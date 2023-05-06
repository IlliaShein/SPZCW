using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPZCW.Classes.StaticClasses;

namespace SPZCWTests.TestsClasses
{
    [TestClass]
    public class MainMenuChartTests
    {
        [TestMethod]
        public void TestGetMainMenuChartByStatusReturnsNotNull()
        {
            Assert.IsNotNull(MainMenuChart.GetMainMenuChartByStatus());
        }

        [TestMethod]
        public void TestGetMainMenuChartByStartTypeReturnsNotNull()
        {
            Assert.IsNotNull(MainMenuChart.GetMainMenuChartByStartType());
        }

        [TestMethod]
        public void TestGetMainMenuChartByServiceTypeReturnsNotNull()
        {
            Assert.IsNotNull(MainMenuChart.GetMainMenuChartByServiceType());
        }

        [TestMethod]
        public void TestGetMainMenuChartByMachineNameReturnsNotNull()
        {
            Assert.IsNotNull(MainMenuChart.GetMainMenuChartByMachineName());
        }
    }
}
