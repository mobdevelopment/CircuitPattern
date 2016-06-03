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
            foreach (Node node in previous)
            {
                if (node.getValue() < 0)
                {
                   return 0;
                }
            }
            return 1;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
