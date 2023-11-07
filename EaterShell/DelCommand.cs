using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class DelCommand : Command
    {
        public DelCommand() { }
        public override string Name => "del";

        public override void Execute()
        {
            string[] parts = Parameters[0].Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            string filename = parts[parts.Length - 1];

            if (filename.Contains("."))
            {
                PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
                TheFile fileToDelete = pathHandler.SearchFileSystemItem(Parameters[0]) as TheFile;

                TheDirectory selectedDir = PathDirectoryHandler.GetTempDirectory();
                

                selectedDir.FileSystemItems.Remove(fileToDelete);
                UpdateParentDirectoriesSize(fileToDelete);
            }
            else
            {
                OutputWriter.WriteLine($"{Parameters[0]} is not a valid file");
            }

            PersistenceService.Save(PathDirectoryHandler.GetSelectedDrive());

        }

        public void UpdateParentDirectoriesSize(TheFile newFile)
        {
            long fileSize = newFile.Size;

            TheDirectory parentDirectory = newFile.ParentDirectory;

            parentDirectory.Size -= fileSize;

            TheDirectory currentDirectory = parentDirectory;
            while (currentDirectory.ParentDirectory != null)
            {
                currentDirectory = currentDirectory.ParentDirectory;
                currentDirectory.Size -= fileSize;
            }

            PathDirectoryHandler.GetSelectedDrive().Size -= fileSize;
        }

        
    }
}
