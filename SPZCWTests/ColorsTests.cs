using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spectre.Console;
using SPZCW.Classes.StaticClasses;

namespace SPZCWTests
{
    [TestClass]
    public class ColorsTests
    {
        [TestMethod]
        public void TestColdGammaColor1ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(1, 95, 108);

            //Act
            var actual = Colors.ColdGammaColor1();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestColdGammaColor2ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(73, 217, 236);

            //Act
            var actual = Colors.ColdGammaColor2();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColdGammaColor3ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(2, 205, 232);

            //Act
            var actual = Colors.ColdGammaColor3();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColdGammaColor4ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(32, 96, 105);

            //Act
            var actual = Colors.ColdGammaColor4();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColdGammaColor5ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(17, 167, 218);

            //Act
            var actual = Colors.ColdGammaColor5();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColdGammaColor6ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(160, 217, 236);

            //Act
            var actual = Colors.ColdGammaColor6();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColdGammaColor7ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(0, 179, 212);

            //Act
            var actual = Colors.ColdGammaColor7();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColdGammaColor8ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(56, 150, 179);

            //Act
            var actual = Colors.ColdGammaColor8();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}