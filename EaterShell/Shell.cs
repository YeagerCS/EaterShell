using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class Shell
    {

        public string directory;
        public string userInput;

        public void Run()
        {
            CurrentDir();
            Directory.SetCurrentDirectory(directory);

            CommandParser commandParser = new CommandParser();
            CommandInvoker commandInvoker = new CommandInvoker();

            do
            {
                Console.Write(Directory.GetCurrentDirectory() + ">");
                userInput = Console.ReadLine();

                string cmd = commandParser.GetCommand(userInput);
                string[] parameters = commandParser.GetParamters(userInput);

                if(!string.IsNullOrEmpty(cmd))
                {
                    commandInvoker.Execute(cmd, parameters);
                }

            }while(true);
        }

        public void CurrentDir()
        {
            //default directory
            string user = Environment.UserName;
            directory = @"C:\Users\" + user;

            //No code mache dasses apasst wird wenn mit CdCommand de directory apasst wird

        }
    }
}
