using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class FileSystemItem
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime CreatedOn { get; set; }
        public TheDirectory ParentDirectory { get; set; }

    }
}
