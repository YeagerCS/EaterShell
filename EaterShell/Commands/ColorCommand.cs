using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EaterShell.OutputWriters;

namespace EaterShell.Commands
{
    public class ColorCommand : Command
    {

        public override string Name => "color";

        public ColorCommand() { }

        public ColorCommand(IOutputWriter outputWriter)
        {
            OutputWriter = outputWriter;
        }

        public override void Execute()
        {

            if (Parameters.Length >= 1)
            {
                if (Enum.TryParse(Parameters[0], true, out ConsoleColor foregroundColor))
                {
                    OutputWriter.ForegroundColor = foregroundColor;
                }

                if (Parameters.Length >= 2)
                {
                    if (Parameters[0] == ".")
                    {
                        if (Enum.TryParse(Parameters[1], true, out ConsoleColor backgroundColor))
                        {
                            OutputWriter.BackgroundColor = backgroundColor;

                            OutputWriter.Clear();
                        }
                    }
                    else if (Enum.TryParse(Parameters[1], true, out ConsoleColor backgroundColor))
                    {
                        OutputWriter.BackgroundColor = backgroundColor;

                        OutputWriter.Clear();
                    }
                }
            }
        }
    }
}