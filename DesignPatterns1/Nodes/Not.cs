﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class Not : Calculatable
    {
        public Not()
        {

        }

        public override string getKey()
        {
            return "NOT";
        }

        public override object Clone()
        {
            return new Not();
        }

        public override int calculate()
        {
            return (previous.First().getValue() >= 1) ? 0 : 1;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}