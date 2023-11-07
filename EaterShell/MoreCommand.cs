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
            Parameters[0] = PathDirectoryHandler.GetFullPath(PathDirectoryHandler.GetCurrentDirectory(), Parameters[0]);
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


                if(meantFile == null)
                {
                    OutputWriter.WriteLine($"{Parameters[0]} not found.");
                    return;
                }
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
                            int percent = (100 / parts.Length) * currentPartIndex;
                            string msg = $"Press space to show more (..{percent}%..)";
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
