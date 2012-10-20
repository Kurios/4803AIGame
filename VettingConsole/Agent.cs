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
         *                      
         * The core of bieng is fefined by an eSpace and a MemSpace. These in themselves are filtered by our Emotions. They can play with the interpretation of the MemSpace and the Espace.
         * 
         * Our emotion space in and upon itself is nothing but a color filter. It flavors the output, blocks some, lets other through... but it makes no decisions on its own. 
         * How can it? It has no persistant memory, no rational. It is nothing. In and of itself, it is as boring as a vector. In fact, we could consider it as a vector, and I 
         * believe we would be jusitified.
         * 
         * However, we also combine these emotions to create new, higher level emotions. These are what the next level cares about.
         * 
         * The filtered MemorySpace is then piped to the Conditioning and Tempering level. This is where our emotional space is changed by training, learning. Think of it as the
         * subconcious. It happens. 
         * 
         * I would say it happens at two levels. The low level, where we start to define an emotion as a slightly more complicated idea. Trained emotion. Positive and negitive attributes to
         * these said emotions...
         * 
         * to pondering what would bring the most positive, and at the intellegnece level, planning long-term (thinking ahead).
         * 
         * 
         *     The Outside World
         *        ||     /\
         *        ||    /  \
         *       \  /    ||                   All input goes through our stack. And everything leaves via it.
         *        \/     ||
         * ------------------------------------------------------------------------------
         * Intel|  High |   -Goal Analysis and Setting
         *      |       |   -Picking actions based on goals (that are passed up from higher levels)...
         *      |       |   -Input selection. What do we consider, what does it mean?
         *      -----------------------------------
         *      |  Med  |   -Interpetation.
         *      |       |   -Thinking Ahead.
         *      |       |   -X is better then Y because
         *      -----------------------------------
         *      | Low   |   -I cannot do X and Y concerrently.
         *      |       |   -X will prevent Y.
         *      |       |   -Non-goal specific.
         *      |       |   -Intellegence that behaves like conditioning.
         *      |       |   ie: Sadness makes me drink beer. We throw out other options like confronting it.
         *      |       |   -Has some basis as a historical action
         *      |       |   -May be a wired memory response.
         * ----------------------------------------------------------Conditioning--- OCEAN focuses the on the subdivision of the condition layer.-----------
         * Condi| High  |  -It is right of me to do X
         *      |       |  -I should do |x|
         *      |       |  -Personality type actions
         *      |       |  -Cutural Type actions
         *      |       |  -Low level responses.
         *      ------------------------------------
         *      |  Mid  |  -Mapping Low level feelings to a potenial set of actions.
         *      |       |  -Relevance of actions.
         *      ------------------------------------
         *      | Low   |  -X is positive/Negitive.
         *      |       |  Relevance of emotions
         *      |       |  Having emotions override other emotions. Concurency checks.
         * ----------------------------------------------------------
         * Emoti| High  | -Mapping the eSpace to high level emotions
         *      |       | - Gives us a high level, binary type represntation of the eSpace.
         *      ------------------------------------------------------
         *      | Low   | Our eSpace itself. Also the color filter.
         * -----------------------------------------------------------
         *  Short Term Memory             |    Emotional Memory
         *      -     -        -   -      | -    -    -    -    -    -
         * Basic Ideas. Size Nonspecific  |    Basic Emotions. The current set as relevant to the Short term Memory
         * ----|----|---------|-------|---| 
         *  1  | 2  | 3  | 4  | 5 | 6 | 7 |
         * -v----v----v----v----v---v---v-|-------------------------------------\/----------
         * 
         *   Long Term Memories - Include attached eSpace for thought. 
         *   Used to determine if that set of actions was good or not... ie learning.
         *                               
         * 
         * 
         * As far as OCEAN, Just like there is a 8-d vector for emotions, effectively patitioning it into 8 segments.
         * 
         * 
         * Independant Aspects and Impletmentation Design.
         * 
         * Emotion up?
         * Importance  --------> --------> ---------> -------> -------->-------->------->------->-------->-----!Benchmark 1 ------!Benchmark 2-------> --------->----->---->-------->----->---->
         * 
         * Yah, eSpace -> emotions -> emotional relevance mapping -> action mapping -> action decision making -> task completion -> rescursive task analysis -> goal setting -> historical analysis
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
