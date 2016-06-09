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

        private static Circuit instance;
        public static Circuit Instance()
        {
            if (instance == null)
                instance = new Circuit();

            return instance;
        }

        private Circuit()
        {
            tester = CircuitTester.Instance();
        }

        private Dictionary<String, Node> _nodes;
        public Dictionary<String, Node> Nodes
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
            }
            else
            {
                return false;
            }
        }

        public void loadScreen()
        {
            foreach (KeyValuePair<string, Node> node in Nodes)
            {
                Console.WriteLine("onscreen:: " + node.Key);
            }
        }

        public void startCircuit()
        {
            walk();
            /*foreach (Node startPoint in Nodes.Values)
            {
                Type t = typeof(Input);
                if (!(startPoint is Input)) continue;

                Console.WriteLine(startPoint.getKey());
            }*/
        }

        public void walk()
        {
            foreach (Node node in Nodes.Values)
            {
                if (node is Input) step(node);
            }
        }

        private bool _validCircuit;
        public bool ValidCircuit
        {
            get
            {
                return _validCircuit;
            }
            set
            {
                _validCircuit = value;
            }
        }
        public void step(Node node)
        {
            while ((node.getPrevious().Count() > 0) || (node.getNext().Count() > 0))
            {
                if (!node.isCalculated() || node is Input)
                {
                    foreach (Node prev in node.getPrevious())
                    {
                        if (prev is Calculatable)
                        {
                            Calculatable Prev = (Calculatable) prev;
                            if (Prev.canCalculate())
                            {
                                Prev.calculate();
                                Console.WriteLine("Calculated: " + Prev.getKey());
                            }
                        }
                    }

                    foreach (Node next in node.getNext())
                    {
                        if (next is Calculatable)
                        {
                            Calculatable Next = (Calculatable)next;
                            if (Next.canCalculate())
                            {
                                Next.calculate();
                                Console.WriteLine("Calculated: " + Next.getKey());
                            }
                        }
                    }
                }
            }
            Console.WriteLine(Nodes);
        }
    }
}
