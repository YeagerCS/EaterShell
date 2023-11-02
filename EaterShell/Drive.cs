using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class Drive
    {
        public TheDirectory RootDirectory { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Label { get; set; }
        public string FileSystemType { get; set; }  
        public string DriveType { get; set; }


        public Drive() { }

        public Drive(TheDirectory rootDirectory, string name, string label, string fileSystemType, string driveType)
        {
            RootDirectory = rootDirectory;
            Name = name;
            Label = label;
            FileSystemType = fileSystemType;
            DriveType = driveType;
        }


    }
}
