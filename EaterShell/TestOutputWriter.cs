using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class TestOutputWriter : IOutputWriter
    {
        public string OutputBuffer { get; set; }

        public void Write(string value)
        {
            OutputBuffer = value;
        }

        public void WriteLine(string value)
        {
            OutputBuffer = value;
        }
    }
}
