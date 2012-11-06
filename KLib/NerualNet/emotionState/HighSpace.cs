using System;

namespace KLib.NerualNet.emotionState
{
    internal class HighSpace
    {
        /*
         *
         *
         * Affection Anger Angst Anguish Annoyance Anxiety Apathy Arousal Awe Boredom Contempt Contentment Courage Curiosity Depression Desire Despair Disappointment Disgust Distrust Dread Ecstasy Embarrassment Envy Euphoria Excitement Fear Frustration Gratitude Grief Guilt Happiness Hatred Hope Horror Hostility Hurt Hysteria Indifference Interest Jealousy Joy Loathing Loneliness Love Lust Outrage Panic Passion Pity Pleasure Pride Rage Regret Remorse Sadness Satisfaction Shame Shock Shyness Sorrow Suffering Surprise Terror Trust Wonder Worry Zeal Zest
         */
        internal LowState lowerState;

        public HighSpace(LowState lowerState)
        {
            this.lowerState = lowerState;
        }

        public void addEmotion(Emotion emotion, double weight)
        {
            eSpace space = new eSpace();

            switch (emotion)
            {
                case Emotion.Disgust: space.Disgust = 2; break;
                case Emotion.Apathy: space.Anticipation = -1; break;
                case Emotion.Joy: space.Joy = 2; break;
                case Emotion.Anticipation: space.Anticipation = 2; break;
                case Emotion.Trust: space.Trust = 2; break;
                case Emotion.Surprise: space.Supprise = 2; break;
                case Emotion.Fear: space.Fear = 2; break;
                case Emotion.Anger: space.Anger = 2; break;
                case Emotion.Sadness: space.Sadness = 2; break;
                case Emotion.Rage: space.Anger = 1; space.Disgust = 1; space.Joy = -1; break;
                case Emotion.Hope: space.Trust = 1; space.Joy = 1; space.Anticipation = 1; space.Fear = -1; break;
                case Emotion.Panic: space.Trust = -1; space.Anticipation = -1; space.Disgust = 1; break;
                case Emotion.Pride: space.Trust = 1; space.Joy = 1; space.Sadness = -1; break;

                default: throw new Exception(emotion.ToString() + " is not implemented. Please add it to KLib/NeuralNetwork/emotionState/HighSpace.addEmotion()");
            }

            lowerState.pass(space, weight);
        }

        private class HigherEmotions
        {
            private bool Affection;
            private eSpace AffectionSpace = new eSpace(0, 0, 0, 1, 0, .5, 0, 0);
            private eSpace AnexietySpace = new eSpace(.5, 0, 0, 0, 0, 0, .5, 0);
            private bool Anger;
            private eSpace AngerSpace = new eSpace(0, 1, 0, 0, 0, 0, 0, 0);
            private bool Angst;
            private eSpace AngstSpace = new eSpace(.5, .5, .5, 0, .5, 0, 0, 0);
            private bool Anguish;
            private eSpace AnguishSpace = new eSpace(0, 0, 1, 0, .5, 0, .2, 0);
            private bool Annoyance;
            private eSpace AnnoyanceSpace = new eSpace(0, 0, 0, 0, .7, 0, .5, 0);
            private bool Anxiety;
            private bool Apathy;
            private eSpace ApathySpace = new eSpace(0, 0, 0, 0, 0, 0, 0, 0);
            private bool Arousal;
            private eSpace ArousalSpace = new eSpace(0, 0, 0, 0, -1, 0, .25, 0);
            private bool Awe;
            private eSpace AweSpace = new eSpace(.75, 0, 0, 0, 0, 0, .75, 0);
            private bool Boredom;
            private eSpace BoredomSpace = new eSpace(0, 0, 0, 0, 0, 0, -1, -1);
            private bool Contempt;
            private eSpace ContemptSpace = new eSpace(0, 0, 0, -.25, .75, 0, 0, 0);
            private bool Contentment;
            private eSpace ContentmentSpace = new eSpace(-.25, -.25, -.5, .5, 0, 0, 0, 0);
            private bool Courage;
            private eSpace CourageSpace = new eSpace(-.25, 0, 0, 0, 0, 0, 1, 0);
            private bool Curiosity;

            //eSpace Curiosity = new eSpace(
            private bool Depression;

            private bool Desire;
            private bool Despair;
            private bool Disappointment;
            private bool Disgust;
            private bool Distrust;
            private bool Dread;
            private bool Ecstasy;
            private bool Embarrassment;
            private bool Envy;
            private bool Euphoria;
            private bool Excitement;
            private bool Fear;
            private bool Frustration;
            private bool Gratitude;
            private bool Grief;
            private bool Guilt;
            private bool Happiness;
            private bool Hatred;
            private bool Hope;
            private bool Horror;
            private bool Hostility;
            private bool Hurt;
            private bool Hysteria;
            private bool Indifference;
            private bool Interest;
            private bool Jealousy;
            private bool Joy;
            private bool Loathing;
            private bool Loneliness;
            private bool Love;
            private bool Lust;
            private bool Outrage;
            private bool Panic;
            private bool Passion;
            private bool Pity;
            private bool Pleasure;
            private bool Pride;
            private bool Rage;
            private bool Regret;
            private bool Remorse;
            private bool Sadness;
            private bool Satisfaction;
            private bool Shame;
            private bool Shock;
            private bool Shyness;
            private bool Sorrow;
            private bool Suffering;
            private bool Surprise;
            private bool Terror;
            private bool Trust;
            private bool Wonder;
            private bool Worry;
            private bool Zeal;
            private bool Zest;
        }
    }
}