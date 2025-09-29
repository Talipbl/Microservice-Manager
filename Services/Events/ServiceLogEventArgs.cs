using Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceLogEventArgs : EventArgs
    {
        public string ServiceName { get; }
        public string Message { get; }
        public DataLabel Label { get; set; }

        public ServiceLogEventArgs(string serviceName, string message, DataLabel label)
        {
            ServiceName = serviceName;
            Message = message;
            Label = label;
        }
    }
}
