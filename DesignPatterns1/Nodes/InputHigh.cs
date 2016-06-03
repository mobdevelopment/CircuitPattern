using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class InputHigh : Node
    {
        public InputHigh()
        {

        }

        public override string getKey()
        {
            return "INPUT_HIGH";
        }

        public override object Clone()
        {
            return new InputHigh();
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
