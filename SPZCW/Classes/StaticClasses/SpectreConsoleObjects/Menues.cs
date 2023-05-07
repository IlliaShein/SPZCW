using Spectre.Console;
using SPZCW.Interfaces;
using System.ServiceProcess;

namespace SPZCW.Classes.StaticClasses
{
    public static class Menues
    {
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
            "[red1]Exit[/]"
            });
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

        public static SelectionPrompt<string> GetActionsMenu(IService service)
        {
            return new SelectionPrompt<string>().AddChoices(new[]
            {
            GetStartOrStopChoise(service),
            "Restart",
            "Change start type",
            "Change display name",
            "Change description",
            "[red1]Back[/]",
            });
        }

        private static string GetStartOrStopChoise(IService service)
        {
            if (service.Status == ServiceControllerStatus.Stopped || !service.CanStop)
            {
                return "Start";
            }
            else
            {
                return "Stop";
            }
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
            "[red1]Back[/]"
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
            "[red1]Back[/]"
            });
        }
    }
}
