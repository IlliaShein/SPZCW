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
    }
}
