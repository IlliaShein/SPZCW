using System;
using System.ServiceProcess;


namespace SPZCW.Classes.StaticClasses
{
    static public class Messages
    {   
        static public string ServicesWithStatus(ServiceControllerStatus status)
        {
            return $"Services with status \"{status}\"";
        }

        static public string ServiceDescriptionHelp()
        {
            return "This program is designed to provide an intuitive and user-friendly interface for" +
                " managing Windows services.\n\n\r";
        }

        static public string ServiceTypesHelp()
        {
            string introduction = "";
            string kernelDriver = "[red]Kernel Driver[/]: these are services that run in the context of the operating system " +
                "kernel and provide access to hardware or other resources that require low-level control. " +
                "Examples include device drivers for devices such as sound cards, video cards, or network adapters.\n\n\r";
            string fileSystemDriver = "[red]File System Driver[/]: these are services that provide access to file systems and" +
                " manage read and write operations on disks. Such services can be used to work with various types" +
                " of file systems, such as NTFS or FAT32.\n\n\r";
            string adapter = "[red]Adapter[/]: these are services that provide access to network adapters and manage " +
                "data transmission through them. Examples include services related to TCP/IP protocols, as well as " +
                "services for processing network packet traffic.\n\n\r";
            string interractiveProcess = "[red]Interactive Process[/]: these are services designed to interact with the user through" +
                " a graphical interface. Examples include services for managing the display or services for managing" +
                " user notifications.\n\n\r";
            string recognizedDriver = "[red]Recognizer Driver[/]: these are services that provide" +
                " recognition of various devices and resources. Examples include services that detect and recognize" +
                " connected USB devices or services that manage speech recognition.\n\n\r";
            string win32OwnProcess = "[red]Win32 Own Process[/]: these are services that run in their own process and do not share" +
                " resources with other processes. Examples include services for running server applications" +
                " or services that manage databases.\n\n\r";
            string win32ShareProcess = "[red]Win32 Share Process[/]: these are services that run in a shared process with" +
                " other services, allowing them to share system resources. Examples include services for managing" +
                " printing or services for providing network security.\n\n\r";

            return introduction + kernelDriver + fileSystemDriver + adapter + interractiveProcess + recognizedDriver + win32OwnProcess + win32ShareProcess;
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

        static public string ServiceStartTypesHelp()
        {
            string introduction = "[bold]In Windows operating systems, a service is a program that runs in the background and" +
                " performs various tasks, such as managing network connections, printing documents, or providing " +
                "remote access to resources. Windows services can have different start types, which determine when " +
                "the service is loaded and started by the operating system.There are five different service start " +
                "types in Windows:[/]\n\n\r";
            string automatic = "[red]Automatic[/]: This is the default start type for most Windows services. " +
                "Services set to this start type are started automatically when the operating system boots up. " +
                "This type of service is important for background processes that are essential to the proper " +
                "functioning of the system, such as device drivers or antivirus software.\n\n\r";
            string manual = "[red]Manual[/]: Services set to this start type do not start automatically when the operating " +
                "system boots up. Instead, they must be started manually by a user or by another application. " +
                "This type of service is typically used for services that are not essential to the functioning " +
                "of the system, but may be needed by specific applications.\n\n\r";
            string disabled = "[red]Disabled[/]: Services set to this start type are not started at all, even if they " +
                "are required by other applications. This type of service is typically used for services that " +
                "are no longer needed or that have  been replaced by another service.\n\n\r";
            string boot = "[red]Boot[/]: Services set to this start type are started during the boot process, before any" +
                " user logs in. This type of service is only used by system services and is not available for " +
                "user-defined services.\n\n\r";
            string system = "[red]System[/]: This start type is used only by kernel-mode device drivers and services that" +
                " are critical to the operating system. Services set to this start type are loaded by the operating " +
                "system loader before any other start type.\n\n\r";

            return introduction + automatic + manual + disabled + boot + system;
        }
        static public string ServiceInfo(Service service)
        {
            string description = $"\nDescription  :\t{service.GetDescription()}\n\r";
            string displayName = $"DisplayName  :\t{service.GetDisplayName()}\n\r";
            string serviceName = $"ServiceName  :\t{service.GetServiceName()}\n\r";
            string machineName = $"MachineName  :\t{service.GetMachineName()}\n\r";
            string serviceType = $"Service Type :\t{service.GetServiceType()}\n\r";
            string startType =   $"Start Type   :\t{service.GetStartType()}\n\r";
            string servicePath = $"Path         :\t{service.GetPath()}\n\r";
            string status =      $"Status       :\t{service.GetStatus()}\n\r";

            return description + displayName + serviceName + machineName + serviceType + servicePath + startType + status;
        }
    }
}
