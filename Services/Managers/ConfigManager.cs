using System.Text.Json;

namespace Services
{
    public static class ConfigManager
    {
        public static Configurations LoadConfig()
        {
            var configurations = new Configurations()
            {
                IsMonitored = Properties.Settings.Default.IsMonitored,
                MaximumMemoryUsage = Properties.Settings.Default.MaximumMemoryUsage,
                MaximumMemoryUsagePerMicroservice = Properties.Settings.Default.MaximumMemoryUsagePerMicroservice,
                AudibleWarning = Properties.Settings.Default.AudibleWarning,
                FlushSequnece = Properties.Settings.Default.FlushSequnece,
                LogLineLimit = Properties.Settings.Default.LogLineLimit,
                RestartOnError = Properties.Settings.Default.RestartOnError,
                StartupDelay = Properties.Settings.Default.StartupDelay,
                RestartLimit = Properties.Settings.Default.RestartLimit,
                IsLimitedOperation = Properties.Settings.Default.IsLimitedOperation,
                MaxConcurrentStarts = Properties.Settings.Default.MaxConcurrentStarts
            };

            var json = Properties.Settings.Default.Categories;
            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    configurations.Categories = JsonSerializer.Deserialize<List<Category>>(json);
                }
                catch (JsonException)
                {
                    configurations.Categories = new List<Category>();
                }
            }
            else
                configurations.Categories = new List<Category>();

            return configurations;
        }

        public static void SaveConfig(Configurations setting)
        {
            Properties.Settings.Default.IsMonitored = setting.IsMonitored;
            Properties.Settings.Default.MaximumMemoryUsage = setting.MaximumMemoryUsage;Properties.Settings.Default.MaximumMemoryUsagePerMicroservice = setting.MaximumMemoryUsagePerMicroservice;
            Properties.Settings.Default.AudibleWarning = setting.AudibleWarning;
            Properties.Settings.Default.FlushSequnece = setting.FlushSequnece;
            Properties.Settings.Default.LogLineLimit = setting.LogLineLimit;
            Properties.Settings.Default.Categories = JsonSerializer.Serialize(setting.Categories, new JsonSerializerOptions { WriteIndented = true });
            Properties.Settings.Default.RestartOnError = setting.RestartOnError;
            Properties.Settings.Default.StartupDelay = setting.StartupDelay;
            Properties.Settings.Default.RestartLimit = setting.RestartLimit;
            Properties.Settings.Default.IsLimitedOperation = setting.IsLimitedOperation;
            Properties.Settings.Default.MaxConcurrentStarts = setting.MaxConcurrentStarts;
            Properties.Settings.Default.Save();
        }

        public static void ExportConfigToJson(Configurations setting, string path)
        {
            string json = JsonSerializer.Serialize(setting);
            File.WriteAllText(path, json);
        }

        public static void ImportConfigFromJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Configuration file not found.", filePath);

            var json = File.ReadAllText(filePath);
            var configurations = JsonSerializer.Deserialize<Configurations>(json) ?? new Configurations();

            SaveConfig(configurations);
        }
    }
}
