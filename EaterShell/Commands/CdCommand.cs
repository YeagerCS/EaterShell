using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EaterShell.PathHandling;

namespace EaterShell.Commands
{
    public class CdCommand : Command
    {
        public override string Name => "cd";

        public CdCommand()
        {
        }

        public override void Execute()
        {
            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            string newPath = pathHandler.GetNewPath(Parameters[0]);
            PathDirectoryHandler.SetCurrentDirectory(newPath);
        }

    }
}
