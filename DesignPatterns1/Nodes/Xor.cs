﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class Xor : Calculatable
    {
        public Xor()
        {

        }

        public override string getKey()
        {
            return "XOR";
        }

        public override object Clone()
        {
            return new Xor();
        }

        public override int calculate()
        {
            // 0 0 = 0
            // 0 1 = 1
            // 1 0 = 1
            // 1 1 = 0
            int positives = 0;
            foreach (Node node in previous)
            {
                if (node.Value > 0) positives++;
            }
            Value = (positives == 1) ? 1 : 0;
            setCalculated();
            return Value;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
