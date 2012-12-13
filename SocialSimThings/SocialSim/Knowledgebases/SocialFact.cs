using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Agents;
using SocialSim.GameStuff;

namespace SocialSim.Knowledgebases
{
    //A Social Fact is a fact that is added to the Social knowledgebase.


    //Social Game (What game was enacted)
    //Initiator - Who initiated the game (Conversation)
    //Target - To whom is the target of the game (Conversation)
    //Third-Party (List of Agents affected)

    class SocialFact
    {
        public SocialGame gamePlayed;   //Social game that was played
        public Agent Initiator; //Initiator
        public Agent Target;    //Target
        public List<Agent> ThirdPartyAgents;    //Who else was affected

        #region Constructors
        public SocialFact()
        {
            Initiator = new Agent();
            Target = new Agent();
            ThirdPartyAgents = new List<Agent>();
        }

        public SocialFact(SocialGame game, Agent ini, Agent tar)
        {
            gamePlayed = game;
            Initiator = ini;
            Target = tar;
            ThirdPartyAgents = new List<Agent>();
        }

        public SocialFact(SocialGame game, Agent ini, Agent tar, List<Agent> thirdParty)
        {
            gamePlayed = game;
            Initiator = ini;
            Target = tar;
            ThirdPartyAgents = thirdParty;
        }
        #endregion

        #region Methods



        #endregion 
    }
}
