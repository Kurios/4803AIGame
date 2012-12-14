using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Knowledgebases;

namespace SocialSim.GameStuff
{
    public class GameChoice
    {

        //A Game Choice corresponds to a choice
        #region Parameters
        public Subject gameSubject;
        public String choiceName;
        public SocialGame game;

        //List of conditions that must be met.  
        #endregion 

        #region Constructors
        
        public GameChoice()
        {
        }

        public GameChoice(Subject s)
        {
            gameSubject = s;
            choiceName = "";
        }

        public GameChoice(Subject s, String choice)
        {
            gameSubject = s;
            choiceName = choice;
        }

        #endregion

        #region Methods

        //Enable or Disable choice?


        #endregion
    }
}
