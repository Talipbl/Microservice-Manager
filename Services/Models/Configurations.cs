namespace Services
{
    public class Configurations
    {
        public List<Category> Categories { get; set; }
        public bool IsMonitored { get; set; }
        public int MaximumMemoryUsage { get; set; }
        public int MaximumMemoryUsagePerMicroservice { get; set; }
        public bool AudibleWarning { get; set; }
        public int FlushSequnece { get; set; }
        public int LogLineLimit { get; set; }
        public bool RestartOnError { get; set; }
        public int StartupDelay { get; set; }
        public int RestartLimit { get; set; }
        public bool IsLimitedOperation { get; set; }
        public int MaxConcurrentStarts { get; set; }

        public Configurations()
        {
            IsMonitored = true;
            AudibleWarning = true;
            FlushSequnece = 100;
            LogLineLimit = 500;
        }
    }
}
