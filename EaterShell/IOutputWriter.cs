﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public interface IOutputWriter
    {
        void Write(string value);
        void WriteLine(string value);
    }
}
