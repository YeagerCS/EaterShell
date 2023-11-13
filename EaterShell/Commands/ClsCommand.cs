using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell.Commands
{
    public class ClsCommand : Command
    {
        public override string Name => "cls";

        public override void Execute()
        {
            Console.Clear();
        }
    }
}
