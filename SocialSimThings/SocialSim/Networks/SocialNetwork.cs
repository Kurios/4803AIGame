using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Agents;
using SocialSim.Knowledgebases;

namespace SocialSim.Networks
{
    public class SocialNetwork
    {
        public Topic TopicOfNetwork;    //The topic that is relevant to the social network
        public List<SocialPair> allPairs;   //The list of pairs

        #region Constructors

        public SocialNetwork(Topic t)
        {
            TopicOfNetwork = t;
            allPairs = new List<SocialPair>();
        }

        #endregion

        #region Methods

        public void generateNetwork(List<Agent> allAgents)
        {
            for (int firstIndex = 0; firstIndex < allAgents.Count-1; firstIndex++)
            {
                for (int secIndex = firstIndex + 1; secIndex < allAgents.Count; secIndex++)
                {
                    SocialPair pair = new SocialPair(allAgents[firstIndex], allAgents[secIndex]);
                    allPairs.Add(pair);
                }
            }
        }

        public SocialPair getPair(Agent A, Agent B)
        {
            foreach (SocialPair pair in allPairs)
            {
                if ((pair.AgentA.name.Equals(A.name) && pair.AgentB.name.Equals(B.name)) || (pair.AgentA.name.Equals(B.name) && pair.AgentB.name.Equals(A.name)))
                {
                    return pair;
                }
            }
            return null;
        }
        #endregion

        #region Test Methods

        public void printAllPairs()
        {
            foreach (SocialPair pair in allPairs)
            {
                Agent A = pair.AgentA;
                Agent B = pair.AgentB;

                Console.WriteLine("Agent A: " + A.name + " Agent B: " + B.name);
            }

            Console.ReadKey();
        }
        #endregion
    }
}
