using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Consts
{
    public class ProcessConsts
    {
        public const string ServiceAlreadyRunning = "Service is already running!";
        public const string ServiceNotRunning = "Service is not running.";
        public const string ServiceStarted = "Service started successfully.";
        public const string ServiceExited = "Service exited.";
        public const string ServiceTerminated = "Service terminated.";

        public const string NoRunningServicees = "No running Service to stop.";
        public const string NoServicesAvailable = "There are no services available in this category. Please add a service from the settings.";

    }
}
