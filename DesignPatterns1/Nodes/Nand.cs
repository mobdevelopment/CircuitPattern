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
            value = 0;
            foreach (Node node in previous)
            {
                if (node.getValue() == 0) value = 1;
            }
            return value;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }

    }
}
