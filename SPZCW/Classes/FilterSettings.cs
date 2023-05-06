using SPZCW.Enumerations;
using SPZCW.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace SPZCW.Classes
{
    public class FilterSettings : IFilterSettings
    {
        public List<ServiceControllerStatus> Statuses { get; }
        public List<ServiceStartMode> StartModes { get; }
        public List<ServiceLocation> Locations { get; }

        public FilterSettings(List<string> choices)
        {
            Statuses = new List<ServiceControllerStatus>();
            StartModes = new List<ServiceStartMode>();
            Locations = new List<ServiceLocation>();

            foreach (string choise in choices)
            {
                AddChoiseAsSetting(choise);
            }
        }

        private void AddChoiseAsSetting(string choise)
        {
            if (choise == "Running") // Checking if choise is status 
            {
                Statuses.Add(ServiceControllerStatus.Running);
            }
            else if (choise == "Stopped")
            {
                Statuses.Add(ServiceControllerStatus.Stopped);
            }
            else if (choise == "Other")
            {
                Statuses.Add(ServiceControllerStatus.Paused);
                Statuses.Add(ServiceControllerStatus.ContinuePending);
                Statuses.Add(ServiceControllerStatus.PausePending);
                Statuses.Add(ServiceControllerStatus.StartPending);
                Statuses.Add(ServiceControllerStatus.StopPending);
            }
            else if (choise == "Manual") // Checking if choise is StartMode 
            {
                StartModes.Add(ServiceStartMode.Manual);
            }
            else if (choise == "Automatic")
            {
                StartModes.Add(ServiceStartMode.Automatic);
            }
            else if (choise == "Disabled")
            {
                StartModes.Add(ServiceStartMode.Disabled);
            }
            else if (choise == "Boot")
            {
                StartModes.Add(ServiceStartMode.Boot);
            }
            else if (choise == "System")
            {
                StartModes.Add(ServiceStartMode.System);
            }
            else if (choise == "Localhost") // Checking if choise is Location 
            {
                Locations.Add(ServiceLocation.LocalHost);
            }
            else if (choise == "Another device")
            {
                Locations.Add(ServiceLocation.AnotherDevice);
            }
            else
            {
                throw new Exception($"Unknown setting: {choise}");
            }
        }
    }
}
