using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SPZCW.Classes.StaticClasses;
using SPZCW.Interfaces;

namespace SPZCWTests.TestsClasses
{
    [TestClass]
    public class MenuesTests
    {
        [TestMethod]
        public void TestGetMainMenuReturnsNotNull()
        {
            Assert.IsNotNull(Menues.GetMainMenu());
        }

        [TestMethod]
        public void TestGetChangeStartTypeMenuReturnsNotNull()
        {
            Assert.IsNotNull(Menues.GetChangeStartTypeMenu());
        }

        [TestMethod]
        public void TestGetFilterMenuReturnsNotNull()
        {
            Assert.IsNotNull(Menues.GetFilterMenu());
        }

        [TestMethod]
        public void TestGetActionsMenuReturnsNotNull()
        {
            //Arange
            var serviceControllerWrapperMock = new Mock<IService>();

            //Act , Assert
            Assert.IsNotNull(Menues.GetActionsMenu(serviceControllerWrapperMock.Object));
        }

        [TestMethod]
        public void TestGetHelpMenuReturnsNotNull()
        {
            Assert.IsNotNull(Menues.GetHelpMenu());
        }
    }
}
