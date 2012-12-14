using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Agents;
using SocialSim.Knowledgebases;
using SocialSim.Knowledgebases;

namespace SocialSim.GameStuff
{
    public class SocialGame
    {

        public Subject gameType;   //The subject that pertains to the game.  What type of game is being played (What subject is being talked about?)


        public float curiosityThreshold;
        public float comfortThreshold;

        public float comfortOffsets;
        public float considerationOffsets;
        public float curiosityOffsets;

        List<String> actorScript;   //What the actor says.
        List<String> targetScript;  //What the target says.

        //A list of conditions that must be met.

        #region Constructors

        public SocialGame(Subject typeOfGame)
        {
            gameType = typeOfGame;
            comfortThreshold = 0;
            //considerationThreshold = 0;
            curiosityThreshold = 0;
            comfortOffsets = 0;
            considerationOffsets = 0;
            curiosityOffsets = 0;

        }

        public SocialGame(Subject typeOfGame, float comfortThresh, float curiosityThresh)
        {
            gameType = typeOfGame;
            comfortThreshold = comfortThresh;
            curiosityThreshold = curiosityThresh;
            comfortOffsets = 0;
            considerationOffsets = 0;
            curiosityOffsets = 0;
        }

        public SocialGame(Subject typeOfGame, float comfort, float consideration, float curiosity)
        {
            gameType = typeOfGame;
            comfortOffsets = comfort;
            considerationOffsets = consideration;
            curiosityOffsets = curiosity;
        }


        #endregion

        #region Methods



        #region Script Methods
        #endregion


        #endregion
    }
}
