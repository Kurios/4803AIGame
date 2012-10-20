using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLib.NerualNet.emotionState
{
    /*
     * An emotionspace is a mapping of the emotional... octet?
     * Think of it as a fancy, 8-dimentional Vector, where we target the range -1 to 1 for each double.
     */
    class eSpace
    {
        public Double Fear = 0;
        public Double Anger = 0;
        public Double Sadness = 0;
        public Double Joy = 0;
        public Double Disgust = 0;
        public Double Trust = 0;
        public Double Anticiation = 0;
        public Double Supprise = 0;

        /*
        * Current notes and thoughts about emotions... Everything trends to zero... so we should have a magnitude of the eSpace to track how it trends...
        * That determines the "velocity" of the emotions to return to a neutral state... and a Normal, so we affect the correct axis? Maybe?
         * 
         * 
         * But the Magnitude does represent how "emotional" the subject is... 
         * 
         * Heh, as a side effect, that could possibly cause mood swings...
         *                          -Kurios
        */

        public double Magnitude()
        {
            return Fear * Anger * Sadness * Joy * Disgust * Trust * Anticiation * Supprise;
        }
    }


}
