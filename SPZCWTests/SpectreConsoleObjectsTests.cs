using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spectre.Console;
using SPZCW;


namespace SPZCWTests
{
    [TestClass]
    public class SpectreConsoleObjectsTests
    {
        [TestMethod]
        public void GetTitleReturnsNotNull()
        {
            Assert.IsNotNull(SpectreConsoleObjects.GetTitle());
        }

        [TestMethod]
        public void GetTitleReturnsCorrectColor()
        {
            //Arrange
            FigletText expected = new FigletText("SPZCW").LeftJustified().Centered();

            //Act
            FigletText actual = SpectreConsoleObjects.GetTitle();

            //Assert
            Assert.IsTrue(actual.Color.ToString() == expected.Color.ToString());
        }

        [TestMethod]
        public void GetTitleReturnsCorrectValue()
        {
            //Arrange
            FigletText expected = new FigletText("SPZCW").LeftJustified().Centered();

            //Act
            FigletText actual = SpectreConsoleObjects.GetTitle();

            //Assert
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
            //Arrange
            SelectionPrompt<string> actual = SpectreConsoleObjects.GetMainMenu();

            //Act
            SelectionPrompt<string> expected = new SelectionPrompt<string>().AddChoices(new[]
            {
            "Active services",
            "Stopped services",
            "All services",
            "Process service",
            "[red]Exit[/]"
            });

            //Assert
            Assert.IsTrue(actual.ToString() == expected.ToString());
        }

        [TestMethod]
        public void GetChangeStartTypeMenuReturnsCorrectValue()
        {
            //Arrange
            SelectionPrompt<string> actual = SpectreConsoleObjects.GetChangeStartTypeMenu();

            //Act
            SelectionPrompt<string> expected = new SelectionPrompt<string>().AddChoices(new[]
            {
            "Manual",
            "Automatic",
            "Disabled",
            "Boot",
            "System",
            "[red]Back[/]"
            });

            //Assert
            Assert.IsTrue(actual.ToString() == expected.ToString());
        }

        [TestMethod]
        public void GetHelpMenuReturnsCorrectValue()
        {
            //Arrange
            SelectionPrompt<string> expected = new SelectionPrompt<string>().AddChoices(new[]
            {
            "Program description",
            "Service Status",
            "Service names",
            "Service start types",
            "Service types",
            "[red]Back[/]"
            });

            // Act
            SelectionPrompt<string> actual = SpectreConsoleObjects.GetChangeStartTypeMenu();

            //Assert
            Assert.IsTrue(actual.ToString() == expected.ToString());
        }
    }
}
