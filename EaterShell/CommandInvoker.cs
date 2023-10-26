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
            command.Execute();
        }
    }
}
