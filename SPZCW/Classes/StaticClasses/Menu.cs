using Spectre.Console;
using SPZCW.Classes.StaticClasses;
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
                case MainMenuChartType.BYSTATUS:
                    chart = SpectreConsoleObjects.GetMainMenuChartByStatus();
                    break;
                case MainMenuChartType.BYSTARTTYPE:
                    chart = SpectreConsoleObjects.GetMainMenuChartByStartType();
                    break;
                case MainMenuChartType.BYSERVICETYPE:
                    chart = SpectreConsoleObjects.GetMainMenuChartByServiceType();
                    break;
                case MainMenuChartType.BYMACHINENAME:
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

                    var fruits = AnsiConsole.Prompt(
                        new MultiSelectionPrompt<string>()
                            .NotRequired() // Not required to have a favorite fruit
                            .PageSize(15)
                            .InstructionsText(
                                "[grey](Press [blue]<space>[/] to toggle a fruit, " +
                                "[green]<enter>[/] to accept)[/]")
                            .AddChoiceGroup<string>("Status", new string [] {
                            "Running" , "Stopped", "Other"})
                            .AddChoiceGroup("Start type" , new string[] {
                                "Manual", "Automatic", "Disabled", "Boot", "System"})
                            .AddChoiceGroup("MachineName" , new string[] {
                                "." , "other"}));

                    break;
                case "Process service":

                    ProcessService();

                    break;
                case "[red]Exit[/]":

                    Environment.Exit(0);

                    break;
            }
        }
        static private void ProcessService()
        {
            Console.Write("\nService DisplayName: ");
            string serviceDisplayName = Console.ReadLine();

            Service service = FindService(serviceDisplayName);
            if(service == null)
            {
                AnsiConsole.WriteLine($"\nService \"{serviceDisplayName}\" not found");
                return;
            }

            Console.WriteLine();
            AnsiConsole.Write(SpectreConsoleObjects.GetServicePathTree(service.GetPath()));
            Console.WriteLine(Messages.ServiceInfo(service));

            ActionsMenuProcessing(service);
        }

        static private Service FindService(string serviceDisplayName)
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

        static private void ActionsMenuProcessing(Service service)
        {
            while(true)
            {
                var actionsMenuChoise = AnsiConsole.Prompt(SpectreConsoleObjects.GetActionsMenuMenu(service));
                if(actionsMenuChoise == "[red]Back[/]")
                {
                    break;
                }
                ActionsMenuChoiseProcessing(service, actionsMenuChoise);
            }
        }
        static private void ActionsMenuChoiseProcessing(Service service , string actionsMenuChoise)
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
                        case "[red]Back[/]":
                            return;
                    }

                    Console.WriteLine($"Start type changed: {oldStartType} -> {ChangeStartTypeMenuChoise}");

                    break;
            }
        }

        static private Table GetAllServicesTable()
        {
            ServiceController[] services = ServiceController.GetServices();
            var table = SpectreConsoleObjects.GetServicesTable(true);
           
            foreach (var service in Program.Services)
            {
                if (service.GetStatus() == ServiceControllerStatus.Stopped)
                {
                    table.AddRow(service.GetDisplayName(), service.GetServiceName(), service.GetMachineName(), service.GetStartType().ToString(), service.GetServiceType().ToString(), service.GetPath(), $"[invert red]{service.GetStatus()}[/]");
                }
                else if (service.GetStatus() == ServiceControllerStatus.Running)
                {
                    table.AddRow(service.GetDisplayName(), service.GetServiceName(), service.GetMachineName(), service.GetStartType().ToString(), service.GetServiceType().ToString(), service.GetPath(), $"[invert lime]{service.GetStatus()}[/]");
                }
                else
                {
                    table.AddRow(service.GetDisplayName(), service.GetServiceName(), service.GetMachineName(),  service.GetStartType().ToString(), service.GetServiceType().ToString(), service.GetPath(), $"[invert yellow]{service.GetStatus()}[/]");
                }
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

        static private Table ShowServicesByStatus(ServiceControllerStatus status)
        {
            var table = SpectreConsoleObjects.GetServicesTable(false);

            foreach (var service in Program.Services)
            {
                if (service.GetStatus() == status)
                {
                    table.AddRow(service.GetDisplayName(), service.GetServiceName() , service.GetMachineName(), service.GetStartType().ToString(), service.GetServiceType().ToString() , service.GetPath());
                }
            }

            return table;
        }
    }
}
