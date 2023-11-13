using EaterShell.PathHandling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell.Commands
{
    public class EraseCommand : Command
    {
        public override string Name => "erase";
        public override void Execute()
        {
            string FS = "EaterFS.json";
            OutputWriter.WriteLine($"Warning! Performing this action will erase your current Drive ({PathDirectoryHandler.GetSelectedDrive().Name})");
            OutputWriter.WriteLine($"Please confirm the erasing of your data Y/N");
            string confirmation = Console.ReadLine();

            switch (confirmation.ToLower())
            {
                case "y":
                    try
                    {
                        File.Delete(FS);
                        Process process = Process.GetCurrentProcess();

                        Process.Start(process.MainModule.FileName);

                        Environment.Exit(0);
                    }
                    catch (Exception ex)
                    {
                        OutputWriter.WriteLine("Something went wrong");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
