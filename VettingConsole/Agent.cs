using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KLib.Language;
using KLib.NerualNet;
using KLib.NerualNet.emotionState;
using KLib.NerualNet.Intellengence;
using KLib.NerualNet.Conditioning;

namespace VettingConsole
{
    class Agent
    {
        Language language = new Language();
        EmotionState emotionState = new EmotionState();
        Intellegence intellegence = new Intellegence();
        Conditioning conditioning = new Conditioning();

        public Agent()
        {
            intellegence.addEmotions(emotionState);
            intellegence.addConditioning(conditioning);
            conditioning.addEmotions(emotionState);

        }

        /*
         * Maybe Im going a bit crazy and overboard, but... just a random thought... When we hear a phrase,
         * the first thing we do is react to it on an emotional level... And im sure theres alot of things going
         * on here in parallel... but still... emotional response, then it gets tempered or exasterbated with conditioning...
         * before we deal with it rationally... So maybe, we as humans, work from the irrational -> rational?
         * 
         * And maybe I need to bias to the irrational...
         * 
         * And as far as intellegnce upon listening? Rationallity takes time. And its a seperate call... This is for the intantanious.
         *                      -Kurios, 10/15/2012
         */

        internal void listen(string line)
        {
            language.parse(line);
            emotionState.ponder();
            conditioning.check();
            emotionState.enact();
        }

        internal string respond()
        {
            throw new NotImplementedException();
        }

        internal bool hasResonse()
        {
            throw new NotImplementedException();
        }
    }
}
