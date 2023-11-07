using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace EaterShell
{
    public class MoreCommand : Command
    {
        public override string Name => "more";

        public MoreCommand() { }

        public override void Execute()
        {
            if (Parameters.Length == 1)
            {
                string filePath = Parameters[0];

                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    Console.WriteLine(fileContent);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("Usage: more <file_path>");
            }
        }
    }
}
