using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class And : Calculatable
    {
        public And()
        {

        }

        public override string getKey()
        {
            return "AND";
        }

        public override object Clone()
        {
            return new And();
        }

        public override int calculate()
        {
            // 0 0 = 0
            // 0 1 = 0
            // 1 0 = 0
            // 1 1 = 1
            Value = 1;
            foreach (Node node in previous)
            {
                if (node.Value == 0) Value = 0;
            }
            setCalculated();
            return Value;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
