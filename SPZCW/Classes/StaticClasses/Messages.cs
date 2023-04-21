using System.ServiceProcess;


namespace SPZCW.Classes.StaticClasses
{
    static public class Messages
    {   
        static public string ServicesWithStatus(ServiceControllerStatus status)
        {
            return $"Services with status \"{status}\"";
        }
        
        static public string ServiceNamesHelp()
        {
            string introduction = "[bold]Each service is identified by a unique name, which consists of three components: " +
                "the service name, the display name, and the machine name.[/]\n\n\r";
            string displayName = "[red]DisplayName[/]: The display name is the name that is shown to users in the Windows" +
                " Services applet in the Control Panel. The display name can be different from the service name," +
                " and is typically a more user-friendly name that describes the function of the service.\n\n\r";
            string serviceName = "[red]ServiceName[/]: The service name is the name used to identify the service internally in" +
                " Windows. This name is used by the operating system to start and stop the service," +
                " as well as to monitor its status.\n\n\r";
            string machineName = "[red]MachineName[/]: This name is used to specify the name of the machine on which" +
                " the service is running. This property is optional, and if it is not specified, the local machine" +
                " is assumed.\n\n\r";

            return introduction + displayName + serviceName + machineName;
        }

        static public string ServiceStatusHelp()
        {
            string introduction = "[bold]In Windows operating system, services are background processes that" +
                " can be started automatically when the system boots up or manually by a user or another application." +
                " Services have a set of predefined statuses that indicate their current state of operation." +
                "The status of a service is one of the most important pieces of information when it comes to" +
                " managing and troubleshooting services in Windows.There are seven possible service statuses" +
                " in Windows. These statuses are:[/]\n\n\r";
            string stopped = "[red]Stopped[/]: This value indicates that the service is not running. " +
                "This means that the service is not currently executing any tasks or performing any operations.\n\n\r";
            string startPending = "[red]StartPending[/]: This value indicates that the service has been requested to start, but" +
                " it is not yet running. This means that the service is currently in the process of starting up.\n\n\r";
            string StopPending = "[red]StopPending[/]: This value indicates that the service has been requested to stop," +
                " but it is not yet stopped. This means that the service is currently in the process" +
                " of shutting down.\n\n\r";
            string running = "[red]Running[/]: This value indicates that the service is currently running. " +
                "This means that the service is currently executing tasks or performing operations.\n\n\r";
            string continuePending = "[red]ContinuePending[/]: This value indicates that the service has been requested" +
                " to continue from a paused state, but it is not yet running. This means that the service" +
                " is currently in the process of resuming its operations after being paused.\n\n\r";
            string pausePending = "[red]PausePending[/]: This value indicates that the service has been requested" +
                " to pause, but it is not yet paused. This means that the service is currently in the process" +
                " of being paused.\n\n\r";
            string paused = "[red]Paused[/]: This value indicates that the service is currently paused. This means that" +
                " the service is currently not executing any tasks or performing any operations, " +
                "but it can be resumed later.\n\n\r";

            return introduction + stopped + startPending + StopPending + running + continuePending + pausePending + paused;
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
