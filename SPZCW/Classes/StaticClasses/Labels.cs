using Spectre.Console;

namespace SPZCW
{
    static public class Labels
    {
        static public SelectionPrompt<string> changeStartTypeMenu = new SelectionPrompt<string>().AddChoices(new[]
        {
        "Manual",
        "Automatic",
        "Disabled",
        "Boot",
        "System",
        "[red]Back[/]"
        });

        static public SelectionPrompt<string> mainMenu = new SelectionPrompt<string>().AddChoices(new[]
        {
        "Active services",
        "Stopped services",
        "All services",
        "Process service",
        "[red]Exit[/]"
        });

        static public FigletText title = new FigletText("SPZCW").LeftJustified().Centered();
    }
}
