using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
            List<string> parameters = new List<string>();
            var matches = Regex.Matches(inputString, @"(?<match>""(?:\\""|[^""])*"")|(\S+)");
            bool firstMatch = true; 
            foreach (Match match in matches)
            {
                if (firstMatch)
                {
                    firstMatch = false;
                    continue; 
                }
                parameters.Add(match.Groups["match"].Success ? match.Groups["match"].Value.Trim('"') : match.Value);
            }
            return parameters.ToArray();
        }
    }
}
