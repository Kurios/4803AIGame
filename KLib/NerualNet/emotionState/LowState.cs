namespace KLib.NerualNet.emotionState
{
    internal class LowState
    {
        private eSpace LowRepresentation = new eSpace();
        private Memory mem;
        private double memoryChangeFactor = .000002;
        private double OldMemoryWeight = 200;
        private eSpace SumRepresentation = new eSpace();
        private double weights = 0;

        //Hmmm... we need a unit of time or something to work with...
        public LowState(Memory m)
        {
            mem = m;
            weights = OldMemoryWeight;
        }

        public eSpace eSpace
        {
            get { return mem.ESpace; }
        }

        public void cycle()
        {
            //Console.WriteLine("memory cycle");
            double weightsOther = weights;
            weights = OldMemoryWeight + weights;

            double weightOldMem = OldMemoryWeight / weights;
            weightsOther = weightsOther / weights;

            SumRepresentation.iMultiply(weightsOther);
            LowRepresentation.iMultiply(weightOldMem);
            LowRepresentation.iAdd(SumRepresentation);

            SumRepresentation = new eSpace();
            weights = 0;

            mem.ESpace.iMultiply(1 - memoryChangeFactor);
            mem.ESpace.iAdd(LowRepresentation.Multiply(memoryChangeFactor));
        }

        public object pass(eSpace space, double weight)
        {
            weights += weight;
            eSpace temp = space.Subtract(mem.ESpace);
            temp.iMultiply(weight);
            SumRepresentation.iAdd(temp);
            return null;
        }

        public object send(eSpace space, double weight)
        {
            return null;
        }

        internal void setStability(double stability)
        {
            memoryChangeFactor = stability;
        }
    }
}