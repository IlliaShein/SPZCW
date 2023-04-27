using Spectre.Console;
using SPZCW.Classes;
using SPZCW.Classes.StaticClasses;
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
                    ActiveServicesChoiseProcessing();
                    break;
                case "Stopped services":
                    StoppedServicesChoiseProcessing();
                    break;
                case "All services":
                    AllServicesChoiseProcessing();
                    break;
                case "Filter services":
                    FilterChoisePocessing();
                    break;
                case "Process service":
                    ProcessServiceChoiseProcessing();
                    break;
                case "Help":
                    HelpChoiseProcessing();
                    break;
                case "[purple]Exit[/]":
                    Environment.Exit(0);
                    break;
            }
        }

        static private void ActiveServicesChoiseProcessing()
        {
            Console.WriteLine(Messages.ServicesWithStatus(ServiceControllerStatus.Running));
            var activeServices = Tables.GetServicesTableByStatus(ServiceControllerStatus.Running);
            AnsiConsole.Write(activeServices);
        }

        static private void StoppedServicesChoiseProcessing()
        {
            Console.WriteLine(Messages.ServicesWithStatus(ServiceControllerStatus.Stopped));
            var stoppedServices = Tables.GetServicesTableByStatus(ServiceControllerStatus.Stopped);
            AnsiConsole.Write(stoppedServices);
        }

        static private void AllServicesChoiseProcessing()
        {
            Console.WriteLine("All services:");
            var allServices = Tables.GetAllServicesTable();
            AnsiConsole.Write(allServices);
        }

        static private void FilterChoisePocessing()
        {
            var filterMenuChoises = AnsiConsole.Prompt(SpectreConsoleObjects.GetFilterMenu());
            if(filterMenuChoises.Contains("Back"))
            {
                return;
            }

            IFilterSettings filterSettings = new FilterSettings(filterMenuChoises);

            var filteredTable = Tables.GetFilteredServicesTable(filterSettings);
            AnsiConsole.Write(filteredTable);
        }

        static private void ProcessServiceChoiseProcessing()
        {
            IService service;
            try
            {
                service = GetServiceViaInput();
            }
            catch(Exception ex)
            {
                AnsiConsole.Write(SpectreConsoleObjects.Error(ex.Message));
                return;
            }

            Console.WriteLine();
            AnsiConsole.Write(SpectreConsoleObjects.GetServicePathTree(service.Path));
            Console.WriteLine(Messages.ServiceInfo(service));

            ServiceActionsMenuProcessing(service);
        }

        static private IService GetServiceViaInput()
        {
            Console.Write("\nService DisplayName: ");
            string serviceDisplayName = Console.ReadLine();

            IService service = FindService(serviceDisplayName);
            if (service == null)
            {
                throw new Exception($"Service \"{serviceDisplayName}\" not found");
            }

            return service;
        }

        static private IService FindService(string serviceDisplayName)
        {
            for (int i = 0; i < Program.Services.Length; i++)
            {
                if (serviceDisplayName == Program.Services[i].DisplayName)
                {
                    return Program.Services[i];
                }
            }

            return null;
        }

        static private void ServiceActionsMenuProcessing(IService service)
        {
            while (true)
            {
                var actionsMenuChoise = AnsiConsole.Prompt(SpectreConsoleObjects.GetActionsMenu(service));
                if (actionsMenuChoise == "[purple]Back[/]")
                {
                    break;
                }
                ServiceActionsMenuChoiseProcessing(service, actionsMenuChoise);
            }
        }

        static private void ServiceActionsMenuChoiseProcessing(IService service, string actionsMenuChoise)
        {
            try
            {
                switch (actionsMenuChoise)
                {
                    case "Stop":
                        StopChoiseProcessing(service);
                        break;
                    case "Start":
                        StartChoiseProcessing(service);
                        break;
                    case "Restart":
                        RestartChoiseProcessing(service);
                        break;
                    case "Change display name":
                        ChangeDisplayNameChoiseProcessing(service);
                        break;
                    case "Change start type":
                        ChangeStartTypeChoiseProcession(service);
                        break;
                    case "Change description":
                        ChangeDescriptionChoiseProcession(service);
                        break;
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.Write(SpectreConsoleObjects.Error(ex.Message));
            }
        }
        static private void StopChoiseProcessing(IService service)
        {
            try
            {
                service.Stop();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Console.WriteLine($"Service \"{service.DisplayName}\" stopped");
        }

        static private void StartChoiseProcessing(IService service)
        {
            if (service.StartType == ServiceStartMode.Disabled)
            {
                throw new Exception($"Service \"{service.DisplayName}\" can not be started because it has \"Disabled\" start mode." +
                    " Change start mode to start service");
            }

            service.Start();
            Console.WriteLine($"Service \"{service.DisplayName}\" started\n");
        }

        static private void RestartChoiseProcessing(IService service)
        {
            if (service.Status == ServiceControllerStatus.Stopped)
            {
                throw new Exception($"Service \"{service.DisplayName}\" is not running");
            }

            service.Stop();
            service.Start();
            Console.WriteLine($"Service \"{service.DisplayName}\" restarted\n");
        }

        static public void ChangeDisplayNameChoiseProcessing(IService service)
        {
            Console.Write("New name: ");
            string oldName = service.DisplayName;
            string newName = Console.ReadLine();

            if (oldName == newName)
            {
                throw new Exception("It's current service DisplayName");
            }

            try
            {
                service.ChangeDisplayName(newName);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Console.WriteLine($"Service DisplayName changed : {oldName} -> {newName} ");
        }

        static private void ChangeStartTypeChoiseProcession(IService service)
        {
            string ChangeStartTypeMenuChoise = AnsiConsole.Prompt(SpectreConsoleObjects.GetChangeStartTypeMenu());
            string oldStartType = service.StartType.ToString();

            if (ChangeStartTypeMenuChoise == oldStartType)
            {
                throw new Exception("It's current service start type");
            }

            try
            {
                ChangeStartTypeMenuChoiseProcession(service, ChangeStartTypeMenuChoise);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Console.WriteLine($"Start type changed: {oldStartType} -> {ChangeStartTypeMenuChoise}");
        }

        static private void ChangeStartTypeMenuChoiseProcession(IService service , string ChangeStartTypeMenuChoise)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static private void ChangeDescriptionChoiseProcession(IService service)
        {
            Console.Write("New description: ");
            string newDesc = Console.ReadLine();
            string oldDesc = service.Description;

            if (oldDesc == newDesc)
            {
                throw new Exception("It's current service description");
            }

            try
            {
                service.ChangeDescription(newDesc);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Console.WriteLine($"Service DisplayName changed : {oldDesc} -> {newDesc} ");
        }
        static private void HelpChoiseProcessing()
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
    }
}