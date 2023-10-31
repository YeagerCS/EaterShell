using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public virtual string[] Parameters { get; set; }
        public virtual IOutputWriter OutputWriter { get; set; }
        public abstract void Execute();

    }
}
