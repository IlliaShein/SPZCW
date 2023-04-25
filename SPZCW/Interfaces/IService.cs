using System.ServiceProcess;

namespace SPZCW.Interfaces
{
    public  interface IService
    {
        string Path { get; }
        string Description { get; }

        void Start();
        void Stop();
        void Restart();
        void ChangeDisplayName(string newName);
        void ChangeStartType(ServiceStartMode newMode);

        string GetDisplayName();
        string GetMachineName();
        string GetServiceName();
        ServiceStartMode GetStartType();
        ServiceType GetServiceType();
        ServiceControllerStatus GetStatus();
        bool CanStop();
    }
}