using Spectre.Console;

namespace SPZCW
{
    public static class SpectreConsoleObjects
    {
        public static Markup Error(string errorMessage)
        {
            return new Markup($"\n[red]Error: {errorMessage}[/]\n");
        }

        public static FigletText GetTitle()
        {
            return new FigletText("SPZCW").LeftJustified().Centered();
        }

        public static Tree GetServicePathTree(string path)
        {
            Tree pathRoot = null;
            TreeNode[] branches = new TreeNode[9];

            string[] splittedPath = path.Split('\\');

            if (splittedPath.Length >= 1)
            {
                pathRoot = new Tree(splittedPath[0]);

                if(splittedPath.Length >= 2)
                {
                    branches[0] = pathRoot.AddNode(splittedPath[1]);
                }
            }

            for (int i = 2; i < splittedPath.Length; i++)
            {
                branches[i - 1] = branches[i - 2].AddNode(splittedPath[i]);
            }

            return pathRoot;
        }
    }
}