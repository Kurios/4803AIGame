using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLib.NerualNet
{

    public class Listener : Node
    {
        public Listener() : base() {}

        public override double update(int tick)
        {
            return Value;
        }

        public void set(double value)
        {
            this.value = value;
        }
    }
}
