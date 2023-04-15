using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPZCW;
using System;


namespace SPZCWTests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void Constructor_throws_ArgumentException_when_invalid_DisplayName_is_provided()
        {
            Assert.ThrowsException<ArgumentException>(() => new Service("AKFH@$*(%@!ASJFP"));
        }

        [TestMethod]
        public void GetDisplayName_ReturnsCorrectDisplayName()
        {
            //Arrange
            string expected = "Print Spooler";
            Service service = new Service(expected);

            //Act
            string actual = service.GetDisplayName();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetServiceName_ReturnsCorrectServiceName()
        {
            //Arrange
            string expected = "Spooler";
            Service service = new Service("Print Spooler");

            //Act
            string actual = service.GetServiceName();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMachineName_ReturnsCorrectMachineName()
        {
            //Arrange
            string expected = ".";
            Service service = new Service("Print Spooler");

            //Act
            string actual = service.GetMachineName();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
