using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            serviceControllerWrapperMock.Setup(x => x.Description).Returns("Description");
            serviceControllerWrapperMock.Setup(x => x.DisplayName).Returns("DisplayName");
            serviceControllerWrapperMock.Setup(x => x.DisplayName).Returns("ServiceName");
            serviceControllerWrapperMock.Setup(x => x.DisplayName).Returns("MachineName");
            serviceControllerWrapperMock.Setup(x => x.ServiceType).Returns(ServiceType.KernelDriver);
            serviceControllerWrapperMock.Setup(x => x.StartType).Returns(ServiceStartMode.Automatic);
            serviceControllerWrapperMock.Setup(x => x.Path).Returns("Path");
            serviceControllerWrapperMock.Setup(x => x.Status).Returns(ServiceControllerStatus.Running);
            serviceControllerWrapperMock.Setup(x => x.CanStop).Returns(true);

            string description = $"\nDescription  :\t{serviceControllerWrapperMock.Object.Description}\n\r";
            string displayName = $"DisplayName  :\t{serviceControllerWrapperMock.Object.DisplayName}\n\r";
            string serviceName = $"ServiceName  :\t{serviceControllerWrapperMock.Object.ServiceName}\n\r";
            string machineName = $"MachineName  :\t{serviceControllerWrapperMock.Object.MachineName}\n\r";
            string serviceType = $"Service Type :\t{serviceControllerWrapperMock.Object.ServiceType}\n\r";
            string startType =   $"Start Type   :\t{serviceControllerWrapperMock.Object.StartType}\n\r";
            string servicePath = $"Path         :\t{serviceControllerWrapperMock.Object.Path}\n\r";
            string status =      $"Status       :\t{serviceControllerWrapperMock.Object.Status}\n\r";
            string canStop =     $"Can stop     :\t{serviceControllerWrapperMock.Object.CanStop}\n\r";

            string expected = description + displayName + serviceName + machineName + serviceType + servicePath + startType + status + canStop;
            //Act
            string actual = Messages.ServiceInfo(serviceControllerWrapperMock.Object);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestServicesWithStatusReturnsCorrectValueWithArguments()
        {
            //Arrange
            string expected1 = "Services with status \"Running\":";
            string expected2 = "Services with status \"Stopped\":";
            string expected3 = "Services with status \"Paused\":";
            string expected4 = "Services with status \"PausePending\":";
            string expected5 = "Services with status \"StartPending\":";
            string expected6 = "Services with status \"StopPending\":";
            string expected7 = "Services with status \"ContinuePending\":";

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
