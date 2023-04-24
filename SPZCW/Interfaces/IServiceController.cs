using System.ServiceProcess;

namespace SPZCW.Interfaces
{
    public interface IServiceController
    {
        string DisplayName { get; set; }
        string MachineName { get; set; }
        string ServiceName { get; set; }
        ServiceStartMode StartType { get; }
        ServiceType ServiceType { get; }
        bool CanStop { get; }
        ServiceControllerStatus Status { get; }

        bool Refresh();
        void Start();
        void Stop();
    }
}