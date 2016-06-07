using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;

namespace DesignPatterns1.Nodes
{
    public abstract class Node : ICloneable, IGetKey<String>
    {
        protected List<Node> previous = new List<Node>();
        protected List<Node> next = new List<Node>();
        protected int counter = 0;
        protected int value = 0;

        protected Node()
        {
        }

        public static Node create(String name)
        {
            return FactoryMethod<String, Node>.create(name);
        }

        public abstract String getKey();

        public abstract object Clone();

        public abstract void show();
           
        public bool isCalculate(int rondecounter)
        {
            return counter >= rondecounter;
        }

        protected void addPrevious(Node node)
        {
            previous.Add(node);
        }

        public void addNext(Node node)
        {
            next.Add(node);
            node.addPrevious(this);
        }

        public void addNexts(List<Node> nodes)
        {
            foreach(Node node in nodes)
            {
                addNext(node);
            }
        }

        public int getValue()
        {
            return this.value;
        }

        public List<Node> getPrevious()
        {
            return previous;
        }

        public List<Node> getNext()
        {
            return next;
        }
    }
}
