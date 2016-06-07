using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes
{
    public class Probe : Output
    {
        public Probe()
        {

        }

        public override string getKey()
        {
            return "PROBE";
        }

        public override object Clone()
        {
            return new Probe();
        }

        public override void show()
        {
            throw new NotImplementedException();
        }
    }
}
