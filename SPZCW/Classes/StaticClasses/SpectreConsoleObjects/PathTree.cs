using Spectre.Console;

namespace SPZCW.Classes.StaticClasses.SpectreConsoleObjects
{
    public static class PathTree
    {
        public static Tree GetServicePathTree(string path)
        {
            string[] splittedPath = path.Split('\\');

            Tree pathRoot = null;
            TreeNode[] branches = new TreeNode[splittedPath.Length - 1];

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
