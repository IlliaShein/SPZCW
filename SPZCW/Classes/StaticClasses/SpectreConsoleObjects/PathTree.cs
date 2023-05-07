using Spectre.Console;

namespace SPZCW.Classes.StaticClasses.SpectreConsoleObjects
{
    public static class PathTree
    {
        public static Tree GetServicePathTree(string path)
        {
            Tree pathRoot = null;
            TreeNode[] branches = new TreeNode[9];

            string[] splittedPath = path.Split('\\');

            if (splittedPath.Length >= 1)
            {
                pathRoot = new Tree(splittedPath[0]);

                if (splittedPath.Length >= 2)
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
