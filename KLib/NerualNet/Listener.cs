namespace KLib.NerualNet
{
    public class Listener : Node
    {
        public Listener()
            : base()
        {
        }

        public void set(double value)
        {
            this.value = value;
        }

        public override double update(int tick)
        {
            return Value;
        }
    }
}