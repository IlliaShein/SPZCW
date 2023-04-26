using Spectre.Console;
using SPZCW.Classes;
using SPZCW.Classes.StaticClasses;
using SPZCW.Enumerations;
using SPZCW.Interfaces;
using SPZCW.Nums;
using System;
using System.ServiceProcess;

namespace SPZCW
{
    static class Menu
    {
        static public void ProcessMainMenu(MainMenuChartType type)
        {
            ProcessTitleAndBar(type);
            var mainMenuChoise = AnsiConsole.Prompt(SpectreConsoleObjects.GetMainMenu());
            MainMenuChoiseProcessing(mainMenuChoise);
        }

        static private void ProcessTitleAndBar(MainMenuChartType type)
        {
            BreakdownChart chart;
            switch (type)
            {
                case MainMenuChartType.ByStatus:
                    chart = SpectreConsoleObjects.GetMainMenuChartByStatus();
                    break;
                case MainMenuChartType.ByStartType:
                    chart = SpectreConsoleObjects.GetMainMenuChartByStartType();
                    break;
                case MainMenuChartType.ByServiceType:
                    chart = SpectreConsoleObjects.GetMainMenuChartByServiceType();
                    break;
                case MainMenuChartType.ByMachineName:
                    chart = SpectreConsoleObjects.GetMainMenuChartByMachineName();
                    break;
                default:
                    throw new ArgumentException($"non-existent type: {type}");
            }
            AnsiConsole.Write(SpectreConsoleObjects.GetTitle());

            AnsiConsole.Write(chart);
            Console.WriteLine("\n");
        }

        static private void MainMenuChoiseProcessing(string mainMenuChoise)
        {
            switch (mainMenuChoise)
            {
                case "Active services":
                    var activeServices = GetActiveServicesTable();
                    Console.WriteLine(Messages.ServicesWithStatus(ServiceControllerStatus.Running));
                    AnsiConsole.Write(activeServices);
                    break;
                case "Stopped services":
                    var stoppedServices = GetStoppedServicesTable();
                    Console.WriteLine(Messages.ServicesWithStatus(ServiceControllerStatus.Stopped));
                    AnsiConsole.Write(stoppedServices);
                    break;
                case "All services":
                    var allServices = GetAllServicesTable();
                    AnsiConsole.Write(allServices);
                    break;
                case "Filter services":
                    ProcessFilterMenu();
                    break;
                case "Process service":
                    ProcessService();
                    break;
                case "Help":
                    ProcessHelpMenu();
                    break;
                case "[purple]Exit[/]":
                    Environment.Exit(0);
                    break;
            }
        }

        static private void ProcessFilterMenu()
        {
            var filterMenuChoises = AnsiConsole.Prompt(SpectreConsoleObjects.GetFilterMenu());
            if(filterMenuChoises.Contains("Back"))
            {
                return;
            }

            IFilterSettings filterSettings = new FilterSettings(filterMenuChoises);

            var filteredTable = GetFilteredServicesTable(filterSettings);
            AnsiConsole.Write(filteredTable);
        }

        static private void ProcessHelpMenu()
        {
            while (true)
            {
                var helpMenuChoise = AnsiConsole.Prompt(SpectreConsoleObjects.GetHelpMenu());

                if (helpMenuChoise == "[purple]Back[/]")
                {
                    break;
                }
                helpMenuChoiseProcessing(helpMenuChoise);
            }
        }

        static private void helpMenuChoiseProcessing(string helpMenuChoise)
        {
            switch (helpMenuChoise)
            {
                case "Program description":
                    AnsiConsole.Write(new Markup(Messages.ServiceDescriptionHelp()));
                    break;
                case "Service names":
                    AnsiConsole.Write(new Markup(Messages.ServiceNamesHelp()));
                    break;
                case "Service start types":
                    AnsiConsole.Write(new Markup(Messages.ServiceStartTypesHelp()));
                    break;
                case "Service Status":
                    AnsiConsole.Write(new Markup(Messages.ServiceStatusHelp()));
                    break;
                case "Service types":
                    AnsiConsole.Write(new Markup(Messages.ServiceTypesHelp()));
                    break;
            }
        }
        static private void ProcessService()
        {
            Console.Write("\nService DisplayName: ");
            string serviceDisplayName = Console.ReadLine();

            IService service = FindService(serviceDisplayName);
            if(service == null)
            {
                AnsiConsole.WriteLine($"\nService \"{serviceDisplayName}\" not found");
                return;
            }

            Console.WriteLine();
            AnsiConsole.Write(SpectreConsoleObjects.GetServicePathTree(service.Path));
            Console.WriteLine(Messages.ServiceInfo(service));

            ActionsMenuProcessing(service);
        }

        static private IService FindService(string serviceDisplayName)
        {
            for (int i = 0; i < Program.Services.Length; i++)
            {
                if (serviceDisplayName == Program.Services[i].GetDisplayName())
                {
                    return Program.Services[i];
                }
            }

            return null;
        }

        static private void ActionsMenuProcessing(IService service)
        {
            while(true)
            {
                var actionsMenuChoise = AnsiConsole.Prompt(SpectreConsoleObjects.GetActionsMenu(service));
                if(actionsMenuChoise == "[purple]Back[/]")
                {
                    break;
                }
                ActionsMenuChoiseProcessing(service, actionsMenuChoise);
            }
        }
        static private void ActionsMenuChoiseProcessing(IService service , string actionsMenuChoise)
        {
            switch (actionsMenuChoise)
            {
                case "Stop":

                    service.Stop();
                    Console.WriteLine($"Service \"{service.GetDisplayName()}\" stopped");

                    break;
                case "Start":

                    if (service.GetStartType() == ServiceStartMode.Disabled)
                    {
                        Console.WriteLine($"Service \"{service.GetDisplayName()}\" can not be started because it has \"Disabled\" start mode." +
                            " Change start mode to start service");
                    }

                    service.Start();
                    Console.WriteLine($"Service \"{service.GetDisplayName()}\" started\n");

                    break;
                case "Restart":

                    if (service.GetStatus() == ServiceControllerStatus.Stopped)
                    {
                        Console.WriteLine($"Service \"{service.GetDisplayName()}\" is not running\n");
                    }

                    service.Stop();
                    service.Start();
                    Console.WriteLine($"Service \"{service.GetDisplayName()}\" restarted\n");

                    break;
                case "Change display name":

                    Console.Write("New name: ");
                    string oldName = service.GetDisplayName();
                    string newName = Console.ReadLine();

                    if (oldName == newName)
                    {
                        Console.WriteLine("It's current service DisplayName\n");
                        break;
                    }

                    service.ChangeDisplayName(newName);
                    Console.WriteLine($"Service DisplayName changed : {oldName} -> {newName} ");

                    break;
                case "Change start type":

                    string ChangeStartTypeMenuChoise = AnsiConsole.Prompt(SpectreConsoleObjects.GetChangeStartTypeMenu());
                    string oldStartType = service.GetStartType().ToString();

                    if (ChangeStartTypeMenuChoise == service.GetStartType().ToString())
                    {
                        Console.WriteLine("It's current service start type");
                        break;
                    }

                    switch (ChangeStartTypeMenuChoise)
                    {
                        case "Manual":
                            service.ChangeStartType(ServiceStartMode.Manual);
                            break;
                        case "Automatic":
                            service.ChangeStartType(ServiceStartMode.Automatic);
                            break;
                        case "Disabled":
                            service.ChangeStartType(ServiceStartMode.Disabled);
                            break;
                        case "Boot":
                            service.ChangeStartType(ServiceStartMode.Boot);
                            break;
                        case "System":
                            service.ChangeStartType(ServiceStartMode.System);
                            break;
                        case "[purple]Back[/]":
                            return;
                    }

                    Console.WriteLine($"Start type changed: {oldStartType} -> {ChangeStartTypeMenuChoise}");

                    break;
            }
        }

        static private Table GetAllServicesTable()
        {
            var table = SpectreConsoleObjects.GetServicesTable(true);
           
            foreach (var service in Program.Services)
            {
                string statusStr = GetStatusStringWithColorNote(service);
                table.AddRow(service.GetDisplayName(), service.GetServiceName(), service.GetMachineName(), service.GetStartType().ToString(), service.GetServiceType().ToString(), service.Path, service.Description, statusStr);
            }

            return table;
        }

        static private Table GetActiveServicesTable()
        {
            return ShowServicesByStatus(ServiceControllerStatus.Running);
        }

        static private Table GetStoppedServicesTable()
        {
            return ShowServicesByStatus(ServiceControllerStatus.Stopped);
        }

        static private Table GetFilteredServicesTable(IFilterSettings filterSettings)
        {
            Table table = SpectreConsoleObjects.GetServicesTable(true);

            foreach (var service in Program.Services)
            {
                if(filterSettings.Statuses.Contains(service.GetStatus()) && filterSettings.StartModes.Contains(service.GetStartType()))
                {
                    if((service.GetMachineName() == "." && filterSettings.Locations.Contains(ServiceLocation.LocalHost))
                    || (service.GetMachineName() != "." && filterSettings.Locations.Contains(ServiceLocation.AnotherDevice)))
                    {
                        string statusStr = GetStatusStringWithColorNote(service);
                        table.AddRow(service.GetDisplayName(), service.GetServiceName(), service.GetMachineName(), service.GetStartType().ToString(), service.GetServiceType().ToString(), service.Path, service.Description, statusStr);
                    }
                }
            }
            return table;
        }

        static private string GetStatusStringWithColorNote(IService service)
        {
            string statusStr;

            if (service.GetStatus() == ServiceControllerStatus.Stopped)
            {
                statusStr = $"[bold black on red]{service.GetStatus()}[/]";
            }
            else if (service.GetStatus() == ServiceControllerStatus.Running)
            {
                statusStr = $"[bold black on lime]{service.GetStatus()}[/]";
            }
            else
            {
                statusStr = $"[bold black on yellow]{service.GetStatus()}[/]";
            }

            return statusStr;
        }
        static private Table ShowServicesByStatus(ServiceControllerStatus status)
        {
            var table = SpectreConsoleObjects.GetServicesTable(false);

            foreach (var service in Program.Services)
            {
                if (service.GetStatus() == status)
                {
                    table.AddRow(service.GetDisplayName(), service.GetServiceName() , service.GetMachineName(), service.GetStartType().ToString(), service.GetServiceType().ToString(), service.Path, service.Description);
                }
            }

            return table;
        }
    }
}