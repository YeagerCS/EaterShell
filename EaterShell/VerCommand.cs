using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class VerCommand : Command
    {
        public override string Name => "ver";

        public VerCommand() { }

        public VerCommand(IOutputWriter outputWriter)
        {
            OutputWriter = outputWriter;
        }

        public override void Execute()
        {
            string ver = Environment.OSVersion.ToString();
            OutputWriter.WriteLine(ver);
        }
    }
}
