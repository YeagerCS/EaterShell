using EaterShell.FileSystem;
using EaterShell.PathHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell.Commands
{
    public class DriveCommand : Command
    {
        public override string Name => "drive";

        public override void Execute()
        {
            Drive drive = PathDirectoryHandler.GetSelectedDrive();
            OutputWriter.WriteLine($"{drive.Label}\t{drive.Name}");
            OutputWriter.WriteLine("Drive type: " + drive.DriveType);
            OutputWriter.WriteLine("File system type: " + drive.FileSystemType);
            OutputWriter.WriteLine("Total size: " + drive.Size + " bytes");
        }
    }
}
