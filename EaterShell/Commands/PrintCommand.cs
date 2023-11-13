using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell.Commands
{
    public class PrintCommand : Command
    {
        public override string Name => "print";

        public override void Execute()
        {
            if(Parameters.Length == 1)
            {
                string text = Parameters[0];
                OutputWriter.WriteLine(text);
            }
        }
    }
}
