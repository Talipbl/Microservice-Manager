using Services.Enums;

namespace Services
{
    public class ServiceStatusEventArgs : EventArgs
    {
        public string ServiceName { get; }
        public ServiceStatus Status { get; }

        public ServiceStatusEventArgs(string serviceName, ServiceStatus status)
        {
            ServiceName = serviceName;
            Status = status;
        }
    }
}
