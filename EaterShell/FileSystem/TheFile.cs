using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell.FileSystem
{
    public class TheFile : FileSystemItem
    {
        public string Content { get; set; }

        public TheFile(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public TheFile() { }

    }
}
