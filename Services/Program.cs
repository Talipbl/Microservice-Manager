using System.Threading.Tasks;

namespace Services
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Form1 form = new();
            ProcessManager manager = new();
            try
            {
                Application.Run(form);
            }
            catch (Exception ex)
            {
                manager.StopAllServicesAsync();
            }
        }
    }
}