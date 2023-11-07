using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class RenCommand : Command
    {
        public override string Name => "ren";

        public RenCommand()
        {

        }

        public override void Execute()
        {


            PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
            FileSystemItem file = pathHandler.SearchFileSystemItem(Parameters[0]);


            try
            {
                string newName = Parameters[1];
                file.Name = newName;
            }
            catch
            {
                Console.WriteLine("Please enter a new name");
            }

            PersistenceService.Save(PathDirectoryHandler.GetSelectedDrive());

        }

    }
}
