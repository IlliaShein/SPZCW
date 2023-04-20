using System.ServiceProcess;


namespace SPZCW.Classes.StaticClasses
{
    static public class Messages
    {   
        static public string ServicesWithStatus(ServiceControllerStatus status)
        {
            return $"Services with status \"{status}\"";
        }

        static public string ServiceInfo(Service service)
        {
            string displayName = $"\nDisplayName  :\t{service.GetDisplayName()}\n\r";
            string serviceName = $"ServiceName  :\t{service.GetServiceName()}\n\r";
            string machineName = $"MachineName  :\t{service.GetMachineName()}\n\r";
            string serviceType = $"Service Type :\t{service.GetServiceType()}\n\r";
            string startType =   $"Start Type   :\t{service.GetStartType()}\n\r";
            string servicePath = $"Path         :\t{service.GetPath()}\n\r";
            string status =      $"Status       :\t{service.GetStatus()}\n\r";

            return displayName + serviceName + machineName + serviceType + servicePath + startType + status;
        }
    }
}
