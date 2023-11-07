﻿using System;
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
            file.Name = filename;
            file.Content = Parameters[1].ToString();

            selectedDir.AddItem(file);

            PersistenceService.Save(PathDirectoryHandler.GetSelectedDrive());
        }

    }
}
