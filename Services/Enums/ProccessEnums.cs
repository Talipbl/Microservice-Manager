using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Enums
{
    public enum ServiceStatus
    {
        Stopped,
        Starting,
        Running,
        Stopping,
        Restarting,
        Error,
        Crashed,
        Queued,
        Canceled
    }

    public enum ServiceType
    {
        Run,
        Build,
        Clean,
        Restore
    }

    public enum DataLabel
    {
        None,
        Error,
        Warning,
        Success,
        Information,
        Debug,
        Stop,
        Url
    }
}
