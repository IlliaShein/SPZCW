using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPZCW.Classes.StaticClasses;

namespace SPZCWTests.TestsClasses.StaticClassesTests.SpectreConsoleObjectsTests
{
    [TestClass]
    public class TablesTests
    {
        [TestMethod]
        public void TestGetServicesTableReturnsNotNull()
        {
            Assert.IsNotNull(Tables.GetServicesTable(true));
        }
    }
}
