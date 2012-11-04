﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLib.NerualNet.emotionState
{
    class HighSpace
    {
        /*
         * 
         * 
         * Affection Anger Angst Anguish Annoyance Anxiety Apathy Arousal Awe Boredom Contempt Contentment Courage Curiosity Depression Desire Despair Disappointment Disgust Distrust Dread Ecstasy Embarrassment Envy Euphoria Excitement Fear Frustration Gratitude Grief Guilt Happiness Hatred Hope Horror Hostility Hurt Hysteria Indifference Interest Jealousy Joy Loathing Loneliness Love Lust Outrage Panic Passion Pity Pleasure Pride Rage Regret Remorse Sadness Satisfaction Shame Shock Shyness Sorrow Suffering Surprise Terror Trust Wonder Worry Zeal Zest
         */

        class HigherEmotions
        {
            bool Affection;
            eSpace AffectionSpace = new eSpace(0,0,0,1,0,.5,0,0);
            bool Anger;
            eSpace AngerSpace = new eSpace(0, 1, 0, 0, 0, 0, 0, 0);
            bool Angst;
            eSpace AngstSpace = new eSpace(.5, .5, .5, 0, .5, 0, 0, 0);
            bool Anguish;
            eSpace AnguishSpace = new eSpace(0, 0, 1, 0, .5, 0, .2, 0);
            bool Annoyance;
            eSpace AnnoyanceSpace = new eSpace(0, 0, 0, 0, .7, 0, .5, 0);
            bool Anxiety;
            eSpace AnexietySpace = new eSpace(.5, 0, 0, 0, 0, 0, .5, 0);
            bool Apathy;
            eSpace ApathySpace = new eSpace(0, 0, 0, 0, 0, 0, 0, 0);
            bool Arousal;
            eSpace ArousalSpace = new eSpace(0, 0, 0, 0, -1, 0, .25, 0);
            bool Awe;
            eSpace AweSpace = new eSpace(.75, 0, 0, 0, 0, 0, .75, 0);
            bool Boredom;
            eSpace BoredomSpace = new eSpace(0, 0, 0, 0, 0, 0, -1, -1);
            bool Contempt;
            eSpace ContemptSpace = new eSpace(0, 0, 0, -.25, .75, 0, 0, 0);
            bool Contentment;
            eSpace ContentmentSpace = new eSpace(-.25,-.25,-.5,.5,0,0,0,0);
            bool Courage;
            eSpace CourageSpace = new eSpace(-.25,0,0,0,0,0,1,0);
            bool Curiosity;
            //eSpace Curiosity = new eSpace(
            bool Depression;
            bool Desire;
            bool Despair;
            bool Disappointment;
            bool Disgust;
            bool Distrust;
            bool Dread;
            bool Ecstasy;
            bool Embarrassment;
            bool Envy;
            bool Euphoria;
            bool Excitement;
            bool Fear;
            bool Frustration;
            bool Gratitude;
            bool Grief;
            bool Guilt;
            bool Happiness;
            bool Hatred;
            bool Hope;
            bool Horror;
            bool Hostility;
            bool Hurt;
            bool Hysteria;
            bool Indifference;
            bool Interest;
            bool Jealousy;
            bool Joy;
            bool Loathing;
            bool Loneliness;
            bool Love;
            bool Lust;
            bool Outrage;
            bool Panic;
            bool Passion;
            bool Pity;
            bool Pleasure;
            bool Pride;
            bool Rage;
            bool Regret;
            bool Remorse;
            bool Sadness;
            bool Satisfaction;
            bool Shame;
            bool Shock;
            bool Shyness;
            bool Sorrow;
            bool Suffering;
            bool Surprise;
            bool Terror;
            bool Trust;
            bool Wonder;
            bool Worry;
            bool Zeal;
            bool Zest;
        }
    }
}