using Spectre.Console;
using SPZCW.Classes.StaticClasses;
using SPZCW.Interfaces;
using System;
using System.ServiceProcess;

namespace SPZCW
{
    public static class SpectreConsoleObjects
    {
        public static Markup Error(string errorMessage)
        {
            return new Markup($"\n[red]Error: {errorMessage}[/]\n");
        }

        public static MultiSelectionPrompt<string> GetFilterMenu()
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
        public static Tree GetServicePathTree(string path)
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

        public static Table GetServicesTable(bool addStatusColumn)
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
        public static SelectionPrompt<string> GetActionsMenu(IService service)
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

        public static SelectionPrompt<string> GetChangeStartTypeMenu()
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

        public static SelectionPrompt<string> GetMainMenu()
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

        public static SelectionPrompt<string> GetHelpMenu()
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

        public static FigletText GetTitle()
        {
            return new FigletText("SPZCW").LeftJustified().Centered();
        }

        private static string GetStartOrStopChoise(IService service)
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