using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class PathHandler
    {

        private string _currentDirectory;

        public PathHandler(string currentDirectory)
        {
            _currentDirectory = currentDirectory;
        }

        public string GetNewPath(string inputPath)
        {
            string newPath = inputPath;

            if (inputPath == "..")
            {
                // Move up one directory level
                DirectoryInfo parentDir = Directory.GetParent(_currentDirectory);
                if (parentDir != null)
                {
                    newPath = parentDir.FullName;
                }
            }
            else if (Path.IsPathRooted(inputPath))
            {
                newPath = inputPath;
            }
            else
            {
                newPath = Path.Combine(_currentDirectory, inputPath);
            }

            newPath = Path.GetFullPath(newPath);

            return newPath;
        }

    }
}
