using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class InputLow : Input
    {
        public InputLow()
        {

        }

        public override string getKey()
        {
            return "INPUT_LOW";
        }

        public override object Clone()
        {
            return new InputLow();
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
