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
            Assert.IsNotNull(Labels.GetTitle());
        }

        [TestMethod]
        public void GetTitleReturnsCorrectColor()
        {
            FigletText actual = Labels.GetTitle();
            FigletText expected = new FigletText("SPZCW").LeftJustified().Centered();

            Assert.IsTrue(actual.Color.ToString() == expected.Color.ToString());
        }

        [TestMethod]
        public void GetTitleReturnsCorrectValue()
        {
            FigletText actual = Labels.GetTitle();
            FigletText expected = new FigletText("SPZCW").LeftJustified().Centered();

            Assert.IsTrue(actual.ToString() == expected.ToString());
        }

        [TestMethod]
        public void GetMainMenuReturnsNotNull()
        {
            Assert.IsNotNull(Labels.GetMainMenu());
        }

        [TestMethod]
        public void GetChangeStartTypeMenuReturnsNotNull()
        {
            Assert.IsNotNull(Labels.GetChangeStartTypeMenu());
        }



        [TestMethod]
        public void GetMainMenuReturnsCorrectValue()
        {
            SelectionPrompt<string> actual = Labels.GetMainMenu();
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
            SelectionPrompt<string> actual = Labels.GetChangeStartTypeMenu();
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
