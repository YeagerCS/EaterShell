using System;
using System.IO;
using System.Net.Http.Headers;
using EaterShell.FileSystem;
using EaterShell.FileSystem.Persistence;
using EaterShell.PathHandling;

namespace EaterShell.Commands
{
    public class MkdirCommand : Command
    {
        public override string Name => "mkdir";

        public MkdirCommand() { }

        public override void Execute()
        {
            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());

            Parameters[0] = PathDirectoryHandler.GetFullPath(PathDirectoryHandler.GetCurrentDirectory(), Parameters[0]);
            string[] strings = Parameters[0].Split("\\");
            string result = "";
            if (strings.Length >= 2)
            {
                result = string.Join("\\", strings.Take(strings.Length - 1));

            }
            pathHandler.SearchFileSystemItem(result);


            string[] parts = Parameters[0].Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);

            TheDirectory currentDir = PathDirectoryHandler.GetTempDirectory();
            string dirName = parts[parts.Length - 1];

            foreach (FileSystemItem fsi in currentDir.FileSystemItems)
            {
                if (fsi.Name == dirName)
                {
                    Console.WriteLine($"Directory '{dirName}' already exists");
                    return;
                }
            }

            TheDirectory newDir = new(dirName, DateTime.Now);
            currentDir.AddItem(newDir);
            PersistenceService.Save(PathDirectoryHandler.GetSelectedDrive());


        }
    }
}