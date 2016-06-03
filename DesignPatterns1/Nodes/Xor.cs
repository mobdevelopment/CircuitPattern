using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class Xor : Node
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

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
