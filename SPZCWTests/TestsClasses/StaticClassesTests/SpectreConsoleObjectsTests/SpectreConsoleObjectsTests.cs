using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPZCW;

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
        public void TestGetServicePathTreeReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetServicePathTree("NotNull"));
        }
    }
}
