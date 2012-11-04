using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLib.NerualNet.emotionState
{
    class LowState
    {
        double OldMemoryWeight = 200;
        eSpace LowRepresentation = new eSpace();
        eSpace SumRepresentation = new eSpace();
        double weights = 0;

        public eSpace eSpace {
         get {return mem.ESpace;}
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
            //Console.WriteLine("memory cycle");
            double memoryChangeFactor = .0002;
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
        public object send(eSpace space, double weight)
        {
            return null;
        }
    }
}
