using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPZCW.Classes;
using SPZCW.Classes.StaticClasses;
using System.Collections.Generic;
using System.ServiceProcess;

namespace SPZCWTests.TestsClasses.StaticClassesTests.SpectreConsoleObjectsTests
{
    [TestClass]
    public class TablesTests
    {
        [TestMethod]
        public void TestGetServicesTableByStatusReturnsNotNull()
        {
            Assert.IsNotNull(Tables.GetServicesTableByStatus(ServiceControllerStatus.Running));
            Assert.IsNotNull(Tables.GetServicesTableByStatus(ServiceControllerStatus.Stopped));
            Assert.IsNotNull(Tables.GetServicesTableByStatus(ServiceControllerStatus.Paused));
            Assert.IsNotNull(Tables.GetServicesTableByStatus(ServiceControllerStatus.StartPending));
            Assert.IsNotNull(Tables.GetServicesTableByStatus(ServiceControllerStatus.StopPending));
            Assert.IsNotNull(Tables.GetServicesTableByStatus(ServiceControllerStatus.ContinuePending));
            Assert.IsNotNull(Tables.GetServicesTableByStatus(ServiceControllerStatus.PausePending));
        }

        [TestMethod]
        public void TestGetAllServicesTableReturnsNotNull()
        {
            Assert.IsNotNull(Tables.GetAllServicesTable());
        }

        [TestMethod]
        public void TestGetFilteredServicesTableReturnsNotNull()
        {
            //Arrange
            var filterSettings = new FilterSettings(new List<string>());

            //Act, Assert
            Assert.IsNotNull(Tables.GetFilteredServicesTable(filterSettings));
        }
    }
}
