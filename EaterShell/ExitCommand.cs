using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class ExitCommand : Command
    {

        public override string Name => "exit";
        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
