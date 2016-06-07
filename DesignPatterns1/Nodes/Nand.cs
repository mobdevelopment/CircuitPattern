using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class Nand : Calculatable
    {
        public Nand()
        {

        }

        public override string getKey()
        {
            return "NAND";
        }

        public override object Clone()
        {
            return new Nand();
        }

        public override int calculate()
        {
            // 0 0 = 1
            // 0 1 = 1
            // 1 0 = 1
            // 1 1 = 0
            Value = 0;
            foreach (Node node in previous)
            {
                if (node.Value == 0) Value = 1;
            }
            return Value;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }

    }
}
