﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.MainLoop();
        }
    }
}
