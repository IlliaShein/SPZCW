using System.ServiceProcess;
using SPZCW.Classes;
using SPZCW.Interfaces;
using SPZCW.Nums;

namespace SPZCW
{
    public class Program
    {
        static public IService[] Services { get; set; }
        static void Main(string[] args)
        {
            Services = GetServices();

            MainMenuChartType type = MainMenuChartType.BYSTATUS;
            while (true)
            {
                Menu.ProcessMainMenu(type);

                if (type == MainMenuChartType.BYMACHINENAME)
                {
                    type = MainMenuChartType.BYSTATUS;
                }
                else
                {
                    type++;
                }
            }
        }

        static public IService [] GetServices()
        {
            ServiceController[] services = ServiceController.GetServices();
            IService[] Services = new Service[services.Length];

            for (int i = 0; i < services.Length; i++)
            {
                ServiceControllerWrapper SCwrapper = new ServiceControllerWrapper(services[i]);
                Services[i] = new Service(SCwrapper);
            }
            return Services;
        }
    }
}