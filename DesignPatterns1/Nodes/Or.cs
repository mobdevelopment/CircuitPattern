using System;
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
            // 0 0 = 0
            // 0 1 = 1
            // 1 0 = 1
            // 1 1 = 1
            value = 0;
            foreach (Node node in previous)
            {
                if (node.getValue() > 0) value = 1;
            }
            return value;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
