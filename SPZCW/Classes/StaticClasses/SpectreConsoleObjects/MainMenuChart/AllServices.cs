using System.ServiceProcess;

namespace SPZCW.Classes.StaticClasses.SpectreConsoleObjects.MainMenuChart
{
    abstract public class AllServices
    {
        protected ServiceController[] Services { get; private set; }

        public AllServices()
        {
            Services = ServiceController.GetServices();
        }
    }
}
