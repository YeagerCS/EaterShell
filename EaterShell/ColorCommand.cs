using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class ColorCommand : Command
    {
            
        public override string Name => "color";

        public ColorCommand() { }

        public override void Execute()
        {

            if (Parameters.Length >= 1)
            {
                if (Enum.TryParse(Parameters[0], true, out ConsoleColor foregroundColor))
                {
                    Console.ForegroundColor = foregroundColor;
                }

                if (Parameters.Length >= 2)
                {
                    if (Parameters[1] == ".")
                    {
                        if (Enum.TryParse(Parameters[2], true, out ConsoleColor backgroundColor))
                        {
                            Console.BackgroundColor = backgroundColor;
                            Console.Clear();
                        }
                    }
                    else if (Enum.TryParse(Parameters[1], true, out ConsoleColor backgroundColor))
                    {
                        Console.BackgroundColor = backgroundColor;
                        Console.Clear();
                    }
                }
            }

        }
    }
}