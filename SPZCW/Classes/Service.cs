using Microsoft.Win32;
using SPZCW.Interfaces;
using System;
using System.Management;
using System.ServiceProcess;

namespace SPZCW
{
    public class Service : IService
    {
        public string Path { get;}
        public string Description { get; private set; }
        public string DisplayName { get; private set; }
        public string ServiceName { get; }
        public string MachineName { get; }
        public bool CanStop { get; }
        public ServiceStartMode StartType { get; private set; }
        public ServiceType ServiceType { get; }
        public ServiceControllerStatus Status { get; private set; }
        private IServiceController _service { get; set; }

        public Service(IServiceController service)
        {
            _service = service;
            Path = FindPath();
            Description = FindDescription(service);

            DisplayName = service.DisplayName;
            ServiceName = service.ServiceName;
            MachineName = service.MachineName;

            CanStop = service.CanStop;

            StartType = service.StartType;
            ServiceType = service.ServiceType;
            Status = service.Status;
        }

        private string FindPath()
        {
            ManagementObject wmiService = new ManagementObject("Win32_Service.Name='" + _service.ServiceName + "'");

            try
            {
                if (wmiService["PathName"] == null)
                {
                    return "";
                }
                wmiService.Get();
                return wmiService["PathName"].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static string FindDescription(IServiceController service)
        {
            string description = "";
            ManagementObject serviceObject = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", service.ServiceName)));

            try
            {
                if (serviceObject["Description"] == null)
                {
                    description = "-";
                    return description;
                }
                description = serviceObject["Description"].ToString();
                return description;
            }
            catch (Exception)
            {
                description = "-";
                return description;
            }
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

        public void ChangeDescription(string newDescription)
        {
            using (var serviceKey = Registry.LocalMachine.OpenSubKey($"SYSTEM\\CurrentControlSet\\Services\\{_service.ServiceName}", true))
            {
                if (serviceKey != null)
                {
                    serviceKey.SetValue("Description", newDescription);
                }
                else
                {
                    throw new Exception($"Service \"{_service.ServiceName}\" was not found in the registry.");
                }
            }

            _service.Refresh();
            Program.Services = Program.GetServices();

            Description = FindDescription(_service);
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
    }
}