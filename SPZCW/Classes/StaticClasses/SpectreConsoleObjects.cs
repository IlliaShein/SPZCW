using Spectre.Console;
using SPZCW.Classes.StaticClasses;
using SPZCW.Interfaces;
using System;
using System.ServiceProcess;

namespace SPZCW
{
    static public class SpectreConsoleObjects
    {
        static public Markup Error(string errorMessage)
        {
            return new Markup($"\n[red]Error: {errorMessage}[/]\n");
        }

        static public MultiSelectionPrompt<string> GetFilterMenu()
        {
            return new MultiSelectionPrompt<string>()
                            .PageSize(15)
                            .AddChoiceGroup<string>("Status", new string[] {
                            "Running" , "Stopped", "Other"})
                            .AddChoiceGroup("Start type", new string[] {
                                "Manual", "Automatic", "Disabled", "Boot", "System"})
                            .AddChoiceGroup("MachineName", new string[] {
                                "Localhost" , "Another device"})
                            .AddChoiceGroup("Back", new string[] { });
        }
        static public Tree GetServicePathTree(string path)
        {
            string[] splittedPath = path.Split('\\');

            Tree pathRoot = null;
            TreeNode bransh1 = null;
            TreeNode bransh2 = null;
            TreeNode bransh3 = null;
            TreeNode bransh4 = null;
            TreeNode bransh5 = null;
            TreeNode bransh6 = null;
            TreeNode bransh7 = null;
            TreeNode bransh8 = null;
            TreeNode bransh9 = null;


            for (int i = 0; i < splittedPath.Length; i++)
            {
                if (i == 0)
                {
                    pathRoot = new Tree(splittedPath[i]);
                }
                else if (i == 1)
                {
                    bransh1 = pathRoot.AddNode(splittedPath[i]);
                }
                else if (i == 2)
                {
                    bransh2 = bransh1.AddNode(splittedPath[i]);
                }
                else if (i == 3)
                {
                    bransh3 = bransh2.AddNode(splittedPath[i]);
                }
                else if (i == 4)
                {
                    bransh4 = bransh3.AddNode(splittedPath[i]);
                }
                else if (i == 5)
                {
                    bransh5 = bransh4.AddNode(splittedPath[i]);
                }
                else if (i == 6)
                {
                    bransh6 = bransh5.AddNode(splittedPath[i]);
                }
                else if (i == 7)
                {
                    bransh7 = bransh6.AddNode(splittedPath[i]);
                }
                else if (i == 8)
                {
                    bransh8 = bransh7.AddNode(splittedPath[i]);
                }
                else if (i == 9)
                {
                    bransh9 = bransh8.AddNode(splittedPath[i]);
                }
                else
                {
                    bransh9.AddNode("...");
                    break;
                }
            }

            return pathRoot;
        }
        static public BreakdownChart GetMainMenuChartByStatus()
        {
            ServiceController[] services = ServiceController.GetServices();

            int stoppedAmount = 0;
            int runningAmount = 0;
            int otherAmount = 0;

            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].Status == ServiceControllerStatus.Stopped)
                {
                    stoppedAmount++;
                }
                else if (services[i].Status == ServiceControllerStatus.Running)
                {
                    runningAmount++;
                }
                else
                {
                    otherAmount++;
                }
            }

            float stoppedPercentage = (100 * stoppedAmount) / services.Length;
            float runningPercentage = (100 * runningAmount) / services.Length;
            float otherPercentage = (100 * otherAmount) / services.Length;

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Stopped", stoppedPercentage, Colors.ColdGammaColor1())
                    .AddItem("Running", runningPercentage, Colors.ColdGammaColor6())
                    .AddItem("Other", otherPercentage, Colors.ColdGammaColor2());
        }

        static public BreakdownChart GetMainMenuChartByStartType()
        {
            ServiceController[] services = ServiceController.GetServices();

            int automaticAmount = 0;
            int manualAmount = 0;
            int disabledAmount = 0;
            int systemAmount = 0;
            int bootAmount = 0;

            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].StartType == ServiceStartMode.Automatic)
                {
                    automaticAmount++;
                }
                else if (services[i].StartType == ServiceStartMode.Manual)
                {
                    manualAmount++;
                }
                else if (services[i].StartType == ServiceStartMode.Disabled)
                {
                    disabledAmount++;
                }
                else if (services[i].StartType == ServiceStartMode.System)
                {
                    systemAmount++;
                }
                else // services[i].StartType == ServiceStartMode.Boot
                {
                    bootAmount++;
                }
            }

            float automaticPercentage = (100 * automaticAmount) / services.Length;
            float manualPercentage = (100 * manualAmount) / services.Length;
            float disabledPercentage = (100 * disabledAmount) / services.Length;
            float systemPercentage = (100 * systemAmount) / services.Length;
            float bootPercentage = (100 * bootAmount) / services.Length;

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Automatic", automaticPercentage, Colors.ColdGammaColor1())
                    .AddItem("Manual", manualPercentage, Colors.ColdGammaColor6())
                    .AddItem("Disabled", disabledPercentage, Colors.ColdGammaColor2())
                    .AddItem("System", systemPercentage, Colors.ColdGammaColor5())
                    .AddItem("Boot", bootPercentage, Colors.ColdGammaColor3());

        }

        static public BreakdownChart GetMainMenuChartByServiceType()
        {
            ServiceController[] services = ServiceController.GetServices();

            int kernelDriverAmount = 0;
            int fileSystemDriverAmount = 0;
            int adapterAmount = 0;
            int interactiveProcessAmount = 0;
            int recognizerDriverAmount = 0;
            int win32OwnProcessAmount = 0;
            int win32ShareProcessAmount = 0;
            int otherAmount = 0;

            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].ServiceType == ServiceType.KernelDriver)
                {
                    kernelDriverAmount++;
                }
                else if (services[i].ServiceType == ServiceType.FileSystemDriver)
                {
                    fileSystemDriverAmount++;
                }
                else if (services[i].ServiceType == ServiceType.Adapter)
                {
                    adapterAmount++;
                }
                else if (services[i].ServiceType == ServiceType.InteractiveProcess)
                {
                    interactiveProcessAmount++;
                }
                else if (services[i].ServiceType == ServiceType.RecognizerDriver)
                {
                    recognizerDriverAmount++;
                }
                else if (services[i].ServiceType == ServiceType.Win32OwnProcess)
                {
                    win32OwnProcessAmount++;
                }
                else if (services[i].ServiceType == ServiceType.Win32ShareProcess)
                {
                    win32ShareProcessAmount++;
                }
                else
                {
                    otherAmount++;
                }
            }

            float kernelDrivePercentage = (100 * kernelDriverAmount) / services.Length;
            float fileSystemDriverPercentage = (100 * fileSystemDriverAmount) / services.Length;
            float adapterPercentage = (100 * adapterAmount) / services.Length;
            float interactiveProcessPercentage = (100 * interactiveProcessAmount) / services.Length;
            float recognizerDriverPercentage = (100 * recognizerDriverAmount) / services.Length;
            float win32OwnProcessPercentage = (100 * win32OwnProcessAmount) / services.Length;
            float win32ShareProcessPercentage = (100 * win32ShareProcessAmount) / services.Length;
            float otherPercentage = (100 * otherAmount) / services.Length;

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Win32OwnProcess", win32OwnProcessPercentage, Colors.ColdGammaColor1())
                    .AddItem("Win32ShareProcess", win32ShareProcessPercentage, Colors.ColdGammaColor8())
                    .AddItem("KernelDriver", kernelDrivePercentage, Colors.ColdGammaColor2())
                    .AddItem("FileSystemDriver", fileSystemDriverPercentage, Colors.ColdGammaColor7())
                    .AddItem("Adapter", adapterPercentage, Colors.ColdGammaColor3())
                    .AddItem("InteractiveProcess", interactiveProcessPercentage, Colors.ColdGammaColor6())
                    .AddItem("RecognizerDriver", recognizerDriverPercentage, Colors.ColdGammaColor4())
                    .AddItem("Other", otherPercentage, Colors.ColdGammaColor5());
        }

        static public BreakdownChart GetMainMenuChartByMachineName()
        {
            ServiceController[] services = ServiceController.GetServices();

            int localAmount = 0;
            int otherAmount = 0;

            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].MachineName == ".")
                {
                    localAmount++;
                }
                else
                {
                    otherAmount++;
                }
            }

            float localPercentage = (100 * localAmount) / services.Length;
            float otherPercentage = (100 * otherAmount) / services.Length;

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Localhost", localPercentage, Colors.ColdGammaColor1())
                    .AddItem("Other", otherPercentage, Colors.ColdGammaColor6());
        }

        static public Table GetServicesTable(bool addStatusColumn)
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
        static public SelectionPrompt<string> GetActionsMenu(IService service)
        {
            return new SelectionPrompt<string>().AddChoices(new[]
            {
            GetStartOrStopChoise(service),
            "Restart",
            "Change start type",
            "Change display name",
            "Change description",
            "[purple]Back[/]",
            });
        }

        static public SelectionPrompt<string> GetChangeStartTypeMenu()
        {
            return new SelectionPrompt<string>().AddChoices(new[]
            {
            "Manual",
            "Automatic",
            "Disabled",
            "Boot",
            "System",
            "[purple]Back[/]"
            });
        }

        static public SelectionPrompt<string> GetMainMenu()
        {
            return new SelectionPrompt<string>().AddChoices(new[]
            {
            "Active services",
            "Stopped services",
            "All services",
            "Filter services",
            "Process service",
            "Help",
            "[purple]Exit[/]"
            });
        }

        static public SelectionPrompt<string> GetHelpMenu()
        {
            return new SelectionPrompt<string>().AddChoices(new[]
           {
            "Program description",
            "Service Status",
            "Service names",
            "Service start types",
            "Service types",
            "[purple]Back[/]"
            });
        }

        static public FigletText GetTitle()
        {
            return new FigletText("SPZCW").LeftJustified().Centered();
        }

        static private string GetStartOrStopChoise(IService service)
        {
            if (service.Status == ServiceControllerStatus.Stopped)
            {
                return "Start";
            }
            else
            {
                return "Stop" ;
            }
        }

    }
}