using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class Or : Node
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

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
