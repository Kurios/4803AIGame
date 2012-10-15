using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLib.NerualNet
{
    public class Node
    {
        double value = 0;
        double Value { get { return value;} }
        LinkedList<LinkNode> children;
        string name;

        int tick = -1;
        string Name { get { return name; } }

        public Node(String name)
        {
            this.name = name;
            children = new LinkedList<LinkNode>();
        }

        /** This is the most primitive type of node. It is the weight of its children, weighted by the assigned weight */
        public double update(int tick)
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
}
