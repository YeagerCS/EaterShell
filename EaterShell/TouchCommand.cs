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
            TheDirectory currentDir = PathDirectoryHandler.GetTheDirectory();

            TheFile file = new();

            file.Name = Parameters[0];

            file.Content = Parameters[1].ToString();

            currentDir.AddItem(file);

            PersistenceService.Save(PathDirectoryHandler.GetSelectedDrive());
        }

    }
}
