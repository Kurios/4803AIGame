using System;

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

        private HighSpace highSpace;
        private LowState lowState;
        private Memory memory = new Memory();

        public EmotionState()
        {
            lowState = new LowState(memory);
            highSpace = new HighSpace(lowState);
        }

        public EmotionState(eSpace initSpace)
            : this()
        {
            memory.ESpace = initSpace;
        }

        /***
         * Stability... a normal amount is really really small... think like .000002 small
         */

        public eSpace eSpace
        {
            get { return lowState.eSpace; }
        }

        public void addEmotion(Emotion emotion, int p)
        {
            highSpace.addEmotion(emotion, p);
        }

        public void addEmotion(emotionState.eSpace espace, int p)
        {
            lowState.pass(espace, p);
        }

        public void enact()
        {
            throw new NotImplementedException();
        }

        public void ponder()
        {
            lowState.cycle();
        }

        public void setStability(double stability)
        {
            lowState.setStability(stability);
        }
    }
}