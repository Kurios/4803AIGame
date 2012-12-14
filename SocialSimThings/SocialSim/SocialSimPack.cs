using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Agents;
using SocialSim.GameStuff;
using SocialSim.Knowledgebases;
using SocialSim.Networks;
using SocialSim.Testing;

namespace SocialSim
{
   public class SocialSimPack
    {
        public KB_C CKB;
        public KB_S SKB;
        public List<SocialFact> socialFacts;
        public List<SocialGame> games;
        public SocialNetworkList networks;

        public SocialSimPack()
        {
            initialize();
        }

        #region Initialization
        private void initializeKBs()
        {
            //Initialize the C_KB
            CKB = new KB_C();
            //Initialize the S_KB
            SKB = new KB_S();
            
        }

        public void initialize()
        {
            initializeKBs();    //Initializes the Cultural knowledgebase and Social knowledgebases
            initializeGames();  //Initializes the games
            networks = initializeNetworks(initializeAgents());  //Initializes the networks
        }

        private void initializeGames()
        {
            //List of social games that can be played
            games = new List<SocialGame>();

            //Get all topics
            foreach (Topic t in CKB.TopicList)
            {
                foreach (Subject s in t.Subjects)
                {
                    SocialGame game = new SocialGame(s,0.11f,0.11f,0.01f);
                    games.Add(game);
                }
            }
            //Cave, Girl, Player, Party, Festival, Games, Gifts, Flowers, Forest, Ghosts, Mushrooms
        }

        private List<Agent> initializeAgents()
        {

            List<Agent> agents = new List<Agent>();
            Agent agent0 = new Agent("Player", 0.2f, -0.1f, 0.25f);
            Agent agent1 = new Agent("Character",0.25f,-0.1f,0.25f);
            Agent agent2 = new Agent("Agent 2", 0.1f, 0.1f, 0.1f);
            Agent agent3 = new Agent("Agent 3");
            Agent agent4 = new Agent("Agent 4");
            Agent agent5 = new Agent("Agent 5");
            Agent agent6 = new Agent("Agent 6");


            agents.Add(agent0);
            agents.Add(agent1);
            agents.Add(agent2);
            agents.Add(agent3);
            agents.Add(agent4);
            agents.Add(agent5);
            agents.Add(agent6);

            return agents;
        }

        private SocialNetworkList initializeNetworks(List<Agent> agens)
        {
            SocialNetworkList networkList = new SocialNetworkList();
            //networks = new SocialNetworkList();

            SocialNetwork sadNetwork = new SocialNetwork(CKB.TopicList[0]);
            SocialNetwork scaryNetwork = new SocialNetwork(CKB.TopicList[1]);
            SocialNetwork funNetwork = new SocialNetwork(CKB.TopicList[2]);
            SocialNetwork friendlyNetwork = new SocialNetwork(CKB.TopicList[3]);

            sadNetwork.generateNetwork(initializeAgents());

            scaryNetwork.generateNetwork(initializeAgents());
            
            funNetwork.generateNetwork(initializeAgents());
            
            friendlyNetwork.generateNetwork(agens);

            networkList.addSocialNetwork(sadNetwork);
            networkList.addSocialNetwork(scaryNetwork);
            networkList.addSocialNetwork(funNetwork);
            networkList.addSocialNetwork(friendlyNetwork);

            return networkList;
        }

        #endregion

    }
}
