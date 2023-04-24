using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SPZCW;
using SPZCW.Interfaces;

namespace SPZCWTests
{
    [TestClass]
    public class SpectreConsoleObjectsTests
    {
        [TestMethod]
        public void TestGetTitleReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetTitle());
        }

        [TestMethod]
        public void TestGetMainMenuReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetMainMenu());
        }

        [TestMethod]
        public void TestGetChangeStartTypeMenuReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetChangeStartTypeMenu());
        }

        [TestMethod]
        public void TestGetFilterMenuReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetFilterMenu());
        }

        [TestMethod]
        public void TestGetServicePathTreeReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetServicePathTree("NotNull"));
        }

        [TestMethod]
        public void TestGetMainMenuChartByStatusReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetMainMenuChartByStatus());
        }

        [TestMethod]
        public void TestGetMainMenuChartByStartTypeReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetMainMenuChartByStartType());
        }

        [TestMethod]
        public void TestGetMainMenuChartByServiceTypeReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetMainMenuChartByServiceType());
        }

        [TestMethod]
        public void TestGetMainMenuChartByMachineNameReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetMainMenuChartByMachineName());
        }

        [TestMethod]
        public void TestGetServicesTableReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetServicesTable(true));
        }

        [TestMethod]
        public void TestGetActionsMenuReturnsNotNull()
        {
            //Arange
            var serviceControllerWrapperMock = new Mock<IService>();

            //Act , Assert
            Assert.IsNotNull(SpectreConsoleObjects.GetActionsMenu(serviceControllerWrapperMock.Object));
        }

        [TestMethod]
        public void TestGetHelpMenuReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetHelpMenu());
        }
    }
}
