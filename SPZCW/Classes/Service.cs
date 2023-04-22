using Microsoft.Win32;
using SPZCW.Interfaces;
using System;
using System.Management;
using System.ServiceProcess;

namespace SPZCW
{
    public class Service : IService
    {
        private ServiceController _service;
        private string _path { get; set; }
        private string _description { get; set; }

        public Service(ServiceController service)
        {
            _service = service;
            _path = FindPath();
            _description = FindDescription(service);
        }

        public Service(string displayName)
        {
            ServiceController[] services = ServiceController.GetServices();

            foreach (var srvc in services)
            {
                if (srvc.DisplayName == displayName && _service == null)
                {
                    if (_service != null)
                    {
                        //TO DO
                        throw new ArgumentException($"Service \"{displayName}\" found more than once");
                    }
                    _service = srvc;
                    _description = FindDescription(srvc);
                }
            }

            if (_service == null)
            {
                throw new ArgumentException($"Service \"{displayName}\" not found");
            }

            _path = FindPath();
        }

        public void Start()
        {
            _service.Refresh();

            if (_service.Status != ServiceControllerStatus.Running)
            {
                _service.Start();
            }
            else
            {
                throw new Exception($"Service \"{_service.DisplayName}\" is already running");
            }

            Program.Services = Program.GetServices();
        }

        public void Stop()
        {
            _service.Refresh();

            if (_service.Status != ServiceControllerStatus.Stopped)
            {
                _service.Stop();
            }
            else
            {
                throw new Exception($"Service \"{_service.DisplayName}\" is already stopped");
            }

            Program.Services = Program.GetServices();
        }

        public void Restart()
        {
            _service.Refresh();

            if (_service.Status != ServiceControllerStatus.Stopped)
            {
                _service.Stop();
                _service.Start();
            }
            else
            {
                throw new Exception($"Service \"{_service.DisplayName}\" is stopped");
            }

            Program.Services = Program.GetServices();
        }

        public void ChangeDisplayName(string newName)
        {
            using (var serviceKey = Registry.LocalMachine.OpenSubKey($"SYSTEM\\CurrentControlSet\\Services\\{_service.ServiceName}", true))
            {
                if (serviceKey != null)
                {
                    serviceKey.SetValue("DisplayName", newName);
                }
                else
                {
                    throw new Exception($"Service \"{_service.ServiceName}\" was not found in the registry.");
                }
            }

            _service.Refresh();
            Program.Services = Program.GetServices();
        }

        public void ChangeStartType(ServiceStartMode newMode)
        {
            var serviceKey = Registry.LocalMachine.OpenSubKey($"SYSTEM\\CurrentControlSet\\Services\\{_service.ServiceName}", true);
            
            if (serviceKey != null)
            {
                serviceKey.SetValue("Start", (int)newMode);
            }
            else
            {
                throw new Exception($"Service \"{_service.ServiceName}\" was not found in the registry.");
            }
            
            _service.Refresh();
            Program.Services = Program.GetServices();
        }

        public string GetPath()
        {
            return _path;
        }

        public string GetDisplayName()
        {
            return _service.DisplayName;
        }

        public string GetMachineName()
        {
            return _service.MachineName;
        }

        public string GetServiceName()
        {
            return _service.ServiceName;
        }

        public ServiceStartMode GetStartType()
        {
            return _service.StartType;
        }

        public ServiceType GetServiceType()
        {
            return _service.ServiceType;
        }

        public bool CanStop()
        {
            return _service.CanStop;
        }

        public ServiceControllerStatus GetStatus()
        {
            return _service.Status;
        }

        public string GetDescription()
        {
            return _description;
        }

        private static string FindDescription(ServiceController service)
        {
            string description = "";

            ManagementObject serviceObject = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", service.ServiceName)));
            
            if(serviceObject["Description"] != null)
            {
                description = serviceObject["Description"].ToString();
            }
            else
            {
                description = "-";
            }

            return description;
        }

        private string FindPath()
        {
            ManagementObject wmiService = new ManagementObject("Win32_Service.Name='" + _service.ServiceName + "'");
            wmiService.Get();
            if(wmiService["PathName"] == null)
            {
                return "";
            }
            else
            {
                return wmiService["PathName"].ToString();
            }
        }
    }
}
