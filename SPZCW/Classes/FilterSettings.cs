using SPZCW.Enumerations;
using SPZCW.Interfaces;
using System.Collections.Generic;
using System.ServiceProcess;

namespace SPZCW.Classes
{
    class FilterSettings : IFilterSettings
    {
        public List<ServiceControllerStatus> Statuses { get; }
        public List<ServiceStartMode> StartModes { get; }
        public List<ServiceLocation> Locations { get; }

        public FilterSettings(List<ServiceControllerStatus> statuses, List<ServiceStartMode> startModes , List<ServiceLocation> locations)
        {
            Statuses = statuses;
            StartModes = startModes;
            Locations = locations;
        }
    }
}
