using System;
using System.Collections.Generic;
using System.IO;
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
                newPath = MoveUpDirectory(_currentDirectory);

                if (!IsRootDirectory())
                {
                    MoveUpChangeDirectory();
                }
            }
            else if (inputPath.StartsWith("..\\"))
            {
                // Splits all times when a ..\ is in the path example: "..\..\dir" => ["..\", "..\", "dir"]
                string[] parts = inputPath.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                string currentPath = _currentDirectory;

                //This Loop goes through the path checking wether it has to move up a directory or change it
                foreach (string part in parts)
                {
                    if (part == "..")
                    {
                        newPath = MoveUpDirectory(currentPath);
                        if (!IsRootDirectory())
                        {
                            MoveUpChangeDirectory();
                        }
                    }
                    else
                    {
                        bool eval = EvalNewDirectory(part);
                        if (eval)
                        {
                            newPath = Path.Combine(newPath, part);
                        }
                        else
                        {
                            break;
                        }
                    }
                    currentPath  = newPath;
                }
            }

            else
            {

                bool eval = EvalNewDirectory(inputPath);
                newPath = eval ? Path.Combine(_currentDirectory, inputPath) : PathDirectoryHandler.GetCurrentDirectory();
            }



            return newPath;
        }

        public void MoveUpChangeDirectory()
        {
            TheDirectory currentDir = PathDirectoryHandler.GetTheDirectory();
            TheDirectory newDir = currentDir.ParentDirectory;
            Console.WriteLine("NewDir " + currentDir.ParentDirectory);

            PathDirectoryHandler.SetTheDirectory(newDir);
        }

        public bool IsRootDirectory()
        {
            return PathDirectoryHandler.GetTheDirectory() == PathDirectoryHandler.GetSelectedDrive().RootDirectory;
        }

        public string MoveUpDirectory(string path)
        {
            string[] pathParts = path.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);

            if (pathParts.Length > 1)
            {
                string newPath = string.Join(Path.DirectorySeparatorChar.ToString(), pathParts, 0, pathParts.Length - 1);
                if (newPath.EndsWith(":"))
                {
                    return newPath + "\\";
                }

                return newPath;
            }
            else
            {
                if (path.EndsWith(":"))
                {
                    return path + "\\";
                }
                else
                {
                    return path;
                }
            }
        }

        public bool EvalNewDirectory(string path)
        {
            string[] pathParts = path.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            TheDirectory currDir = PathDirectoryHandler.GetTheDirectory();

            foreach (string dirName in pathParts)
            {
                TheDirectory subDir = SearchDirectory(dirName, currDir);
                if (subDir != null)
                {
                    currDir = subDir;
                }
                else
                {
                    Console.WriteLine($"Directory '{dirName}' not found.");
                    return false;
                }
            }

            PathDirectoryHandler.SetTheDirectory(currDir);
            return true;
        }

        private TheDirectory SearchDirectory(string name, TheDirectory currDir)
        {
            TheDirectory foundDir = null;
            foreach (FileSystemItem item in currDir.FileSystemItems)
            {
                if (item.Name.ToLower() == name.ToLower() && item.GetType() == typeof(TheDirectory))
                {
                    foundDir = item as TheDirectory;
                }
            }


            return foundDir;
        }

    }
}
