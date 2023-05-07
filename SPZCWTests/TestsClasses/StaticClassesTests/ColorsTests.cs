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
            var expected = new Color(0, 111, 116);

            //Act
            var actual = Colors.Color1();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestColor2ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(129, 205, 194);

            //Act
            var actual = Colors.Color2();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColor3ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(254, 242, 215);

            //Act
            var actual = Colors.Color3();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColor4ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(243, 140, 118);

            //Act
            var actual = Colors.Color4();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestColor5ReturnsCorrectValue()
        {
            //Arrange
            var expected = new Color(242, 78, 74);

            //Act
            var actual = Colors.Color5();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}