using DesignPatterns1.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1
{
    class CircuitTester
    {
        // Here needs to be put the function for testing if an circuit can be executed.
        // Given hint was flood fill.
        // flood fill is primarily used for calculating the shortest route through a maze.
        // Do not know how to implement flood fill to the full adder
        // Do not kwow because the full adder had multiple beginnings and multiple endings

        private Dictionary<String, Node> nodes = new Dictionary<String, Node>();

        public CircuitTester()
        {
            //Nodes = _nodes;
        }

        public Boolean CircuitTest(Dictionary<String, Node> nodes)
        {
            bool floodTest = FloodFill(nodes);

            bool connectTest = NodeConnection(nodes);

            if(floodTest && connectTest)
            {
                return true;
            }
            return false;
        }

        public Boolean FloodFill(Dictionary<String, Node> nodes)
        {
            return true;
        }

        private Boolean NodeConnection(Dictionary<String, Node> nodes)
        {
            int boolCount = 0;
            foreach(KeyValuePair<String, Node> node in nodes)
            {
                bool nodeConn = false;
                List<Node> prevNodes = node.Value.getPrevious();
                List<Node> nextNodes = node.Value.getNext();

                if (node.Value.getKey().Contains("INPUT"))
                {
                    // NODE is a input node
                    if(nextNodes.Count > 0)
                    {
                        nodeConn = true;
                    }
                    
                } else if (node.Value.getKey().Contains("PROBE"))
                {
                    // NODE is a end node
                    if (prevNodes.Count == 1)
                    {
                        nodeConn = true;
                    }

                } else
                {
                    // NODE is a connecting node.
                    if (node.Value.getKey().Contains("NOT"))
                    {
                        if (prevNodes.Count == 1 && nextNodes.Count > 0)
                        {
                            nodeConn = true;
                        }
                    }
                    else
                    {
                        if (prevNodes.Count == 2 && nextNodes.Count > 0)
                        {
                            nodeConn = true;
                        }
                    }
                }
                if (nodeConn)
                {
                    boolCount++;
                }
            }
            if (boolCount == nodes.Count)
            {
                Console.WriteLine("every node is connected");
                return true;
            }
            Console.WriteLine("not every node is connected");
            return false;
        }


    }
}
