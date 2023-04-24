using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SPZCW;
using SPZCW.Classes;
using SPZCW.Interfaces;
using System;


namespace SPZCWTests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void TestConstructor_throws_ArgumentException_when_invalid_DisplayName_is_provided()
        {
            Assert.ThrowsException<ArgumentException>(() => new Service("AKFH@$*(%@!ASJFP"));
        }

        [TestMethod]
        public void TestGetDisplayName_ReturnsCorrectDisplayName()
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
        public void TestGetDisplayName_ReturnsCorrectServiceName()
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
        public void TestGetDisplayName_ReturnsCorrectMachineName()
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
    }
}
