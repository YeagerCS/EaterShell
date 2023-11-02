using System;
using System.IO;
using System.Net.Http.Headers;

namespace EaterShell
{
    public class MkdirCommand : Command
    {
        public override string Name => "mkdir";

        public MkdirCommand() { }

        public override void Execute()
        {
            TheDirectory currentDir = PathDirectoryHandler.GetTheDirectory();
            TheDirectory newDir = new(Parameters[0], DateTime.Now);
            currentDir.AddItem(newDir);
            PersistenceService.Save(PathDirectoryHandler.GetSelectedDrive());


        }
    }
}