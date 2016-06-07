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
        CircuitTester tester = new CircuitTester();
        
        public Circuit(Dictionary<String, Node> _nodes)
        {
            //circuitNodes = Reader.getNodes();
            this.Nodes = _nodes;
        }



        //private Dictionary<String, Node> circuitNodes = new Dictionary<String, Node>();


        private Dictionary<String, Node> nodes;
        public Dictionary<String, Node> Nodes
        {
            get
            {
                return nodes;
            }
            set
            {
                nodes = value;
            }
        }


        //public Dictionary<String, Node> getCircuitNodes()
        //{
        //    return circuitNodes;
        //}

        //public void setCircuitNodes(Dictionary<String, Node> _CNodes)
        //{
        //    circuitNodes = _CNodes;
        //}

        public Boolean validateCircuit()
        {
            if (tester.CircuitTest(nodes))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
