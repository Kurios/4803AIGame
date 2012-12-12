using System.Collections.Generic;

namespace KLib.NerualNet
{
    public class NNetwork
    {
        public LinkedList<Node> Nodes = new LinkedList<Node>();
        public LinkedList<Node> Outputs = new LinkedList<Node>();

        private int lastTick = 0;

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