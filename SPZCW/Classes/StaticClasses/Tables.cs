using Spectre.Console;
using SPZCW.Enumerations;
using SPZCW.Interfaces;
using System.ServiceProcess;

namespace SPZCW.Classes.StaticClasses
{
    public static class Tables
    {
        public static Table GetFilteredServicesTable(IFilterSettings filterSettings)
        {
            Table table = SpectreConsoleObjects.GetServicesTable(true);

            foreach (var service in Program.Services)
            {
                if (filterSettings.Statuses.Contains(service.Status) && filterSettings.StartModes.Contains(service.StartType))
                {
                    if ((service.MachineName == "." && filterSettings.Locations.Contains(ServiceLocation.LocalHost))
                    || (service.MachineName != "." && filterSettings.Locations.Contains(ServiceLocation.AnotherDevice)))
                    {
                        string statusStr = GetStatusStringWithColorNote(service);
                        table.AddRow(service.DisplayName, service.ServiceName, service.MachineName, service.StartType.ToString(), service.ServiceType.ToString(), service.Path, service.Description, statusStr);
                    }
                }
            }

            return table;
        }

        public static Table GetServicesTableByStatus(ServiceControllerStatus status)
        {
            var table = SpectreConsoleObjects.GetServicesTable(false);

            foreach (var service in Program.Services)
            {
                if (service.Status == status)
                {
                    table.AddRow(service.DisplayName, service.ServiceName, service.MachineName, service.StartType.ToString(), service.ServiceType.ToString(), service.Path, service.Description);
                }
            }

            return table;
        }
        public static Table GetAllServicesTable()
        {
            var table = SpectreConsoleObjects.GetServicesTable(true);

            foreach (var service in Program.Services)
            {
                string statusStr = GetStatusStringWithColorNote(service);
                table.AddRow(service.DisplayName, service.ServiceName, service.MachineName, service.StartType.ToString(), service.ServiceType.ToString(), service.Path, service.Description, statusStr);
            }

            return table;
        }

        private static string GetStatusStringWithColorNote(IService service)
        {
            string statusStr;
            string color;

            if (service.Status == ServiceControllerStatus.Stopped)
            {
                color = "red";
            }
            else if (service.Status == ServiceControllerStatus.Running)
            {
                color = "lime";
            }
            else
            {
                color = "yellow";
            }

            statusStr = $"[bold black on {color}]{service.Status}[/]";
            return statusStr;
        }
    }
}
