using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell.OutputWriters
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public ConsoleColor BackgroundColor
        {
            get { return Console.BackgroundColor; }
            set
            {
                Console.BackgroundColor = value;
            }
        }
        public ConsoleColor ForegroundColor
        {
            get { return Console.ForegroundColor; }
            set
            {
                Console.ForegroundColor = value;
            }
        }
        public ConsoleOutputWriter() { }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
        public void Clear()
        {
            Console.Clear();
        }
    }
}
