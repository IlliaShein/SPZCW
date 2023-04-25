using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SPZCW;
using SPZCW.Interfaces;
using System.ServiceProcess;

namespace SPZCWTests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void TestGetDisplayName_ReturnsCorrectValue()
        {
            // Arrange
            string expected = "DisplayName";
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.DisplayName).Returns(expected);

            var myClass = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = myClass.GetDisplayName();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetServiceName_ReturnsCorrectValue()
        {
            // Arrange
            string expected = "ServiceName";
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.ServiceName).Returns(expected);

            var myClass = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = myClass.GetServiceName();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetMachineName_ReturnsCorrectValue()
        {
            // Arrange
            string expected = "MachineName";
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.MachineName).Returns(expected);

            var myClass = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = myClass.GetMachineName();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetStatus_ReturnsCorrectValue()
        {
            // Arrange
            var expected = ServiceControllerStatus.Running;
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.Status).Returns(ServiceControllerStatus.Running);

            var myClass = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = myClass.GetStatus();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetStartType_ReturnsCorrectValue()
        {
            // Arrange
            var expected = ServiceStartMode.Automatic;
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.StartType).Returns(ServiceStartMode.Automatic);

            var myClass = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = myClass.GetStartType();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetServiceType_ReturnsCorrectValue()
        {
            // Arrange
            var expected = ServiceType.KernelDriver;
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.ServiceType).Returns(ServiceType.KernelDriver);

            var myClass = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = myClass.GetServiceType();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
