﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class Or : Calculatable
    {
        public Or()
        {

        }

        public override string getKey()
        {
            return "OR";
        }

        public override object Clone()
        {
            return new Or();
        }

        public override int calculate()
        {
            foreach (Node node in previous)
            {
                if (node.getValue() > 0) return 1;
            }
            return 0;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}