using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.GameStuff;
using SocialSim.Agents;

namespace SocialSim.Knowledgebases
{
    //KEEP TRACK OF THE FOLLOWING:
    
    //ENVIRONMENTAL

    //ENVIRONMENT
        //Current state of the environment.
        //List of events that transpired in chronological order. (Social Facts)

    //NETWORKS
        //Social Network of agents
    public class KB_S
    {
        List<SocialFact> events;

        #region Constructors
        public KB_S()
        {
            events = new List<SocialFact>();
        }
        #endregion

        #region Methods

        
        public void addNewFact(SocialFact latestEvent)
        {
            events.Add(latestEvent);
        }

           //Search for a particular event.
                //Search by agent

        //Search by agent
        public List<SocialFact> getSocialFactsByAgent(Agent thisAgent)
        {
            List<SocialFact> factsFound = new List<SocialFact>();
            foreach (SocialFact sf in events)
            {
                if (sf.Initiator.name.Equals(thisAgent.name) || sf.Target.name.Equals(thisAgent.name))
                {
                    factsFound.Add(sf);
                }
            }
            return factsFound;
        }

        //Get social facts based on interactions specifically for these two agents.  Great for looking for old agent interaction beforehand.
        public List<SocialFact> getSocialFactsByPair(Agent agent1, Agent agent2)
        {
            List<SocialFact> factsFound = new List<SocialFact>();
            foreach (SocialFact sf in events)
            {
                if ((sf.Initiator.name.Equals(agent1.name) && sf.Target.name.Equals(agent2.name)) || (sf.Initiator.name.Equals(agent2.name) && sf.Target.name.Equals(agent1.name)))
                {
                    factsFound.Add(sf);
                }
            }
            return factsFound;
        }

        //Search by subject
        public List<SocialFact> getSocialFactsBySubject(Subject bySubject)
        {
            List<SocialFact> factsFound = new List<SocialFact>();
            foreach (SocialFact sf in events)
            {
                if (sf.gamePlayed.gameType.SubjectName.Equals(bySubject.SubjectName))
                {
                    factsFound.Add(sf);
                }
            }
            return factsFound;
        }

                //Search by game
        #endregion
    }
}
