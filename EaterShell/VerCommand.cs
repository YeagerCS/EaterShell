﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaterShell
{
    public class VerCommand : Command
    {
        public override string Name => "ver";

        public override void Execute()
        {
            string ver = Environment.OSVersion.ToString();
            Console.WriteLine(ver);
        }
    }
}