using Spectre.Console;

namespace SPZCW.Classes.StaticClasses.SpectreConsoleObjects
{
    public static class MainTitle
    {
        public static FigletText Title { get;} = new FigletText("SPZCW").LeftJustified().Centered();
    }
}
