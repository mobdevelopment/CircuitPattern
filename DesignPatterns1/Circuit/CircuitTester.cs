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
        private static CircuitTester instance;
        public static CircuitTester Instance()
        {
            if (instance == null)
                instance = new CircuitTester();
            return instance;
        }

        private CircuitTester()
        {
        }

        public Boolean CircuitTest(Dictionary<String, Node> nodes)
        {
            bool floodTest = FloodFill(nodes);

            bool connectTest = NodeConnection(nodes);

            if(floodTest && connectTest)
            {
                Console.WriteLine("CircuitTest:: TRUE");
                return true;
            }
            Console.WriteLine("CircuitTest:: FALSE");
            return false;
        }

        public Boolean FloodFill(Dictionary<String, Node> nodes)
        {
            int visit = nodes.Count();
            while (visit > 0)
            {
                int impossibleCircuit = visit;
                foreach (KeyValuePair<String, Node> node in nodes)
                {
                    if (!node.Value.Visited)
                    {
                        List<Node> prevNodes = node.Value.getPrevious();
                        List<Node> nextNodes = node.Value.getNext();

                        if (prevNodes.Count > 0)
                        {
                            int prevVisitCount = 0;
                            foreach (Node _pNode in prevNodes)
                            {
                                if (_pNode.Visited)
                                {
                                    prevVisitCount++;
                                }
                            }
                            if (prevVisitCount == prevNodes.Count)
                            {
                                visit--;
                                node.Value.Visited = true;
                                Console.WriteLine(node.Key + ":: is visited");

                                foreach (Node _nNode in nextNodes)
                                {
                                    if (_nNode.Visited)
                                    {
                                        Console.WriteLine("FloodFill:: FALSE");
                                        return false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            visit--;
                            Console.WriteLine(node.Key + ":: is visited");
                            node.Value.Visited = true;
                        }
                    }
                }
                if (impossibleCircuit == visit)
                {
                    // nodes are not reachable
                    Console.WriteLine("FLOODFILL:: FALSE");
                    return false;
                }
            }
            Console.WriteLine("FloodFill:: TRUE");
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
                Console.WriteLine("NodeConnection:: TRUE");
                return true;
            }
            Console.WriteLine("NodeConnection:: FALSE");
            return false;
        }
    }
}
