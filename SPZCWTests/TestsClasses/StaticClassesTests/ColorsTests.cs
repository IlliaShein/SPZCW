using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spectre.Console;
using SPZCW.Classes.StaticClasses;

namespace SPZCWTests
{
    [TestClass]
    public class ColorsTests
    {
        [TestMethod]
        public void TestColor1ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(200, 50, 50);

            //Act
            var actual = Colors.Color1();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestColor2ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(50, 200, 50);

            //Act
            var actual = Colors.Color2();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColor3ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(50, 50, 200);

            //Act
            var actual = Colors.Color3();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColor4ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(200, 200, 50);

            //Act
            var actual = Colors.Color4();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColor5ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(200, 50, 200);

            //Act
            var actual = Colors.Color5();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColor6ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(50, 200, 200);

            //Act
            var actual = Colors.Color6();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColor7ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(155, 50, 155);

            //Act
            var actual = Colors.Color7();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColor8ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(60, 32, 200);

            //Act
            var actual = Colors.Color8();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}