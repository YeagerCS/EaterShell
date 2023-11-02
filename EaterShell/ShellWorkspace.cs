using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class ShellWorkspace
    {
        public Drive Drive { get; set; }
        public string CurrentDir { get; set; }

        public ShellWorkspace()
        {
            Drive = PersistenceService.Load();
            CurrentDir = Drive.Name + Drive.RootDirectory.Name;

            PathDirectoryHandler.SetCurrentDirectory(CurrentDir);
            PathDirectoryHandler.SelectDrive(Drive);
        }
    }
}
