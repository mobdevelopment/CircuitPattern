﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class Nor : Calculatable
    {
        public Nor()
        {

        }

        public override string getKey()
        {
            return "NOR";
        }

        public override object Clone()
        {
            return new Nor();
        }

        public override int calculate()
        {
            // 0 0 = 1
            // 0 1 = 0
            // 1 0 = 0
            // 1 1 = 0
            foreach (Node node in previous)
            {
                if (node.Value > 0) return 0;
            }
            return 1;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
