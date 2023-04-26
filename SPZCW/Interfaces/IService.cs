using System.ServiceProcess;

namespace SPZCW.Interfaces
{
    public  interface IService
    {
        string Path { get; }
        string Description { get; }
        string DisplayName { get; }
        string ServiceName { get; }
        string MachineName { get; }
        bool CanStop { get; }
        ServiceStartMode StartType { get; }
        ServiceType ServiceType { get; }
        ServiceControllerStatus Status { get; }

        void Start();
        void Stop();
        void Restart();
        void ChangeDisplayName(string newName);
        void ChangeStartType(ServiceStartMode newMode);
    }
}