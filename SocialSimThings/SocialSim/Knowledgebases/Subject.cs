using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialSim.Knowledgebases
{
    public enum SubjectType
    {
        Cave, Girl, Player, Party, Festival, Games, Gifts, Flowers, Forest, Ghosts, Mushrooms
    }

    class Subject
    {
        public SubjectType SubjectName;
        public float comfortThreshold;
        public float considerationThreshold;
        public float curiosityThreshold;

        #region Constructors
        public Subject()
        {
            SubjectName = SubjectType.Cave;
            comfortThreshold = 0;
            considerationThreshold = 0;
            curiosityThreshold = 0;
        }
  

        public Subject(SubjectType s)
        {
            SubjectName = s;
            comfortThreshold = 0;
            considerationThreshold = 0;
            curiosityThreshold = 0;
        }

        public Subject(SubjectType s, float comfort, float consideration, float curiosity)
        {
            SubjectName = s;

            comfortThreshold = comfort;
            considerationThreshold = consideration;
            curiosityThreshold = curiosity;
        }
        #endregion

    }

}
