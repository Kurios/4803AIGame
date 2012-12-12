using KLib.NerualNet.emotionState;

namespace KLib.NerualNet
{
    internal class Memory
    {
        public Memory()
        {
            ESpace = new eSpace();
        }

        public eSpace ESpace { get; set; }
    }
}