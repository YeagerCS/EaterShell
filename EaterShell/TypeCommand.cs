using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class TypeCommand : Command
    {
        public override string Name => "type";

        public TypeCommand() { }

        public TypeCommand(IOutputWriter output)
        {
            OutputWriter = output;
        }

        public override void Execute()
        {
            string filename = Parameters[0];
            if (!filename.Contains("."))
            {
                OutputWriter.WriteLine(filename + " is not a valid file");
            }
            else
            {
                PathHandler pathHandler = new(PathDirectoryHandler.GetCurrentDirectory());
                TheFile meantFile = pathHandler.SearchFileSystemItem(filename) as TheFile;
                if (meantFile != null)
                {
                    OutputWriter.WriteLine(meantFile.Content);
                }
                else
                {
                    OutputWriter.WriteLine(filename + " is not a valid file");
                }
            }
        }
    }
}
