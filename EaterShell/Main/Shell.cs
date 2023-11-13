using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EaterShell.PathHandling;

namespace EaterShell.Main
{
    public class Shell
    {

        public string directory;
        public string userInput;
        public ShellWorkspace shellWorkspace;

        public Shell()
        {
            shellWorkspace = new ShellWorkspace();
        }

        public void Run()
        {
            CommandParser commandParser = new CommandParser();
            CommandInvoker commandInvoker = new CommandInvoker();

            do
            {
                Console.Write(PathDirectoryHandler.GetCurrentDirectory() + ">");
                PathHandler pathHandler = new PathHandler(PathDirectoryHandler.GetCurrentDirectory());
                userInput = Console.ReadLine();

                string cmd = commandParser.GetCommand(userInput);
                string[] parameters = commandParser.GetParamters(userInput);

                if (!string.IsNullOrEmpty(cmd))
                {
                    commandInvoker.Execute(cmd, parameters);
                }

            } while (true);
        }

    }
}
