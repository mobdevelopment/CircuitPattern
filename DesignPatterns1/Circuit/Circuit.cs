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
        

        public Circuit()
        {
            //circuitNodes = Reader.getNodes();

            
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
            if (tester.FloodFill())
            {
                Console.WriteLine("Circuit is correctly build");
                //foreach (KeyValuePair<string, Node> node in Nodes)
                //{
                //    Console.WriteLine(node.Key);
                //}
                return true;
            } else
            {
                Console.WriteLine("Circuit is incorrectly build");

                return false;
            }
        }
    }
}
