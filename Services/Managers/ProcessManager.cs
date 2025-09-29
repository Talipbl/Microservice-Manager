using Services.Consts;
using Services.Enums;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Services
{
    public class ProcessManager
    {
        private readonly ConcurrentDictionary<Microservice, Process> _processMap = new();
        private SemaphoreSlim _semaphore;
        private readonly int _maxConcurrent;
        private CancellationTokenSource _cts;
        private CancellationToken Token => _cts.Token;

        private Configurations _configurations;


        public event EventHandler<ServiceLogEventArgs> LogReceived;
        public event EventHandler<ServiceStatusEventArgs> StatusChanged;

        public ProcessManager(int maxConcurrent = 5)
        {
            _cts = new CancellationTokenSource();
            _maxConcurrent = maxConcurrent;
            _semaphore = new SemaphoreSlim(_maxConcurrent, _maxConcurrent);
            _configurations = ConfigManager.LoadConfig();
        }

        public async Task StartServiceAsync(Microservice service, string arguments)
        {
            if (_processMap.TryGetValue(service, out var existingProcess) && !existingProcess.HasExited)
            {
                OnLog(service.Name, ProcessConsts.ServiceAlreadyRunning, DataLabel.Warning);
                return;
            }

            OnStatus(service.Name, ServiceStatus.Queued);

            await _semaphore.WaitAsync(Token);

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo("dotnet", arguments)
                    {
                        WorkingDirectory = service.Path,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    },
                    EnableRaisingEvents = true,
                };

                process.OutputDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        var lower = e.Data.ToLowerInvariant();

                        var match = Regex.Match(e.Data, @"Now listening on:\s+(https?://\S+)", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            service.ListeningUrl = match.Groups[1].Value;
                            OnLog(service.Name, $"[{DateTime.Now:HH:mm:ss} URL] {service.ListeningUrl}", DataLabel.Url);

                            //TODO: Daha isabetli bir durum incelemesi yapılabilir.
                            service.CurrentAction = ServiceStatus.Running;
                            OnStatus(service.Name, ServiceStatus.Running);

                            ReleaseSemaphore();

                            return;
                        }

                        if (lower.Contains("error") || lower.Contains("err") || lower.Contains("exception"))
                            OnLog(service.Name, e.Data, DataLabel.Warning);
                        else if (lower.Contains("warning") || lower.Contains("warn") || lower.Contains("wrn"))
                            OnLog(service.Name, e.Data, DataLabel.Warning);
                        else if (lower.Contains("stop") || lower.Contains("stopped"))
                            OnLog(service.Name, e.Data, DataLabel.Stop);
                        else if (lower.Contains("url") && Regex.IsMatch(e.Data, @"https?:\/\/[^\s]+", RegexOptions.IgnoreCase))
                            OnLog(service.Name, e.Data, DataLabel.Url);
                        else if (Regex.IsMatch(e.Data, @"HTTP.*?(\\d{3})\\b", RegexOptions.IgnoreCase))
                            OnLog(service.Name, e.Data, DataLabel.Information);
                        else if (lower.Contains("info") || lower.Contains("inf") || lower.Contains("debug") || lower.Contains("dbg"))
                            OnLog(service.Name, e.Data, DataLabel.Debug);
                        else
                            OnLog(service.Name, e.Data, DataLabel.None);
                    }
                };

                process.ErrorDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        OnLog(service.Name, e.Data, DataLabel.Error);

                    OnStatus(service.Name, ServiceStatus.Error);
                };

                process.Exited += (s, e) =>
                {
                    lock (_processMap)
                    {
                        _processMap.TryRemove(service, out _);
                        OnStatus(service.Name, ServiceStatus.Stopped);
                        OnLog(service.Name, $"{ProcessConsts.ServiceExited} (Code: {process.ExitCode})", DataLabel.Warning);

                        if (process.ExitCode < 1)
                        {
                            service.ResetRestartCount();
                            return;
                        }

                        ReleaseSemaphore();

                        if (_configurations.RestartOnError && service.RestartCount < _configurations.RestartLimit)
                        {
                            OnStatus(service.Name, ServiceStatus.Restarting);
                            OnLog(service.Name, $"{ProcessConsts.ServiceExited} Restarting... (Attempt {service.RestartCount + 1}/{_configurations.RestartLimit})", DataLabel.Warning);
                            service.RestartCount++;
                            Task.Delay(_configurations.StartupDelay).Wait();
                            _ = StartServiceAsync(service, arguments);
                        }
                        else
                        {
                            service.ResetRestartCount();
                        }
                    }
                };

                if (process.Start())
                {
                    _processMap[service] = process;
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    OnStatus(service.Name, ServiceStatus.Starting);
                    OnLog(service.Name, $"Service {service.Name} started.", DataLabel.Success);
                }
                else
                {
                    OnStatus(service.Name, ServiceStatus.Error);
                    OnLog(service.Name, $"Failed to start {service.Name}", DataLabel.Error);
                    ReleaseSemaphore();
                }
            }
            catch (OperationCanceledException)
            {
                OnStatus(service.Name, ServiceStatus.Canceled);
                OnLog(service.Name, $"Service {service.Name} cancelled before start.", DataLabel.Information);
                ReleaseSemaphore();
            }
            catch (Exception ex)
            {
                OnStatus(service.Name, ServiceStatus.Error);
                OnLog(service.Name, ex.Message, DataLabel.Error);
                ReleaseSemaphore();
            }
        }
        public async Task StopServiceAsync(Microservice service)
        {
            if (!_processMap.TryGetValue(service, out var process))
            {
                OnLog(service.Name, ProcessConsts.ServiceNotRunning, DataLabel.Warning);
                return;
            }

            try
            {
                OnStatus(service.Name, ServiceStatus.Stopping);

                process.Kill();
                await process.WaitForExitAsync();

                _processMap.TryRemove(service, out _);
                OnStatus(service.Name, ServiceStatus.Stopped);
                OnLog(service.Name, $"Service {service.Name} stopped.", DataLabel.Warning);
            }
            catch (Exception ex)
            {
                OnStatus(service.Name, ServiceStatus.Error);
                OnLog(service.Name, $"Error stopping service: {ex.Message}", DataLabel.Error);
            }
            finally
            {
                ReleaseSemaphore();
            }
        }
        public async Task RestartServiceAsync(Microservice service, string arguments)
        {
            OnStatus(service.Name, ServiceStatus.Restarting);
            await StopServiceAsync(service);
            await StartServiceAsync(service, arguments);
        }

        public void StopAllServicesAsync()
        {
            try
            {
                foreach (var item in _processMap)
                {
                    var service = item.Key;
                    var process = item.Value;

                    OnStatus(service.Name, ServiceStatus.Stopping);

                    process.Kill();
                    process.WaitForExit(3000);
                    process.Dispose();

                    _processMap.TryRemove(service, out _);
                    OnStatus(service.Name, ServiceStatus.Stopped);
                    OnLog(service.Name, $"Service {service.Name} stopped.", DataLabel.Warning);
                }
            }
            finally
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = new CancellationTokenSource();
                _semaphore = new SemaphoreSlim(_maxConcurrent, _maxConcurrent);
            }
        }

        public Process GetProcessForService(Microservice service)
        {
            if (!_processMap.TryGetValue(service, out var prc))
                return null;

            return prc;
        }
        public Microservice GetMicroservice(string serviceName)
        {
            return _processMap.Keys.FirstOrDefault(s => s.Name.Equals(serviceName, StringComparison.OrdinalIgnoreCase));
        }
        public List<Microservice> GetRunningServices()
        {
            return _processMap.Where(p => !p.Value.HasExited).Select(p => p.Key).ToList();
        }

        private void OnLog(string serviceName, string message, DataLabel label)
            => LogReceived?.Invoke(this, new ServiceLogEventArgs(serviceName, message, label));

        private void OnStatus(string serviceName, ServiceStatus status)
            => StatusChanged?.Invoke(this, new ServiceStatusEventArgs(serviceName, status));

        private void ReleaseSemaphore()
        {
            try
            {
                if (_semaphore != null && _semaphore.CurrentCount < _maxConcurrent)
                    _semaphore.Release();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Semaphore release error: {ex.Message}");
            }
        }
    }
}
