using System;
using System.Collections.Generic;

namespace KLib.NerualNet
{
    public class LinkNode
    {
        public Node Node;
        public double Value;

        public LinkNode(Node node, double value)
        {
            this.Node = node;
            this.Value = value;
        }
    }

    public class Node
    {
        protected double value = 0;

        private LinkedList<LinkNode> children;

        private string name;

        private int tick = -1;

        public Node()
        {
        }

        public Node(String name)
        {
            this.name = name;
            children = new LinkedList<LinkNode>();
        }

        public string Name { get { return name; } }

        public double Value { get { return value; } }

        /** This is the most primitive type of node. It is the weight of its children, weighted by the assigned weight */

        public virtual double update(int tick)
        {
            if (tick != this.tick)
            {
                this.tick = tick;
                this.value = 0;
                if (children.Count > 0)
                {
                    foreach (LinkNode child in children)
                    {
                        this.value += child.Value * child.Node.update(tick); ;
                    }
                }
                else
                {
                    throw new Exception("Nerual Network Node has no children");
                }
            }
            return value;
        }
    }

    /* Wrapper for the Node/Value pairs */
}