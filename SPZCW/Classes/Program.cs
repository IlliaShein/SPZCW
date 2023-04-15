using System;
using System.ServiceProcess;

namespace SPZCW
{
    class Program
    {
        static public Service[] Services;
        static void Main(string[] args)
        {
            Services = GetServices();

            while (true)
            {
                Menu.ProcessMainMenu();
            }
        }

        static public Service[] GetServices()
        {
            ServiceController[] services = ServiceController.GetServices();
            Service[] Services = new Service[services.Length];

            for (int i = 0; i < services.Length; i++)
            {
                Services[i] = new Service(services[i]);
            }
            return Services;
        }

    }
}