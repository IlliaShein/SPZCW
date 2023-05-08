using Spectre.Console;
using SPZCW.Enumerations;
using SPZCW.Interfaces;
using System.ServiceProcess;

namespace SPZCW.Classes.StaticClasses
{
    public static class Tables
    {
        public static Table GetAllServicesTable()
        {
            var table = GetServicesTable(true);

            foreach (var service in Program.Services)
            {
                AddServiceToTableWithStatus(table, service);
            }

            return table;
        }

        public static Table GetServicesTableByStatus(ServiceControllerStatus status)
        {
            var table = GetServicesTable(false);

            foreach (var service in Program.Services)
            {
                if (service.Status == status)
                {
                    AddServiceToTable(table, service);
                }
            }

            return table;
        }

        public static Table GetFilteredServicesTable(IFilterSettings filterSettings)
        {
            Table table = GetServicesTable(true);

            foreach (var service in Program.Services)
            {
                if (filterSettings.Statuses.Contains(service.Status) && filterSettings.StartModes.Contains(service.StartType))
                {
                    if ((service.MachineName == "." && filterSettings.Locations.Contains(ServiceLocation.LocalHost))
                    || (service.MachineName != "." && filterSettings.Locations.Contains(ServiceLocation.AnotherDevice)))
                    {
                        AddServiceToTableWithStatus(table,service);
                    }
                }
            }

            return table;
        }

        private static void AddServiceToTable(Table table, IService service)
        {
            table.AddRow(service.DisplayName, service.ServiceName, service.MachineName, service.StartType.ToString(), service.ServiceType.ToString(), service.Path, service.Description);
        }

        private static void AddServiceToTableWithStatus(Table table , IService service)
        {
            string statusStr = GetStatusStringWithColorNote(service);
            table.AddRow(service.DisplayName, service.ServiceName, service.MachineName, service.StartType.ToString(), service.ServiceType.ToString(), service.Path, service.Description, statusStr);
        }

        private static Table GetServicesTable(bool addStatusColumn)
        {
            Table table = new Table();

            table.AddColumn("DisplayName");
            table.AddColumn(new TableColumn("ServiceName"));
            table.AddColumn(new TableColumn("MachineName"));
            table.AddColumn(new TableColumn("Start type"));
            table.AddColumn(new TableColumn("ServiceType"));
            table.AddColumn(new TableColumn("Path"));
            table.AddColumn(new TableColumn("Description"));
            if (addStatusColumn)
            {
                table.AddColumn(new TableColumn("Status").Centered());
            }

            return table;
        }

        private static string GetStatusStringWithColorNote(IService service)
        {
            string statusStr;
            string color;

            if (service.Status == ServiceControllerStatus.Stopped)
            {
                color = "red1";
            }
            else if (service.Status == ServiceControllerStatus.Running)
            {
                color = "mediumturquoise";
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
