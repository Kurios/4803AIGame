using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLib.NerualNet.emotionState
{
    public class EmotionState
    {
        /*
         * 
         * Emotion doesnt define action, emotion tempers our worldview, so we can define action itself.
         * 
         * In fact, it defines it such that our conditioning can function, and all doesnt fire at the same time...
         * 
         */

        Memory memory = new Memory();
        LowState lowState;
        HighSpace highSpace;

        public EmotionState()
        {
            lowState = new LowState(memory);
            highSpace = new HighSpace(lowState);
        }


        public eSpace eSpace
        {
            get { return lowState.eSpace; }
        }
        public void ponder()
        {
            lowState.cycle();
        }

        public void enact()
        {
            throw new NotImplementedException();
        }
        public void addEmotion(Emotion emotion, int p)
        {
            highSpace.addEmotion(emotion, p);
        }
        public void addEmotion(emotionState.eSpace espace, int p)
        {
            lowState.pass(espace, p);
        }
    }
}
