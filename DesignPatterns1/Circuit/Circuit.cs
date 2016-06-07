using DesignPatterns1.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    public class Circuit
    {
        CircuitTester tester;
        
        public Circuit(Dictionary<String, Node> _n)
        {
            this.Nodes = _n;
            tester = new CircuitTester();
        }

        private Dictionary<String, Node> _nodes;
        private Dictionary<String, Node> Nodes
        {
            get
            {
                return _nodes;
            }
            set
            {
                _nodes = value;
            }
        }

        public Boolean validateCircuit()
        {
            if (tester.CircuitTest(Nodes))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
