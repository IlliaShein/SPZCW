using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spectre.Console;
using SPZCW;


namespace SPZCWTests
{
    [TestClass]
    public class LabelsTests
    {
        [TestMethod]
        public void GetTitleReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetTitle());
        }

        [TestMethod]
        public void GetTitleReturnsCorrectColor()
        {
            FigletText actual = SpectreConsoleObjects.GetTitle();
            FigletText expected = new FigletText("SPZCW").LeftJustified().Centered();

            Assert.IsTrue(actual.Color.ToString() == expected.Color.ToString());
        }

        [TestMethod]
        public void GetTitleReturnsCorrectValue()
        {
            FigletText actual = SpectreConsoleObjects.GetTitle();
            FigletText expected = new FigletText("SPZCW").LeftJustified().Centered();

            Assert.IsTrue(actual.ToString() == expected.ToString());
        }

        [TestMethod]
        public void GetMainMenuReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetMainMenu());
        }

        [TestMethod]
        public void GetChangeStartTypeMenuReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetChangeStartTypeMenu());
        }



        [TestMethod]
        public void GetMainMenuReturnsCorrectValue()
        {
            SelectionPrompt<string> actual = SpectreConsoleObjects.GetMainMenu();
            SelectionPrompt<string> expected = new SelectionPrompt<string>().AddChoices(new[]
            {
            "Active services",
            "Stopped services",
            "All services",
            "Process service",
            "[red]Exit[/]"
            });

            Assert.IsTrue(actual.ToString() == expected.ToString());
        }

        [TestMethod]
        public void GetChangeStartTypeMenuReturnsCorrectValue()
        {
            SelectionPrompt<string> actual = SpectreConsoleObjects.GetChangeStartTypeMenu();
            SelectionPrompt<string> expected = new SelectionPrompt<string>().AddChoices(new[]
            {
            "Manual",
            "Automatic",
            "Disabled",
            "Boot",
            "System",
            "[red]Back[/]"
            });

            Assert.IsTrue(actual.ToString() == expected.ToString());
        }
    }
}
