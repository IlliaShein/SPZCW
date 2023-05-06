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

        public static string ServiceDescriptionHelp()
        {
            string introduction = "[bold]This program is designed to provide an intuitive and user-friendly interface for" +
                " managing Windows services.[/]\n\n\r";
            string mainText = "You can view information about running, stopped and services with any status using buttons" +
                " \"Active services\", \"Stopped services\" and \"All services\" respectively. If you need to search for other" +
                " criteria, or more of them, you can use the \"Filter services\" button. To change a service, you need to find" +
                " it by display name via the \"Process service\" button. After that, you will see detailed information about the" +
                " found service and you will be able to perform certain actions with it (start/stop (depending on the current state)," +
                " restart, change display name, change description, change service type). Please note that some services cannot be" +
                " stopped, this is indicated in the description to them after the search. Enjoy using the program.\n\n\r";

            return introduction + mainText;
        }

        public static string ServiceTypesHelp()
        {
            string introduction = "[bold]In Windows operating systems, services are classified into several" +
                "types based on how they interact with the system and what resources they manage.[/]\n\n\r";
            string kernelDriver = "[cyan1]Kernel Driver[/]: these are services that run in the context of the operating system " +
                "kernel and provide access to hardware or other resources that require low-level control. " +
                "Examples include device drivers for devices such as sound cards, video cards, or network adapters.\n\n\r";
            string fileSystemDriver = "[cyan1]File System Driver[/]: these are services that provide access to file systems and" +
                " manage read and write operations on disks. Such services can be used to work with various types" +
                " of file systems, such as NTFS or FAT32.\n\n\r";
            string adapter = "[cyan1]Adapter[/]: these are services that provide access to network adapters and manage " +
                "data transmission through them. Examples include services related to TCP/IP protocols, as well as " +
                "services for processing network packet traffic.\n\n\r";
            string interractiveProcess = "[cyan1]Interactive Process[/]: these are services designed to interact with the user through" +
                " a graphical interface. Examples include services for managing the display or services for managing" +
                " user notifications.\n\n\r";
            string recognizedDriver = "[cyan1]Recognizer Driver[/]: these are services that provide" +
                " recognition of various devices and resources. Examples include services that detect and recognize" +
                " connected USB devices or services that manage speech recognition.\n\n\r";
            string win32OwnProcess = "[cyan1]Win32 Own Process[/]: these are services that run in their own process and do not share" +
                " resources with other processes. Examples include services for running server applications" +
                " or services that manage databases.\n\n\r";
            string win32ShareProcess = "[cyan1]Win32 Share Process[/]: these are services that run in a shacyan1 process with" +
                " other services, allowing them to share system resources. Examples include services for managing" +
                " printing or services for providing network security.\n\n\r";

            return introduction + kernelDriver + fileSystemDriver + adapter + interractiveProcess + recognizedDriver + win32OwnProcess + win32ShareProcess;
        }

        public static string ServiceNamesHelp()
        {
            string introduction = "[bold]Each service is identified by a unique name, which consists of three components: " +
                "the service name, the display name, and the machine name.[/]\n\n\r";
            string displayName = "[cyan1]DisplayName[/]: The display name is the name that is shown to users in the Windows" +
                " Services applet in the Control Panel. The display name can be different from the service name," +
                " and is typically a more user-friendly name that describes the function of the service.\n\n\r";
            string serviceName = "[cyan1]ServiceName[/]: The service name is the name used to identify the service internally in" +
                " Windows. This name is used by the operating system to start and stop the service," +
                " as well as to monitor its status.\n\n\r";
            string machineName = "[cyan1]MachineName[/]: This name is used to specify the name of the machine on which" +
                " the service is running. This property is optional, and if it is not specified, the local machine" +
                " is assumed.\n\n\r";

            return introduction + displayName + serviceName + machineName;
        }

        public static string ServiceStatusHelp()
        {
            string introduction = "[bold]In Windows operating system, services are background processes that" +
                " can be started automatically when the system boots up or manually by a user or another application." +
                " Services have a set of pcyan1efined statuses that indicate their current state of operation." +
                "The status of a service is one of the most important pieces of information when it comes to" +
                " managing and troubleshooting services in Windows.There are seven possible service statuses" +
                " in Windows. These statuses are:[/]\n\n\r";
            string stopped = "[cyan1]Stopped[/]: This value indicates that the service is not running. " +
                "This means that the service is not currently executing any tasks or performing any operations.\n\n\r";
            string startPending = "[cyan1]StartPending[/]: This value indicates that the service has been requested to start, but" +
                " it is not yet running. This means that the service is currently in the process of starting up.\n\n\r";
            string StopPending = "[cyan1]StopPending[/]: This value indicates that the service has been requested to stop," +
                " but it is not yet stopped. This means that the service is currently in the process" +
                " of shutting down.\n\n\r";
            string running = "[cyan1]Running[/]: This value indicates that the service is currently running. " +
                "This means that the service is currently executing tasks or performing operations.\n\n\r";
            string continuePending = "[cyan1]ContinuePending[/]: This value indicates that the service has been requested" +
                " to continue from a paused state, but it is not yet running. This means that the service" +
                " is currently in the process of resuming its operations after being paused.\n\n\r";
            string pausePending = "[cyan1]PausePending[/]: This value indicates that the service has been requested" +
                " to pause, but it is not yet paused. This means that the service is currently in the process" +
                " of being paused.\n\n\r";
            string paused = "[cyan1]Paused[/]: This value indicates that the service is currently paused. This means that" +
                " the service is currently not executing any tasks or performing any operations, " +
                "but it can be resumed later.\n\n\r";

            return introduction + stopped + startPending + StopPending + running + continuePending + pausePending + paused;
        }

        public static string ServiceStartTypesHelp()
        {
            string introduction = "[bold]In Windows operating systems, a service is a program that runs in the background and" +
                " performs various tasks, such as managing network connections, printing documents, or providing " +
                "remote access to resources. Windows services can have different start types, which determine when " +
                "the service is loaded and started by the operating system.There are five different service start " +
                "types in Windows:[/]\n\n\r";
            string automatic = "[cyan1]Automatic[/]: This is the default start type for most Windows services. " +
                "Services set to this start type are started automatically when the operating system boots up. " +
                "This type of service is important for background processes that are essential to the proper " +
                "functioning of the system, such as device drivers or antivirus software.\n\n\r";
            string manual = "[cyan1]Manual[/]: Services set to this start type do not start automatically when the operating " +
                "system boots up. Instead, they must be started manually by a user or by another application. " +
                "This type of service is typically used for services that are not essential to the functioning " +
                "of the system, but may be needed by specific applications.\n\n\r";
            string disabled = "[cyan1]Disabled[/]: Services set to this start type are not started at all, even if they " +
                "are requicyan1 by other applications. This type of service is typically used for services that " +
                "are no longer needed or that have  been replaced by another service.\n\n\r";
            string boot = "[cyan1]Boot[/]: Services set to this start type are started during the boot process, before any" +
                " user logs in. This type of service is only used by system services and is not available for " +
                "user-defined services.\n\n\r";
            string system = "[cyan1]System[/]: This start type is used only by kernel-mode device drivers and services that" +
                " are critical to the operating system. Services set to this start type are loaded by the operating " +
                "system loader before any other start type.\n\n\r";

            return introduction + automatic + manual + disabled + boot + system;
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
