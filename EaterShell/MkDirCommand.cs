using System;
using System.IO;

namespace EaterShell
{
    public class MkdirCommand : Command
    {
        public override string Name => "mkdir";

        public MkdirCommand() { }

        public override void Execute()
        {
            if (Parameters.Length >= 1)
            {
                string directoryName = Parameters[0];

                try
                {

                    string fullPath = Path.Combine(Environment.CurrentDirectory, directoryName);


                    if (!Directory.Exists(fullPath))
                    {




                    }
                    else
                    {
                        Console.WriteLine($"Directory already exists: {fullPath}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating directory: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Usage: mkdir <directory_name>");
            }
        }
    }
}
