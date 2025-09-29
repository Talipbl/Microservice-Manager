using Services.Consts;
using Services.Enums;
using Services.Helpers;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using Timer = System.Timers.Timer;

namespace Services
{
    public partial class Form1 : Form
    {
        private Dictionary<string, RichTextBox> _logBoxMap = new();
        private ConcurrentQueue<(string service, string message, DataLabel label)> _logQueue = new();

        private ImageList _serviceStatusImages;
        private List<Category> _categories;
        private Timer _procDiagnosticTimer;

        private Configurations _configurations;

        private volatile bool _semaphoreActive = true;

        private int _maxLogLines;
        private DateTime _lastMemoryWarningTime = DateTime.MinValue;
        private TimeSpan _warningCooldown = TimeSpan.FromSeconds(60);

        private readonly ProcessManager _processManager;


        public Form1()
        {
            InitializeComponent();
            InitSettings();

            if (_configurations.IsMonitored)
                InitMemoryMonitor();

            InitNotify();
            InitLogFlushTimer();
            InitTabIcons();

            int maxConcurrent = _semaphoreActive ? _configurations.MaxConcurrentStarts : int.MaxValue;
            _processManager = new ProcessManager(maxConcurrent: maxConcurrent);

            _processManager.LogReceived += ProcessManager_LogReceived;
            _processManager.StatusChanged += ProcessManager_StatusChanged;
        }

        private void ProcessManager_LogReceived(object sender, ServiceLogEventArgs e)
        {
            _logQueue.Enqueue((e.ServiceName, e.Message, e.Label));
            if (e.Label == DataLabel.Error && _configurations.AudibleWarning)
            {
                Invoke(() =>
                {
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(2000, $"Error in {e.ServiceName} service!", e.Message, ToolTipIcon.Error);
                });
            }
        }
        private void ProcessManager_StatusChanged(object sender, ServiceStatusEventArgs e)
        {
            var tabPage = GetCurrentTab(e.ServiceName);
            if (tabPage == null)
                return;

            BeginInvoke(new Action(() =>
            {
                string key = e.Status switch
                {
                    ServiceStatus.Starting => "Starting",
                    ServiceStatus.Running => "Running",
                    ServiceStatus.Stopped => "Stopped",
                    ServiceStatus.Error => "Error",
                    ServiceStatus.Queued => "Queued",
                    ServiceStatus.Canceled => "Canceled",
                    ServiceStatus.Restarting => "Restarting",
                    _ => "Stopped"
                };

                tabPage.ImageKey = key;

                if (e.Status == ServiceStatus.Canceled)
                    tabPage.ImageIndex = -1;
            }));
        }

        private RichTextBox GetLogBoxForService(string serviceName)
        {
            if (!_logBoxMap.TryGetValue(serviceName, out var rtb))
                return null;

            return rtb;
        }


        #region Process Management

        private void AppendLog(string serviceName, string message, DataLabel label)
        {
            BeginInvoke(new Action(() =>
            {
                var box = GetLogBoxForService(serviceName);
                if (box == null)
                    return;

                box.SelectionColor = label switch
                {
                    DataLabel.Error => Color.OrangeRed,
                    DataLabel.Warning => Color.Orange,
                    DataLabel.Success => Color.LightGreen,
                    DataLabel.Information => Color.LightBlue,
                    DataLabel.Debug => Color.LightGray,
                    DataLabel.Stop => Color.Red,
                    DataLabel.Url => Color.LightBlue,
                    _ => Color.White
                };

                box.AppendText($"{message.Trim()}{Environment.NewLine}");
                box.ScrollToCaret();
                TrimLog(box);
            }));
        }

        #region Windows Terminal Integration

        private Task StartInWindowsTerminal(Microservice service, string args)
        {
            string wtArgs = $@"new-tab --title ""{service.Name}"" -d ""{service.Path}"" dotnet {args}";

            var psi = new ProcessStartInfo
            {
                FileName = "wt.exe",
                Arguments = wtArgs,
                UseShellExecute = false
            };

            try
            {
                var process = Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terminal açılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AppendLog(service.Name,
                $"[{DateTime.Now:HH:mm:ss} START] {service.Name} service started with command: dotnet {args} in {service.Path}",
                DataLabel.Success);

            return Task.CompletedTask;
        }
        private Task StopInWindowsTerminal(Microservice service)
        {
            string psCmd =
                $@"powershell -NoExit -ExecutionPolicy Bypass -Command ""Get-CimInstance Win32_Process `
          | Where-Object {{ $_.CommandLine -like '*dotnet run*' -and $_.CommandLine -like '*{service.Path}*' }} `
          | Select-Object -ExpandProperty ProcessId `
          | ForEach-Object {{ Stop-Process -Id $_ -Force }}""";

            var psi = new ProcessStartInfo
            {
                FileName = "wt.exe",
                Arguments = $@"new-tab --title ""{service.Name} | Stop"" -d ""{service.Path}"" {psCmd}",
                UseShellExecute = true
            };

            Process.Start(psi);
            AppendLog(service.Name, $"[{DateTime.Now:HH:mm:ss} STOP] {service.Name} service stopped in Windows Terminal.", DataLabel.Success);
            return Task.CompletedTask;
        }
        private Task RestartInWindowsTerminal(Microservice service)
        {
            string psCmd =
                $@"powershell -NoExit -ExecutionPolicy Bypass -Command `
            ""Get-CimInstance Win32_Process `
              | Where-Object {{ $_.CommandLine -like '*dotnet run*' -and $_.CommandLine -like '*{service.Path}*' }} `
              | Select-Object -ExpandProperty ProcessId `
              | ForEach-Object {{ Stop-Process -Id $_ -Force }}; `
            cd '{service.Path}'; dotnet run""";

            var psi = new ProcessStartInfo
            {
                FileName = "wt.exe",
                Arguments = $@"new-tab --title ""{service.Name} | Restart"" -d ""{service.Path}"" {psCmd}",
                UseShellExecute = true
            };

            Process.Start(psi);
            return Task.CompletedTask;
        }
        #endregion

        private void TrimLog(RichTextBox box)
        {
            var lines = box.Lines;
            if (lines.Length <= _maxLogLines)
                return;

            var newLines = lines
                .Skip(lines.Length - _maxLogLines)
                .ToArray();

            box.Lines = newLines;
        }
        private TabPage? GetCurrentTab(string serviceName)
        {
            return tabMicroservices.TabPages
                .Cast<TabPage>()
                .FirstOrDefault(t => t.Tag is MicroserviceTag tag && tag.Service.Name == serviceName);
        }
        #endregion

        #region UI Event Handlers
        private void _procDiagnosticTimer_Tick(object sender, EventArgs e)
        {
            double totalMemory = 0;
            bool perServiceExceeded = false;
            bool totalExceeded = false;

            foreach (var tab in tabMicroservices.TabPages)
            {
                try
                {
                    var tag = (tab as TabPage)?.Tag as MicroserviceTag;
                    var process = _processManager.GetProcessForService(tag?.Service);
                    if (process != null && !process.HasExited)
                    {
                        var memBytes = process.WorkingSet64;
                        var memMB = memBytes / (1024.0 * 1024.0);
                        if (memMB > _configurations.MaximumMemoryUsagePerMicroservice && _configurations.MaximumMemoryUsagePerMicroservice != 0)
                            perServiceExceeded = true;

                        Invoke(() => tag.MemoryLabel.Text = $"RAM: {memMB:F1} MB");
                        totalMemory += memMB;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            if (totalMemory > _configurations.MaximumMemoryUsage && _configurations.MaximumMemoryUsage != 0)
                totalExceeded = true;

            if (_configurations.IsMonitored && (perServiceExceeded || totalExceeded) && DateTime.Now - _lastMemoryWarningTime > _warningCooldown)
            {
                _lastMemoryWarningTime = DateTime.Now;

                string msg = perServiceExceeded
                    ? "One or more services exceeded memory limits."
                    : "Total memory usage exceeded threshold.";

                notifyIcon.ShowBalloonTip(4000, "Memory Warning", msg, ToolTipIcon.Warning);
            }

            var anyRunning = _processManager.GetRunningServices().Count > 0;
            if (anyRunning)
            {
                Invoke(() =>
                {
                    cmbCategories.Enabled = false;
                    toolbtnSettings.Enabled = false;
                });
            }
            else
            {
                Invoke(() =>
                {
                    cmbCategories.Enabled = true;
                    toolbtnSettings.Enabled = true;
                });
            }

            Invoke(() =>
            {
                toollblMemory.Text = $"Memory Usage: {totalMemory:F2} MB";
                toollblServices.Text = $"Working Services: {_processManager.GetRunningServices().Count}/{_categories.Sum(c => c.Services.Count)}";
            });
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCategory = cmbCategories.SelectedItem as Category;
            if (selectedCategory == null)
                return;

            tabMicroservices.TabPages.Clear();
            _logBoxMap.Clear();
            _logQueue.Clear();

            lblAppStatus.Text = string.Empty;
            if (selectedCategory.Services.Count == 0)
            {
                lblAppStatus.Text = ProcessConsts.NoServicesAvailable;
                return;
            }

            foreach (var service in selectedCategory.Services)
            {
                var microServiceName = service.IsFavorite ? $"{service.Name} ★" : service.Name;
                var tab = new TabPage(microServiceName);

                var panel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Top,
                    Height = 45,
                    FlowDirection = FlowDirection.LeftToRight,
                    Padding = new Padding(5)
                };

                AddButton(panel, new() { Text = "Start", Name = $"{tab.Name}_btnStart", BackColor = Color.LightGreen },
                    () => _processManager.StartServiceAsync(service, "run"));
                AddButton(panel, new() { Text = "Stop", Name = $"{tab.Name}_btnStop", BackColor = Color.OrangeRed, ForeColor = Color.White },
                    async () => _processManager.StopServiceAsync(service));
                AddButton(panel, new() { Text = "Restart", Name = $"{tab.Name}_btnRestart", BackColor = Color.LightGray },
                    async () => _processManager.RestartServiceAsync(service, "run"));
                AddButton(panel, new() { Text = "Clean", Name = $"{tab.Name}_btnClean", BackColor = Color.LightGray },
                    () => StartInWindowsTerminal(service, "clean"));
                AddButton(panel, new() { Text = "Restore", Name = $"{tab.Name}_btnRestore", BackColor = Color.LightGray },
                    () => StartInWindowsTerminal(service, "restore"));
                AddButton(panel, new() { Text = "Build", Name = $"{tab.Name}_btnBuild", BackColor = Color.LightGray },
                    () => StartInWindowsTerminal(service, "build"));

                var richTextBox = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    DetectUrls = true,
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    Font = new Font("Consolas", 11),
                    ScrollBars = RichTextBoxScrollBars.Vertical,
                    Tag = service
                };

                richTextBox.LinkClicked += (s, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = e.LinkText,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        _logQueue.Enqueue((service.Name, $"[{DateTime.Now:HH:mm:ss} EXCEPTION] Failed to open link: {ex.Message}", DataLabel.Error));
                    }
                };

                var tag = new MicroserviceTag()
                {
                    Service = service,
                };

                if (_configurations.IsMonitored)
                {
                    var memoryLabel = new Label
                    {
                        Text = "RAM: 0 MB",
                        AutoSize = true,
                        ForeColor = Color.DarkGreen,
                        Location = new Point(10, 50)
                    };

                    tab.Controls.Add(memoryLabel);
                    tag.MemoryLabel = memoryLabel;
                }

                tab.Tag = tag;
                tab.Controls.Add(richTextBox);
                tab.Controls.Add(panel);

                tabMicroservices.TabPages.Add(tab);

                _logBoxMap[service.Name] = richTextBox;
            }
            void AddButton(Panel panel, Button button, Action clickAction)
            {
                button.Width = 80;
                button.Height = 30;
                button.Left = 15;
                button.Top = 10;
                button.Margin = new Padding(3);
                button.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                panel.Controls.Add(button);
                button.Click += (s, e) => clickAction();
            }
        }
        private void toolbtnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            settings.ShowDialog();
            InitSettings();
        }
        private void toolbtnStopAll_Click(object sender, EventArgs e)
        {
            var runningServices = _processManager.GetRunningServices();
            if (runningServices.Count == 0)
            {
                MessageBox.Show("There are no services currently running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                "Are you sure you want to stop all services? This may take some time depending on the number of services.",
                "Confirm Stop All Services",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result != DialogResult.Yes)
                return;

            _processManager.StopAllServicesAsync();
        }
        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void toolbtnStartAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to start all services? This may take some time depending on the number of services.",
                "Confirm Start All Services",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result != DialogResult.Yes)
                return;

            var selectedCategory = cmbCategories.SelectedItem as Category;
            var runnig = _processManager.GetRunningServices();
            var notRunning = selectedCategory?.Services.Where(s => !runnig.Contains(s)).ToList() ?? new();
            if (notRunning.Count == 0)
            {
                MessageBox.Show("All services in the selected category are already running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var svc in notRunning)
                Task.Run(() => _processManager.StartServiceAsync(svc, "run"));
        }
        private void btnRunFavorites_Click(object sender, EventArgs e)
        {
            var selectedCategory = cmbCategories.SelectedItem as Category;
            var runnig = _processManager.GetRunningServices();
            var notRunning = selectedCategory?.Services.Where(s => !runnig.Contains(s) && s.IsFavorite).ToList() ?? new();

            if (notRunning.Count == 0)
            {
                MessageBox.Show("All favorite services in the selected category are already running or no favorite services defined.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var svc in notRunning)
                Task.Run(() => _processManager.StartServiceAsync(svc, "run"));

            notifyIcon.ShowBalloonTip(2000, "Favorites Launched", "Selected favorite services are starting.", ToolTipIcon.Info);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is designed to manage microservices. " +
                "You can start, stop, and monitor the services running on your machine. " +
                "For more information, visit the developer.\r\nDeveloped by Talip",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                this.Activate();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon.ShowBalloonTip(2000, "Running in the background...", "The microservice manager has been minimised to the system tray.", ToolTipIcon.Info);
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var anyRunning = _processManager.GetRunningServices().Count > 0;
            if (anyRunning)
            {
                var result = MessageBox.Show("Some services are still running. Are you sure you want to shut down?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            _processManager.StopAllServicesAsync();
        }
        #endregion

        #region Initialization Methods
        private void InitSettings()
        {
            _configurations = ConfigManager.LoadConfig();
            _maxLogLines = _configurations.LogLineLimit > 0 ? _configurations.LogLineLimit : 500;
            _categories = _configurations.Categories ?? [];

            _semaphoreActive = _configurations.IsLimitedOperation && _configurations.MaxConcurrentStarts > 0;

            cmbCategories.Items.Clear();
            cmbCategories.Items.AddRange(_categories.Cast<object>().ToArray());

            if (_categories.Count is 0 || !_categories.Any(c => c.Services.Count > 0))
            {
                lblAppStatus.Text = ProcessConsts.NoServicesAvailable;
                tabMicroservices.TabPages.Clear();
                _logBoxMap.Clear();
                _logQueue.Clear();
            }
            else
            {
                cmbCategories.SelectedIndex = 0;
                lblAppStatus.Text = string.Empty;
            }

            if (!_configurations.IsMonitored)
                toollblMemory.Visible = false;
            else
                toollblMemory.Visible = true;
        }
        private void InitMemoryMonitor()
        {
            _procDiagnosticTimer = new();
            _procDiagnosticTimer.Interval = 3000;
            _procDiagnosticTimer.Elapsed += _procDiagnosticTimer_Tick;
            _procDiagnosticTimer.AutoReset = true;
            _procDiagnosticTimer.Start();
        }
        private void InitNotify()
        {
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();

            var runningServicesMenu = new ToolStripMenuItem("Running Services");
            runningServicesMenu.DropDownOpening += (s, e) =>
            {
                runningServicesMenu.DropDownItems.Clear();

                var running = _processManager.GetRunningServices();

                if (!running.Any())
                {
                    runningServicesMenu.DropDownItems.Add("None").Enabled = false;
                }
                else
                {
                    foreach (var service in running)
                    {
                        var item = new ToolStripMenuItem($"({service.Category}) {service.Name} - {service.CurrentAction}");

                        if (service.CurrentAction is ServiceStatus.Running && !string.IsNullOrEmpty(service.ListeningUrl))
                        {

                            var manageItem = new ToolStripMenuItem("Go To Web");
                            manageItem.Image = ByteHelper.ByteArrayToImage(Properties.Resources.Web);
                            manageItem.Click += (s, e) =>
                            {
                                Process.Start(new ProcessStartInfo
                                {
                                    FileName = service.ListeningUrl,
                                    UseShellExecute = true
                                });
                            };

                            item.DropDownItems.Add(manageItem);
                        }

                        var restartItem = new ToolStripMenuItem("Restart");
                        restartItem.Click += async (s, e) =>
                        {
                            _processManager.RestartServiceAsync(service, "run");
                        };

                        var stopItem = new ToolStripMenuItem("Stop");
                        stopItem.Click += async (s, e) =>
                        {
                            _processManager.StopServiceAsync(service);
                        };

                        item.DropDownItems.Add(restartItem);
                        item.DropDownItems.Add(stopItem);

                        runningServicesMenu.DropDownItems.Add(item);
                    }
                }
            };

            notifyIcon.ContextMenuStrip.Items.Add("Show", null, (s, e) =>
            {
                this.Invoke(() =>
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.BringToFront();
                });
            });
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add(runningServicesMenu);
            notifyIcon.ContextMenuStrip.Items.Add("Stop All Services", null, (s, e) => _processManager.StopAllServicesAsync());
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add("Settings", null, toolbtnSettings_Click);
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, (s, e) => Application.Exit());
        }
        private void InitLogFlushTimer()
        {
            var flushTimer = new Timer { Interval = _configurations.FlushSequnece };
            flushTimer.Elapsed += (s, e) =>
            {
                int batchSize = 200;
                while (batchSize-- > 0 && _logQueue.TryDequeue(out var entry))
                {
                    AppendLog(entry.service, entry.message, entry.label);
                }
            };
            flushTimer.Start();
        }
        private void InitTabIcons()
        {
            _serviceStatusImages = new ImageList
            {
                ImageSize = new Size(20, 20),
                ColorDepth = ColorDepth.Depth32Bit,
            };

            _serviceStatusImages.Images.Add("Queued", ByteHelper.ByteArrayToImage(Properties.Resources.Status_Queued));
            _serviceStatusImages.Images.Add("Running", ByteHelper.ByteArrayToImage(Properties.Resources.Status_Running));
            _serviceStatusImages.Images.Add("Stopped", ByteHelper.ByteArrayToImage(Properties.Resources.Status_Stopped));
            _serviceStatusImages.Images.Add("Error", ByteHelper.ByteArrayToImage(Properties.Resources.Status_Error));
            _serviceStatusImages.Images.Add("Starting", ByteHelper.ByteArrayToImage(Properties.Resources.Status_Starting));
            _serviceStatusImages.Images.Add("Restarting", ByteHelper.ByteArrayToImage(Properties.Resources.Status_Restarting));

            tabMicroservices.ImageList = _serviceStatusImages;
        }
        #endregion
    }
}
