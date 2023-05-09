using Spectre.Console;
using SPZCW.Classes;
using SPZCW.Classes.StaticClasses;
using SPZCW.Classes.StaticClasses.SpectreConsoleObjects;
using SPZCW.Interfaces;
using SPZCW.Nums;
using System;
using System.ServiceProcess;

namespace SPZCW
{
    static class Menu
    {
        public static void ProcessMainMenu(MainMenuChartType type)
        {
            ProcessTitleAndBar(type);
            var mainMenuChoise = AnsiConsole.Prompt(Menues.GetMainMenu());
            MainMenuChoiseProcessing(mainMenuChoise);
        }

        private static void ProcessTitleAndBar(MainMenuChartType type)
        {
            BreakdownChart chart;
            switch (type)
            {
                case MainMenuChartType.ByStatus:
                    chart = MainMenuChart.GetMainMenuChartByStatus();
                    break;
                case MainMenuChartType.ByStartType:
                    chart = MainMenuChart.GetMainMenuChartByStartType();
                    break;
                case MainMenuChartType.ByServiceType:
                    chart = MainMenuChart.GetMainMenuChartByServiceType();
                    break;
                case MainMenuChartType.ByMachineName:
                    chart = MainMenuChart.GetMainMenuChartByMachineName();
                    break;
                default:
                    throw new ArgumentException($"non-existent type: {type}");
            }
            AnsiConsole.Write(MainTitle.Title);

            AnsiConsole.Write(chart);
            Console.WriteLine("\n");
        }

        private static void MainMenuChoiseProcessing(string mainMenuChoise)
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
                case "[red1]Exit[/]":
                    Environment.Exit(0);
                    break;
            }
        }

        private static void ActiveServicesChoiseProcessing()
        {
            Console.WriteLine(Messages.ServicesWithStatus(ServiceControllerStatus.Running));
            var activeServices = Tables.GetServicesTableByStatus(ServiceControllerStatus.Running);
            AnsiConsole.Write(activeServices);
        }

        private static void StoppedServicesChoiseProcessing()
        {
            Console.WriteLine(Messages.ServicesWithStatus(ServiceControllerStatus.Stopped));
            var stoppedServices = Tables.GetServicesTableByStatus(ServiceControllerStatus.Stopped);
            AnsiConsole.Write(stoppedServices);
        }

        private static void AllServicesChoiseProcessing()
        {
            Console.WriteLine("All services:");
            var allServices = Tables.GetAllServicesTable();
            AnsiConsole.Write(allServices);
        }

        private static void FilterChoisePocessing()
        {
            var filterMenuChoises = AnsiConsole.Prompt(Menues.GetFilterMenu());
            if(filterMenuChoises.Contains("Back"))
            {
                return;
            }

            IFilterSettings filterSettings = new FilterSettings(filterMenuChoises);

            var filteredTable = Tables.GetFilteredServicesTable(filterSettings);
            AnsiConsole.Write(filteredTable);
        }

        private static void ProcessServiceChoiseProcessing()
        {
            IService service;
            try
            {
                service = GetServiceViaInput();
            }
            catch(Exception ex)
            {
                AnsiConsole.Write(Messages.Error(ex.Message));
                return;
            }

            ServiceActionsMenuProcessing(service);
        }

        private static IService GetServiceViaInput()
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

        private static IService FindService(string serviceDisplayName)
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

        private static void ServiceActionsMenuProcessing(IService service)
        {
            while (true)
            {
                Console.WriteLine();
                AnsiConsole.Write(PathTree.GetServicePathTree(service.Path));
                Console.WriteLine(Messages.ServiceInfo(service));

                var actionsMenuChoise = AnsiConsole.Prompt(Menues.GetActionsMenu(service));
                if (actionsMenuChoise == "[red1]Back[/]")
                {
                    break;
                }
                ServiceActionsMenuChoiseProcessing(ref service, actionsMenuChoise);

                if(actionsMenuChoise != "Change display name")
                {
                    service = FindService(service.DisplayName);
                }
            }
        }

        private static void ServiceActionsMenuChoiseProcessing(ref IService service, string actionsMenuChoise)
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
                        ChangeDisplayNameChoiseProcessing(ref service);
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
                AnsiConsole.Write(Messages.Error(ex.Message));
            }
        }
        private static void StopChoiseProcessing(IService service)
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

        private static void StartChoiseProcessing(IService service)
        {
            if (service.StartType == ServiceStartMode.Disabled)
            {
                throw new Exception($"Service \"{service.DisplayName}\" can not be started because it has \"Disabled\" start mode." +
                    " Change start mode to start service");
            }

            service.Start();
            Console.WriteLine($"Service \"{service.DisplayName}\" started\n");
        }

        private static void RestartChoiseProcessing(IService service)
        {
            if (service.Status == ServiceControllerStatus.Stopped)
            {
                throw new Exception($"Service \"{service.DisplayName}\" is not running");
            }

            service.Stop();
            service.Start();
            Console.WriteLine($"Service \"{service.DisplayName}\" restarted\n");
        }

        public static void ChangeDisplayNameChoiseProcessing(ref IService service)
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

            service = FindService(newName);
            Console.WriteLine($"Service DisplayName changed : {oldName} -> {newName} ");
        }

        private static void ChangeStartTypeChoiseProcession(IService service)
        {
            string ChangeStartTypeMenuChoise = AnsiConsole.Prompt(Menues.GetChangeStartTypeMenu());
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

        private static void ChangeStartTypeMenuChoiseProcession(IService service , string ChangeStartTypeMenuChoise)
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
                    case "[red1]Back[/]":
                        return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void ChangeDescriptionChoiseProcession(IService service)
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
        private static void HelpChoiseProcessing()
        {
            while (true)
            {
                var helpMenuChoise = AnsiConsole.Prompt(Menues.GetHelpMenu());

                if (helpMenuChoise == "[red1]Back[/]")
                {
                    break;
                }
                HelpMenuChoiseProcessing(helpMenuChoise);
            }
        }

        private static void HelpMenuChoiseProcessing(string helpMenuChoise)
        {
            switch (helpMenuChoise)
            {
                case "Program description":
                    AnsiConsole.Write(HelpMenuText.ProgramDescription);
                    break;
                case "Service names":
                    AnsiConsole.Write(HelpMenuText.ServiceNames);
                    break;
                case "Service start types":
                    AnsiConsole.Write(HelpMenuText.ServiceStartTypes);
                    break;
                case "Service Status":
                    AnsiConsole.Write(HelpMenuText.ServiceStatus);
                    break;
                case "Service types":
                    AnsiConsole.Write(HelpMenuText.ServiceTypes);
                    break;
            }
        }
    }
}