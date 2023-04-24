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
        public void TestServiceDescriptionHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceDescriptionHelp());
        }

        [TestMethod]
        public void TestServiceTypesHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceTypesHelp());
        }

        [TestMethod]
        public void TestServiceNamesHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceNamesHelp());
        }

        [TestMethod]
        public void TestServiceStatusHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceStatusHelp());
        }

        [TestMethod]
        public void TestServiceStartTypesHelpReturnsNotNull()
        {
            Assert.IsNotNull(Messages.ServiceStartTypesHelp());
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
