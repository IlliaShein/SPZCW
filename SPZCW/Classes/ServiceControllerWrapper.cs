using SPZCW.Interfaces;
using System.ServiceProcess;

namespace SPZCW.Classes
{
    public class ServiceControllerWrapper : IServiceController
    {
        private ServiceController _serviceController { get; set; }

        public ServiceControllerWrapper(ServiceController serviceController)
        {
            _serviceController = serviceController;
        }

        public string DisplayName
        {
            get { return _serviceController.DisplayName; }
            set { _serviceController.DisplayName = value; }
        }

        public string MachineName
        {
            get { return _serviceController.MachineName; }
            set { _serviceController.MachineName = value; }
        }

        public string ServiceName
        {
            get { return _serviceController.ServiceName; }
            set { _serviceController.ServiceName = value; }
        }

        public ServiceStartMode StartType
        {
            get { return _serviceController.StartType; }
        }

        public ServiceType ServiceType
        {
            get { return _serviceController.ServiceType; }
        }

        public bool CanStop
        {
            get { return _serviceController.CanStop; }
        }

        public ServiceControllerStatus Status
        {
            get { return _serviceController.Status; }
        }

        public bool Refresh()
        {
            try
            {
                _serviceController.Refresh();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Start()
        {
            _serviceController.Start();
        }
        public void Stop()
        {
            _serviceController.Stop();
        }
    }
}