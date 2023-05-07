using Spectre.Console;
using SPZCW.Interfaces;
using System.ServiceProcess;

namespace SPZCW.Classes.StaticClasses
{
    public static class Messages
    {
        public static string ServicesWithStatus(ServiceControllerStatus status)
        {
            return $"Services with status \"{status}\":";
        }

        public static Markup Error(string errorMessage)
        {
            return new Markup($"\n[red1]Error: {errorMessage}[/]\n");
        }

        public static string ServiceInfo(IService service)
        {
            string description = $"\nDescription  :\t{service.Description}\n\r";
            string displayName = $"DisplayName  :\t{service.DisplayName}\n\r";
            string serviceName = $"ServiceName  :\t{service.ServiceName}\n\r";
            string machineName = $"MachineName  :\t{service.MachineName}\n\r";
            string serviceType = $"Service Type :\t{service.ServiceType}\n\r";
            string startType =   $"Start Type   :\t{service.StartType}\n\r";
            string servicePath = $"Path         :\t{service.Path}\n\r";
            string status =      $"Status       :\t{service.Status}\n\r";
            string canStop =     $"Can stop     :\t{service.CanStop}\n\r";

            return description + displayName + serviceName + machineName + serviceType + servicePath + startType + status + canStop;
        }
    }
}
