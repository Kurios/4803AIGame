using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Agents;
using SocialSim.GameStuff;

using SocialSim.Knowledgebases;

namespace SocialSim.Networks
{
    //A social pair is a linking between two agents.
    class SocialPair
    {
        public Agent AgentA;
        public Agent AgentB;

        public float curiosity;
        public float consideration;
        public float comfort;

        #region Constructors
        
        public SocialPair(Agent A, Agent B)
        {
            AgentA = A;
            AgentB = B;
            curiosity = A.curiosity - B.curiosity;
            consideration = A.consideration - B.consideration;
            comfort = A.comfort - B.comfort;
        }
        
        #endregion

        #region Methods

        public void update()
        {
            //Update the parameters of the two agents


        }

        public List<SocialGame> getPlayableGames(List<SocialGame> games)
        {
            List<SocialGame> gamesThatCanBePlayed = new List<SocialGame>();

            foreach (SocialGame game in games)
            {

                //if(game.gameType
                Console.WriteLine("Threshold: " + game.gameType.comfortThreshold + ", " + game.gameType.considerationThreshold + ", " + game.gameType.curiosityThreshold);
                if (game.gameType.comfortThreshold < this.comfort && game.gameType.considerationThreshold < this.consideration && game.gameType.curiosityThreshold < this.curiosity)
                {
                    gamesThatCanBePlayed.Add(game);
                }
            }
            return gamesThatCanBePlayed;
        }


        //Player agent and target agent engage in the game

        public void playGame(SocialGame game)
        {
            //Player and target interact between each other.  They just read two different scripts.

            //Based on statistics, conversation can change subtly.

            //Update values
            AgentA.comfort = AgentA.comfort + game.comfortOffsets;
            AgentA.consideration = AgentA.consideration + game.considerationOffsets;
            AgentA.curiosity = AgentA.curiosity + game.curiosityOffsets;
        }
        #endregion

        #region Test Methods
        #endregion
    }
}
