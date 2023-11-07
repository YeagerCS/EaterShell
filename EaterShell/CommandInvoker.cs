using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class CommandInvoker
    {
        public CommandInvoker() { }
        public void Execute(string commandStr, string[] parameters)
        {
            Command command = CommandFactory.CreateCommand(commandStr);
            command.Parameters = parameters;
            try
            {
                command.Execute();
            } catch (Exception ex)
            {
                Console.WriteLine("Invalid Command Syntax.");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
