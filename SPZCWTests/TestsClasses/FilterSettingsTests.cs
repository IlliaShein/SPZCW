using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPZCW.Classes;
using SPZCW.Enumerations;
using System.Collections.Generic;
using System.ServiceProcess;

namespace SPZCWTests
{
    [TestClass]
    public class FilterSettingsTests
    {
        [TestMethod]
        public void TestConstructorCreatesCorrectSizesOfLists()
        {
            //Arrange
            List<string> choices = new List<string>();
            choices.Add("Running");
            choices.Add("Other");

            choices.Add("Automatic");

            choices.Add("Another device");
            choices.Add("Localhost");

            //Act
            FilterSettings filterSettings = new FilterSettings(choices);

            //Assert
            Assert.AreEqual(6, filterSettings.Statuses.Count);
            Assert.AreEqual(1, filterSettings.StartModes.Count);
            Assert.AreEqual(2, filterSettings.Locations.Count);
        }

        [TestMethod]
        public void TestConstructorCreatesCorrectLists()
        {
            //Arrange
            List<string> choices = CreateListWithChoices();
            //Act
            FilterSettings filterSettings = new FilterSettings(choices);
            bool correctFilling = CheckCorrectFilterSettingsFilling(filterSettings);

            //Assert
            Assert.IsTrue(correctFilling);
        }

        private List<string>  CreateListWithChoices()
        {
            List<string> choices = new List<string>();
            choices.Add("Running");
            choices.Add("Stopped");
            choices.Add("Other");

            choices.Add("Automatic");
            choices.Add("Manual");
            choices.Add("Disabled");
            choices.Add("System");
            choices.Add("Boot");

            choices.Add("Another device");
            choices.Add("Localhost");

            return choices;
        }

        private bool CheckCorrectFilterSettingsFilling(FilterSettings filterSettings)
        {
            if (filterSettings.Locations.Contains(ServiceLocation.AnotherDevice)
                && filterSettings.Locations.Contains(ServiceLocation.LocalHost)
                && filterSettings.StartModes.Contains(ServiceStartMode.Automatic)
                && filterSettings.StartModes.Contains(ServiceStartMode.Disabled)
                && filterSettings.StartModes.Contains(ServiceStartMode.Boot)
                && filterSettings.StartModes.Contains(ServiceStartMode.Manual)
                && filterSettings.StartModes.Contains(ServiceStartMode.System)
                && filterSettings.Statuses.Contains(ServiceControllerStatus.Running)
                && filterSettings.Statuses.Contains(ServiceControllerStatus.Stopped)
                && filterSettings.Statuses.Contains(ServiceControllerStatus.ContinuePending)
                && filterSettings.Statuses.Contains(ServiceControllerStatus.Paused)
                && filterSettings.Statuses.Contains(ServiceControllerStatus.StartPending)
                && filterSettings.Statuses.Contains(ServiceControllerStatus.StartPending)
                && filterSettings.Statuses.Contains(ServiceControllerStatus.StopPending))
            {
                return true;
            }

            return false;
        }
    }
}
