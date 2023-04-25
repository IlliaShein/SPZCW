﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SPZCW.Classes.StaticClasses;
using SPZCW.Interfaces;
using System.ServiceProcess;

namespace SPZCWTests
{
    [TestClass]
    public class MessagesTests
    {
        [TestMethod]
        public void TestServicesWithStatusReturnsNotNull()
        {
            //Act
            string result1 = Messages.ServicesWithStatus(ServiceControllerStatus.Running);
            string result2 = Messages.ServicesWithStatus(ServiceControllerStatus.Stopped);
            string result3 = Messages.ServicesWithStatus(ServiceControllerStatus.Paused);
            string result4 = Messages.ServicesWithStatus(ServiceControllerStatus.PausePending);
            string result5 = Messages.ServicesWithStatus(ServiceControllerStatus.StartPending);
            string result6 = Messages.ServicesWithStatus(ServiceControllerStatus.StopPending);
            string result7 = Messages.ServicesWithStatus(ServiceControllerStatus.ContinuePending);

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.IsNotNull(result3);
            Assert.IsNotNull(result4);
            Assert.IsNotNull(result5);
            Assert.IsNotNull(result6);
            Assert.IsNotNull(result7);
        }

        [TestMethod]
        public void TestServiceDescriptionHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceDescriptionHelp());
        }

        [TestMethod]
        public void TestServiceDescriptionHelpReturnsCorrrectValue()
        {
            //Arrange
            string expected =  "This program is designed to provide an intuitive and user-friendly interface for" +
                " managing Windows services.\n\n\r";

            //Act
            string actual = Messages.ServiceDescriptionHelp();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestServiceTypesHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceTypesHelp());
        }

        [TestMethod]
        public void TestServiceTypesHelpReturnsCorrrectValue()
        {
            //Arrange
            string introduction = "";
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

            string expected = introduction + kernelDriver + fileSystemDriver + adapter + interractiveProcess + recognizedDriver + win32OwnProcess + win32ShareProcess;

            //Act
            string actual = Messages.ServiceTypesHelp();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestServiceNamesHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceNamesHelp());
        }

        [TestMethod]
        public void TestServiceNamesHelpReturnsCorrrectValue()
        {
            //Arrange
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

            string expected = introduction + displayName + serviceName + machineName;

            //Act
            string actual = Messages.ServiceNamesHelp();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestServiceStatusHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceStatusHelp());
        }

        [TestMethod]
        public void TestServiceStatusHelpReturnsCorrrectValue()
        {
            //Arrange
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

            string expected = introduction + stopped + startPending + StopPending + running + continuePending + pausePending + paused;

            //Act
            string actual = Messages.ServiceStatusHelp();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestServiceStartTypesHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceStartTypesHelp());
        }

        [TestMethod]
        public void TestServiceStartTypesHelpReturnsCorrrectValue()
        {
            //Arrange
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

            string expected =  introduction + automatic + manual + disabled + boot + system;

            //Act
            string actual = Messages.ServiceStartTypesHelp();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestServiceInfoHelpReturnsNotNull()
        {
            //Arange
            var serviceControllerWrapperMock = new Mock<IService>();

            //Act , Assert
            Assert.IsNotNull(Messages.ServiceInfo(serviceControllerWrapperMock.Object));
        }

        [TestMethod]
        public void TestServiceInfoReturnsCorrrectValue()
        {
            //Arrange
            var serviceControllerWrapperMock = new Mock<IService>();
            serviceControllerWrapperMock.Setup(x => x.GetDescription()).Returns("Description");
            serviceControllerWrapperMock.Setup(x => x.GetDisplayName()).Returns("DisplayName");
            serviceControllerWrapperMock.Setup(x => x.GetServiceName()).Returns("ServiceName");
            serviceControllerWrapperMock.Setup(x => x.GetMachineName()).Returns("MachineName");
            serviceControllerWrapperMock.Setup(x => x.GetServiceType()).Returns(ServiceType.KernelDriver);
            serviceControllerWrapperMock.Setup(x => x.GetStartType()).Returns(ServiceStartMode.Automatic);
            serviceControllerWrapperMock.Setup(x => x.GetPath()).Returns("Path");
            serviceControllerWrapperMock.Setup(x => x.GetStatus()).Returns(ServiceControllerStatus.Running);

            string description = $"\nDescription  :\t{serviceControllerWrapperMock.Object.GetDescription()}\n\r";
            string displayName = $"DisplayName  :\t{serviceControllerWrapperMock.Object.GetDisplayName()}\n\r";
            string serviceName = $"ServiceName  :\t{serviceControllerWrapperMock.Object.GetServiceName()}\n\r";
            string machineName = $"MachineName  :\t{serviceControllerWrapperMock.Object.GetMachineName()}\n\r";
            string serviceType = $"Service Type :\t{serviceControllerWrapperMock.Object.GetServiceType()}\n\r";
            string startType = $"Start Type   :\t{serviceControllerWrapperMock.Object.GetStartType()}\n\r";
            string servicePath = $"Path         :\t{serviceControllerWrapperMock.Object.GetPath()}\n\r";
            string status = $"Status       :\t{serviceControllerWrapperMock.Object.GetStatus()}\n\r";

            string expected = description + displayName + serviceName + machineName + serviceType + servicePath + startType + status;
            //Act
            string actual = Messages.ServiceInfo(serviceControllerWrapperMock.Object);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestServicesWithStatusReturnsCorrectValueWithArguments()
        {
            //Arrange
            string expected1 = "Services with status \"Running\"";
            string expected2 = "Services with status \"Stopped\"";
            string expected3 = "Services with status \"Paused\"";
            string expected4 = "Services with status \"PausePending\"";
            string expected5 = "Services with status \"StartPending\"";
            string expected6 = "Services with status \"StopPending\"";
            string expected7 = "Services with status \"ContinuePending\"";

            //Act
            string actual1 = Messages.ServicesWithStatus(ServiceControllerStatus.Running);
            string actual2 = Messages.ServicesWithStatus(ServiceControllerStatus.Stopped);
            string actual3 = Messages.ServicesWithStatus(ServiceControllerStatus.Paused);
            string actual4 = Messages.ServicesWithStatus(ServiceControllerStatus.PausePending);
            string actual5 = Messages.ServicesWithStatus(ServiceControllerStatus.StartPending);
            string actual6 = Messages.ServicesWithStatus(ServiceControllerStatus.StopPending);
            string actual7 = Messages.ServicesWithStatus(ServiceControllerStatus.ContinuePending);

            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
            Assert.AreEqual(expected4, actual4);
            Assert.AreEqual(expected5, actual5);
            Assert.AreEqual(expected6, actual6);
            Assert.AreEqual(expected7, actual7);
        }
    }
}
