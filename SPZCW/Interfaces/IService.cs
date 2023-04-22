using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SPZCW.Interfaces
{
    interface IService
    {
        void Start();
        void Stop();
        void Restart();
        void ChangeDisplayName(string newName);
        void ChangeStartType(ServiceStartMode newMode);

        string GetPath();
        string GetDisplayName();
        string GetMachineName();
        string GetServiceName();
        ServiceStartMode GetStartType();
        ServiceType GetServiceType();
        ServiceControllerStatus GetStatus();
        bool CanStop();
    }
}
