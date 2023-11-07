using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class TouchCommand : Command
    {
        public override string Name => "touch";

        public TouchCommand() { }

        public override void Execute()
        {
            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            pathHandler.SearchFileSystemItem(Parameters[0]);

            TheDirectory selectedDir = PathDirectoryHandler.GetTempDirectory();

            TheFile file = new();
            string[] parts = Parameters[0].Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            string filename = parts[parts.Length - 1];

            foreach (FileSystemItem fsi in selectedDir.FileSystemItems)
            {
                if (fsi.Name == filename)
                {
                    Console.WriteLine($"File '{filename}' already exists");
                    return;
                }
            }

            file.Name = filename;
            file.Content = Parameters[1].ToString();
            file.CreatedOn = DateTime.Now;
            file.Size = GetFileSize(file);

            selectedDir.AddItem(file);
            UpdateParentDirectoriesSize(file);


            PersistenceService.Save(PathDirectoryHandler.GetSelectedDrive());
        }

        public void UpdateParentDirectoriesSize(TheFile newFile)
        {
            long fileSize = newFile.Size;

            TheDirectory parentDirectory = newFile.ParentDirectory;

            parentDirectory.Size += fileSize;

            TheDirectory currentDirectory = parentDirectory;
            while (currentDirectory.ParentDirectory != null)
            {
                currentDirectory = currentDirectory.ParentDirectory;
                currentDirectory.Size += fileSize;
            }

            PathDirectoryHandler.GetSelectedDrive().Size += fileSize;
        }

        public long GetFileSize(TheFile file)
        {
            string contentString = file.Content;
            Encoding encoding= Encoding.UTF8;

            byte[] bytes = encoding.GetBytes(contentString);
            long sizeInBytes = bytes.Length;

            return sizeInBytes;
        }


    }
}
