using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPZCW.Classes.StaticClasses.SpectreConsoleObjects;

namespace SPZCWTests.TestsClasses.StaticClassesTests.SpectreConsoleObjectsTests
{
    [TestClass]
    public class PathTreeTests
    {
        [TestMethod]
        public void TestGetServicePathTreeReturnsNotNull()
        {
            Assert.IsNotNull(PathTree.GetServicePathTree("path"));
        }
    }
}
