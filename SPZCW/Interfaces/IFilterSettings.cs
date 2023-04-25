using System.ServiceProcess;
using SPZCW.Enumerations;
using System.Collections.Generic;

namespace SPZCW.Interfaces
{
    interface IFilterSettings
    {
        List<ServiceControllerStatus> Statuses {get;}
        List<ServiceStartMode> StartModes { get;}
        List<ServiceLocation> Locations { get; }
    }
}
