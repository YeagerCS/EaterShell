using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EaterShell
{
    public class MoreCommand : Command
    {
        public override string Name => "more";

        public MoreCommand() { }

        public override void Execute()
        {
            int windowHeight = Console.WindowHeight;
            Console.WriteLine(windowHeight);

            string filename = Parameters[0];
            if (!filename.Contains("."))
            {
                OutputWriter.WriteLine(filename + " is not a valid file");
            }
            else
            {
                PathHandler pathHandler = new(PathDirectoryHandler.GetCurrentDirectory());
                TheFile meantFile = pathHandler.SearchFileSystemItem(filename) as TheFile;

                string[] parts = meantFile.Content.Split("\\n");

                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i].Replace("\n", "");
                }

                int currentPartIndex = 0;
                if (meantFile != null)
                {
                    while (currentPartIndex < parts.Length)
                    {
                        for (int i = 0; i < Math.Min(windowHeight, parts.Length - currentPartIndex); i++)
                        {
                            OutputWriter.WriteLine(parts[currentPartIndex]);
                            currentPartIndex++;
                        }

                        if (currentPartIndex < parts.Length)
                        {
                            string msg = "Press space to show more or any other key to exit.";
                            OutputWriter.WriteLine(msg);
                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                            if (keyInfo.Key != ConsoleKey.Spacebar)
                            {
                                break;
                            }
                            else
                            {
                                int currentLineCursor = Console.CursorTop;
                                Console.SetCursorPosition(0, currentLineCursor);
                                Console.Write(new string(' ', Console.WindowWidth));
                                Console.SetCursorPosition(0, currentLineCursor);
                            }
                        }
                    }
                }
                else
                {
                    OutputWriter.WriteLine(filename + " is not a valid file");
                }
            }
        }
    }
}
