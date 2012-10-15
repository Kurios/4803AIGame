using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLib.NerualNet
{
    public class NNetwork
    {

        public LinkedList<Node> Nodes = new LinkedList<Node>();
        public LinkedList<Node> Outputs = new LinkedList<Node>();

        int lastTick = 0;

        public NNetwork()
        {
        }

        public void update()
        {
            foreach (Node node in Outputs)
            {
                node.update(lastTick);
                lastTick++;
            }
        }
    }
}
