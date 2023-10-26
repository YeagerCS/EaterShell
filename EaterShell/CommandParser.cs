using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class CommandParser
    {
        private Dictionary<string, Type> commands = new Dictionary<string, Type>();

        public CommandParser() 
        {
            commands = CommandFactory.GetCommands();

        }


        public string GetCommand(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                string[] parts = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                if (commands.TryGetValue(command, out Type commandType))
                {
                    return command;
                }
                else
                {
                    Console.WriteLine($"Command '{command}' not found");
                    return "";
                }
            }
            else
            {
                return "";
            }

        }

        public string[] GetParamters(string inputString)
        {
            string[] parts = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] parameters = parts.Skip(1).ToArray();
            return parameters;
        }
    }
}
