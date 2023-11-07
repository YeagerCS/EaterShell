using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class MoveCommand : Command
    {
        public MoveCommand() { }
        public override string Name => "move";

        public override void Execute()
        {
            string itemToMovePath = Parameters[0];
            string dirToBeMovedTo = Parameters[1];

            string[] dirParts = dirToBeMovedTo.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            if (dirParts[dirParts.Length - 1].Contains("."))
            {
                OutputWriter.WriteLine($"{dirToBeMovedTo} is not a valid directory.");
                return;
            }

            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            FileSystemItem movingItem = pathHandler.SearchFileSystemItem(itemToMovePath);
            TheDirectory dirContainingItem = PathDirectoryHandler.GetTempDirectory();

            if (movingItem == null)
            {
                OutputWriter.WriteLine($"{itemToMovePath} not found.");
                return;
            }


            if (itemToMovePath == dirToBeMovedTo)
            {
                OutputWriter.WriteLine($"Can't move a directory to itself.");
                return;
            }

            if (IsMoveValid(itemToMovePath, dirToBeMovedTo))
            {
                //Commence the move
                dirContainingItem.FileSystemItems.Remove(movingItem);

                TheDirectory dirToMoveTo = pathHandler.SearchFileSystemItem(dirToBeMovedTo) as TheDirectory;

                if (dirToMoveTo == null)
                {
                    OutputWriter.WriteLine($"{dirToBeMovedTo} not found.");
                    return;
                }

                dirToMoveTo.FileSystemItems.Add(movingItem);
                UpdateParentDirs(movingItem, dirToBeMovedTo);
            }
            else
            {
                OutputWriter.WriteLine("Can't move a parent directory to a subdirectory");
            }
        }

        public bool IsMoveValid(string itemToMove, string dirToBeMovedTo)
        {
            itemToMove = Path.GetFullPath(itemToMove);
            dirToBeMovedTo = Path.GetFullPath(dirToBeMovedTo);

            if (dirToBeMovedTo.StartsWith(itemToMove, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }

        public void UpdateParentDirs(FileSystemItem movingItem, string dirToBeMovedTo)
        {
            long itemSize = movingItem.Size;

            TheDirectory parentDir = movingItem.ParentDirectory;

            parentDir.Size -= itemSize;

            TheDirectory currentDirectory = parentDir;
            while (currentDirectory.ParentDirectory != null)
            {
                currentDirectory = currentDirectory.ParentDirectory;
                currentDirectory.Size -= itemSize;
            }


            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            TheDirectory finalDir = pathHandler.SearchFileSystemItem(dirToBeMovedTo) as TheDirectory;
            if (finalDir != null)
            {
                finalDir.Size += movingItem.Size;

                TheDirectory secondCurrentDirectory = finalDir;
                while(secondCurrentDirectory.ParentDirectory != null)
                {
                    secondCurrentDirectory= secondCurrentDirectory.ParentDirectory;
                    secondCurrentDirectory.Size += movingItem.Size;
                }
            }
        }
    }
}
