using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using Moq;
using SPZCW;
using SPZCW.Interfaces;
using System;
using System.ServiceProcess;

namespace SPZCWTests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void TestDisplayNameReturnsCorrectValue()
        {
            // Arrange
            string expected = "DisplayName";
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.DisplayName).Returns(expected);

            var service = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = service.DisplayName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestServiceNameReturnsCorrectValue()
        {
            // Arrange
            string expected = "ServiceName";
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.ServiceName).Returns(expected);

            var service = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = service.ServiceName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMachineNameReturnsCorrectValue()
        {
            // Arrange
            string expected = "MachineName";
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.MachineName).Returns(expected);

            var service = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = service.MachineName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStatusReturnsCorrectValue()
        {
            // Arrange
            var expected = ServiceControllerStatus.Running;
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.Status).Returns(ServiceControllerStatus.Running);

            var service = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = service.Status;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStartTypeReturnsCorrectValue()
        {
            // Arrange
            var expected = ServiceStartMode.Automatic;
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.StartType).Returns(ServiceStartMode.Automatic);

            var service = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = service.StartType;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestServiceTypeReturnsCorrectValue()
        {
            // Arrange
            var expected = ServiceType.KernelDriver;
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.ServiceType).Returns(ServiceType.KernelDriver);

            var service = new Service(serviceControllerWrapperMock.Object);

            // Act
            var actual = service.ServiceType;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStartThrowExceptionWhenServiceIsAlreadyRunning()
        {
            // Arrange
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.Status).Returns(ServiceControllerStatus.Running);

            var service = new Service(serviceControllerWrapperMock.Object);

            //Act, Assert
            Assert.ThrowsException<Exception>(() => service.Start());
        }

        [TestMethod]
        public void TestStopThrowExceptionWhenServiceIsAlreadyStopped()
        {
            // Arrange
            var serviceControllerWrapperMock = new Mock<IServiceController>();
            serviceControllerWrapperMock.Setup(x => x.Status).Returns(ServiceControllerStatus.Stopped);

            var service = new Service(serviceControllerWrapperMock.Object);

            //Act, Assert
            Assert.ThrowsException<Exception>(() => service.Stop());
        }


    }
}
