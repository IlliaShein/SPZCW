using Spectre.Console;
using System;
using System.ServiceProcess;

namespace SPZCW
{
    static class Menu
    {
        static public void ProcessMainMenu()
        {
            AnsiConsole.Write(Labels.GetTitle());
            var mainMenuChoise = AnsiConsole.Prompt(Labels.GetMainMenu());

            switch (mainMenuChoise)
            {
                case "Active services":

                    var activeServices = GetActiveServicesTable();
                    AnsiConsole.WriteLine($"Services with status \"Active\"");
                    AnsiConsole.Write(activeServices);

                    break;
                case "Stopped services":

                    var stoppedServices = GetStoppedServicesTable();
                    AnsiConsole.WriteLine($"Services with status \"Stopped\"");
                    AnsiConsole.Write(stoppedServices);

                    break;
                case "All services":

                    var allServices = GetAllServicesTable();
                    AnsiConsole.Write(allServices);

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
            AnsiConsole.Write("\nService DisplayNumber: ");
            string serviceDisplayName = Console.ReadLine();

            bool correctName = false;
            Service service = null;
            for (int i = 0; i < Program.Services.Length; i++)
            {
                if(serviceDisplayName == Program.Services[i].GetDisplayName())
                {
                    correctName = true;
                    service = Program.Services[i];
                    break;
                }
            }

            
            if(!correctName)
            {
                AnsiConsole.WriteLine($"\nService \"{serviceDisplayName}\" not found");
                return;
            }

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine($"DisplayName : {service.GetDisplayName()}");
            AnsiConsole.WriteLine($"ServiceName : {service.GetServiceName()}");
            AnsiConsole.WriteLine($"MachineName : {service.GetMachineName()}");
            AnsiConsole.WriteLine($"Service Type : {service.GetServiceType()}");
            AnsiConsole.WriteLine($"Start Type : {service.GetStartType()}");
            AnsiConsole.WriteLine($"Status : {service.GetStatus()}");
            AnsiConsole.WriteLine();

            ActionsMenuProcessing(service);
        }

        static private void ActionsMenuProcessing(Service service)
        {
            SelectionPrompt<string> menu = new SelectionPrompt<string>();

            if(service.GetStatus() == ServiceControllerStatus.Running)
            {
                menu.AddChoice("Stop");
                menu.AddChoice("Restart");
            }
            else if(service.GetStartType() != ServiceStartMode.Disabled && service.GetStatus() == ServiceControllerStatus.Stopped)
            {
                menu.AddChoice("Start");
            }

            menu.AddChoice("Change start type");
            menu.AddChoice("Change display name");
            menu.AddChoice("[red]Back[/]");

            string ActionsMenuChoise = AnsiConsole.Prompt(menu);
            switch (ActionsMenuChoise)
            {
                case "Stop":

                    service.Stop();
                    Console.WriteLine($"Service \"{service.GetDisplayName()}\" stopped");

                    break;
                case "Start":

                    service.Start();
                    Console.WriteLine($"Service \"{service.GetDisplayName()}\" started");

                    break;
                case "Restart":

                    service.Stop();
                    service.Start();
                    Console.WriteLine($"Service \"{service.GetDisplayName()}\" restarted");

                    break;
                case "Change display name":

                    Console.Write("New name: ");
                    string oldName = service.GetDisplayName();
                    string newName = Console.ReadLine();

                    if(oldName == newName)
                    {
                        Console.WriteLine("It's current service DisplayName");
                        break;
                    }

                    service.ChangeDisplayName(newName);
                    Console.WriteLine($"Service DisplayName changed : {oldName} -> {newName} ");

                    break;
                    case "Change start type":

                    string ChangeStartTypeMenuChoise = AnsiConsole.Prompt(Labels.GetChangeStartTypeMenu());
                    string oldStartType = service.GetStartType().ToString();

                    if(ChangeStartTypeMenuChoise == service.GetStartType().ToString())
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
                case "[red]Back[/]":
                    return;
            }
            
        }

        static private Table GetAllServicesTable()
        {
            ServiceController[] services = ServiceController.GetServices();
            var table = new Table();

            table.AddColumn("DisplayName");
            table.AddColumn(new TableColumn("ServiceName"));
            table.AddColumn(new TableColumn("MachineName"));
            table.AddColumn(new TableColumn("Start type"));
            table.AddColumn(new TableColumn("ServiceType"));
            table.AddColumn(new TableColumn("Status").Centered());
           
            foreach (var service in Program.Services)
            {
                if (service.GetStatus() == ServiceControllerStatus.Stopped)
                {
                    table.AddRow(service.GetDisplayName(), service.GetServiceName(), service.GetMachineName(), service.GetStartType().ToString(), service.GetServiceType().ToString(), $"[invert red]{service.GetStatus()}[/]");
                }
                else if (service.GetStatus() == ServiceControllerStatus.Running)
                {
                    table.AddRow(service.GetDisplayName(), service.GetServiceName(), service.GetMachineName(), service.GetStartType().ToString(), service.GetServiceType().ToString(), $"[invert green]{service.GetStatus()}[/]");
                }
                else
                {
                    table.AddRow(service.GetDisplayName(), service.GetServiceName(), service.GetMachineName(),  service.GetStartType().ToString(), service.GetServiceType().ToString(), $"[invert yellow]{service.GetStatus()}[/]");
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
            var table = new Table();

            table.AddColumn("DisplayName");
            table.AddColumn(new TableColumn("ServiceName"));
            table.AddColumn(new TableColumn("MachineName"));
            table.AddColumn(new TableColumn("Start type"));
            table.AddColumn(new TableColumn("ServiceType"));

            foreach (var service in Program.Services)
            {
                if (service.GetStatus() == status)
                {
                    table.AddRow(service.GetDisplayName(), service.GetServiceName() , service.GetMachineName(), service.GetStartType().ToString(), service.GetServiceType().ToString());
                }
            }

            return table;
        }
    }
}
