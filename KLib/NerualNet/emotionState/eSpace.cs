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
    public class eSpace
    {
        public Double Fear = 0;
        public Double Anger = 0;
        public Double Sadness = 0;
        public Double Joy = 0;
        public Double Disgust = 0;
        public Double Trust = 0;
        public Double Anticipation = 0;
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

        public eSpace()
        {
        }

        public eSpace(double Fear, double Anger, double Sadness, double Joy, double Disgust, double Trust, double Anticipation, double Supprise)
        {
            this.Fear = Fear;
            this.Anger = Anger;
            this.Sadness = Sadness;
            this.Joy = Joy;
            this.Disgust = Disgust;
            this.Trust = Trust;
            this.Anticipation = Anticipation;
            this.Supprise = Supprise;
        }

        public double Magnitude()
        {
            return Fear * Anger * Sadness * Joy * Disgust * Trust * Anticipation * Supprise;
        }

        internal eSpace Magnified()
        {
            eSpace ret = new eSpace();
            double mag = Magnitude();
            ret.Fear = Fear * mag;
            ret.Anger = Anger * mag;
            ret.Sadness = Sadness * mag;
            ret.Joy = Joy * mag;
            ret.Disgust = Disgust * mag;
            ret.Trust = Trust * mag;
            ret.Anticipation = Anticipation * mag;
            ret.Supprise = Supprise * mag;
            return ret;
        }

        internal eSpace Magnified(double secondary)
        {
            eSpace ret = new eSpace();
            double mag = Magnitude();
            ret.Fear = Fear * mag * secondary;
            ret.Anger = Anger * mag * secondary;
            ret.Sadness = Sadness * mag * secondary;
            ret.Joy = Joy * mag * secondary;
            ret.Disgust = Disgust * mag * secondary;
            ret.Trust = Trust * mag * secondary;
            ret.Anticipation = Anticipation * mag * secondary;
            ret.Supprise = Supprise * mag * secondary;
            return ret;
        }

        internal eSpace Multiply(double secondary)
        {
            eSpace ret = new eSpace();
            ret.Fear = Fear * secondary;
            ret.Anger = Anger * secondary;
            ret.Sadness = Sadness * secondary;
            ret.Joy = Joy * secondary;
            ret.Disgust = Disgust * secondary;
            ret.Trust = Trust * secondary;
            ret.Anticipation = Anticipation * secondary;
            ret.Supprise = Supprise * secondary;
            return ret;
        }

        internal void iMultiply(double secondary)
        {
            Fear = Fear * secondary;
            Anger = Anger * secondary;
            Sadness = Sadness * secondary;
            Joy = Joy * secondary;
            Disgust = Disgust * secondary;
            Trust = Trust * secondary;
            Anticipation = Anticipation * secondary;
            Supprise = Supprise * secondary;
        }

        internal eSpace Subtract(eSpace espace)
        {
            eSpace ret = new eSpace();
            ret.Fear = Fear - espace.Fear;
            ret.Anger = Anger - espace.Anger;
            ret.Sadness = Sadness - espace.Sadness;
            ret.Joy = Joy - espace.Joy;
            ret.Disgust = Disgust - espace.Disgust;
            ret.Trust = Trust - espace.Trust;
            ret.Anticipation = Anticipation - espace.Anticipation;
            ret.Supprise = Supprise - espace.Supprise;
            return ret;
        }

        internal eSpace Add(eSpace espace)
        {
            eSpace ret = new eSpace();
            ret.Fear = Fear + espace.Fear;
            ret.Anger = Anger + espace.Anger;
            ret.Sadness = Sadness + espace.Sadness;
            ret.Joy = Joy + espace.Joy;
            ret.Disgust = Disgust + espace.Disgust;
            ret.Trust = Trust + espace.Trust;
            ret.Anticipation = Anticipation + espace.Anticipation;
            ret.Supprise = Supprise + espace.Supprise;
            return ret;
        }

        internal void iAdd(eSpace espace)
        {
            Fear = Fear + espace.Fear;
            Anger = Anger + espace.Anger;
            Sadness = Sadness + espace.Sadness;
            Joy = Joy + espace.Joy;
            Disgust = Disgust + espace.Disgust;
            Trust = Trust + espace.Trust;
            Anticipation = Anticipation + espace.Anticipation;
            Supprise = Supprise + espace.Supprise;
        }

        internal eSpace Copy()
        {
            throw new NotImplementedException();
        }
    }


}
