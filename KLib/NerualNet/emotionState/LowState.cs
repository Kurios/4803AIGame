using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLib.NerualNet.emotionState
{
    class LowState
    {
        double OldMemoryWeight = 100;
        eSpace LowRepresentation = new eSpace();
        eSpace SumRepresentation = new eSpace();
        double weights = 0;

        public eSpace eSpace {
         get {return LowRepresentation;}
        }

        private Memory mem;
        //Hmmm... we need a unit of time or something to work with...
        public LowState(Memory m)
        {
            mem = m;
            weights = OldMemoryWeight;
        }

        public object pass(eSpace space, double weight)
        {
            weights += weight;
            eSpace temp = space.Subtract(mem.ESpace);
            temp.iMultiply(weight);
            SumRepresentation.iAdd( temp );


            return null;
        }
        public void cycle()
        {
            double memoryChangeFactor = .02;
            weights = 0 + OldMemoryWeight;
            double weightOldMem = OldMemoryWeight / weights;
            double weightsOther = OldMemoryWeight - 1;
            SumRepresentation.iMultiply(weightsOther);
            LowRepresentation.iMultiply(weightOldMem);
            LowRepresentation.Add(SumRepresentation);
            SumRepresentation = new eSpace();

            mem.ESpace.iMultiply(1 - memoryChangeFactor);
            mem.ESpace.iAdd(LowRepresentation.Multiply(memoryChangeFactor));

        }
        public object send(eSpace space, double weight)
        {
            return null;
        }
    }
}
