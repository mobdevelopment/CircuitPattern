﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public abstract class Input : Node
    {
        public Input()
        {
            calculated = true;
        }
    }
}
