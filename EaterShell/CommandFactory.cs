using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EaterShell
{
    public class CommandFactory
    {
        private static Dictionary<string, Type> commands = Assembly.GetExecutingAssembly()
                                                            .GetTypes()
                                                            .Where(type => type.IsSubclassOf(typeof(Command)))
                                                            .ToDictionary(type => ((Command)Activator.CreateInstance(type)).Name, type => type);


        public static Command CreateCommand(string cmd)
        {
            if (commands.TryGetValue(cmd, out Type commandType))
            {
                Command commandInstance = (Command)Activator.CreateInstance(commandType);
                commandInstance.OutputWriter = new ConsoleOutputWriter();
                return commandInstance;
            }
            return null;

        }

        public static Dictionary<string, Type> GetCommands()
        {
            return commands;
        }

        public CommandFactory() { }
        

    }
}
