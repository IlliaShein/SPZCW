using Spectre.Console;

namespace SPZCW
{
    static public class Labels
    {
        static public SelectionPrompt<string> GetChangeStartTypeMenu()
        {
            return new SelectionPrompt<string>().AddChoices(new[]
            {
            "Manual",
            "Automatic",
            "Disabled",
            "Boot",
            "System",
            "[red]Back[/]"
            });
        }

        static public SelectionPrompt<string> GetMainMenu()
        {
            return new SelectionPrompt<string>().AddChoices(new[]
            {
            "Active services",
            "Stopped services",
            "All services",
            "Process service",
            "[red]Exit[/]"
            });
        }

        static public FigletText GetTitle()
        {
            return new FigletText("SPZCW").LeftJustified().Centered();
        }

    }
}
