using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPZCW.Classes.StaticClasses;
using System.ServiceProcess;

namespace SPZCWTests
{
    [TestClass]
    public class MessagesTests
    {

        [TestMethod]
        public void ServicesWithStatusReturnsCorrectValueWithArgumentRunning()
        {
            //Arrange
            string expected = "Services with status \"Running\"";

            //Act
            string actual = Messages.ServicesWithStatus(ServiceControllerStatus.Running);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ServicesWithStatusReturnsCorrectValueWithArgumentStopped()
        {
            //Arrange
            string expected = "Services with status \"Stopped\"";

            //Act
            string actual = Messages.ServicesWithStatus(ServiceControllerStatus.Stopped);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ServicesWithStatusReturnsCorrectValueWithArgumentContinuePending()
        {
            //Arrange
            string expected = "Services with status \"ContinuePending\"";

            //Act
            string actual = Messages.ServicesWithStatus(ServiceControllerStatus.ContinuePending);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ServicesWithStatusReturnsCorrectValueWithArgumentStartPending()
        {
            //Arrange
            string expected = "Services with status \"StartPending\"";

            //Act
            string actual = Messages.ServicesWithStatus(ServiceControllerStatus.StartPending);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ServicesWithStatusReturnsCorrectValueWithArgumentStopPending()
        {
            //Arrange
            string expected = "Services with status \"StopPending\"";

            //Act
            string actual = Messages.ServicesWithStatus(ServiceControllerStatus.StopPending);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ServiceDescriptionHelpReturnsCorrectValue()
        {
            //Arrange
            string expected = "This program is designed to provide an intuitive and user-friendly interface for" +
                " managing Windows services.\n\n\r";

            //Act
            string actual = Messages.ServiceDescriptionHelp();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
