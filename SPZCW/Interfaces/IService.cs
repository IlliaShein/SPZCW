using System.ServiceProcess;

namespace SPZCW.Interfaces
{
    public  interface IService
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
        string GetDescription();
        ServiceStartMode GetStartType();
        ServiceType GetServiceType();
        ServiceControllerStatus GetStatus();
        bool CanStop();
    }
}
