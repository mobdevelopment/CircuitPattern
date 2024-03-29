﻿using DesignPatterns1.Nodes;
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

        public CircuitTester()
        {
        }

        public Boolean CircuitTest(Dictionary<String, Node> nodes)
        {
            // floodfill test
            bool floodTest = FloodFill(nodes);
            // connection test
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
            // check if the circuit doesn't contain dead ends or loops
            int visit = nodes.Count();
            while (visit > 0)
            {
                // counter for dead end and loops
                int impossibleCircuit = visit;
                foreach (KeyValuePair<String, Node> node in nodes)
                {
                    // if a node isn't already visited
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
                                // Shows the nodes which are visited
                                //Console.WriteLine(node.Key + ":: is visited");

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
                            // Shows the nodes which are visited
                            //Console.WriteLine(node.Key + ":: is visited");
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
            // check if all nodes are correctly connected to oneanother
            int boolCount = 0;
            foreach(KeyValuePair<String, Node> node in nodes)
            {
                node.Value.Name = node.Key;
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
