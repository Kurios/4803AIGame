using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KLib.NerualNet.emotionState;

namespace KLib.NerualNet
{
    class Memory
    {
        public eSpace ESpace { get; set; }

        public Memory()
        {
            ESpace = new eSpace();
        }
    }
}
