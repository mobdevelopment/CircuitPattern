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

        public void inputValue()
        {
            Console.WriteLine("Your Input Nodes need a value please enter a 0 or 1 followed by enter.");
            foreach (Node n in Nodes.Values)
            {

                if (n.getKey().Contains("INPUT"))
                {
                    Console.WriteLine("Enter a value for " + n.getKey() + ": ");
                    var dialog = new InputDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        int nVal = Convert.ToInt32(dialog.ResponseText);
                        if (nVal > 1)
                            n.Value = 0;
                        else
                            n.Value = nVal;
                    }
                }
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

        private void resetVisited()
        {
            foreach (Node node in Nodes.Values)
            {
                node.Visited = false;
            }
        }

        public void walk()
        {
            resetVisited();
            foreach (Node node in Nodes.Values)
            {
                if (node is Input) node.Visited = true; /*step(node);*/
                step(node);
                printCircuit();
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
            //Console.WriteLine("Step:: " + node.Name + " - " + node.getKey());

            foreach (Node next in node.getNext())
            {
                if (next is Calculatable && !next.isCalculated())
                {
                    Calculatable Next = (Calculatable)next;
                    if(Next.canCalculate())
                    {
                        Next.calculate();
                        Next.Visited = true;
                        //Console.WriteLine("Calculated: " + Next.Name + " - " + Next.getKey() + ", value = " + Next.Value + ", visited = " + Next.Visited);
                        step(Next);
                    }
                }
                else if (next is Output && node.isCalculated())
                {
                    next.Value = node.Value;
                    next.Visited = true;
                    //Console.WriteLine("Calculated: " + next.Name + " - " + next.getKey() + ", value = " + next.Value);
                }
            }
        }

        public void printCircuit()
        {
            foreach(Node node in Nodes.Values)
            {
                if ((node.isCalculated() || node is Probe) && node.Visited)
                {
                    Console.WriteLine("Node: " + node.Name + ", Type: " + node.getKey() + ", Value: " + node.Value);
                }
                else
                {
                    Console.WriteLine("Node: " + node.Name + ", Type: " + node.getKey() + ", Value: /");
                }
            }
            Console.WriteLine();
        }
    }
}
