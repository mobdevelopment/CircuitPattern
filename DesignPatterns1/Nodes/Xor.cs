using System;
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
            int positives = 0;
            foreach (Node node in previous)
            {
                if (node.getValue() > 0) positives++;
            }
            return (positives == 1) ? 1 : 0;
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
