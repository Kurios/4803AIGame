using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Agents;
using SocialSim.GameStuff;
using SocialSim.Knowledgebases;
using SocialSim.Networks;

namespace SocialSim.Testing
{
    class TestMain
    {
        static KB_C CKB;
        static KB_S SKB;
        static List<SocialFact> socialFacts;
        static List<SocialGame> games;

        static void Main()
        {
            #region INITIALIZATION

           initializeKBs(); //Initializes the Knowledgebases
           initializeGames();   //Initializes all the games that can be played
           List<Agent> ages = initializeAgents();  //Initializes all the agents that will be in the game
           SocialNetworkList networks = initializeNetworks(ages);    //Initializes all networks for the game
           List<SocialFact> socialFacts = new List<SocialFact>();
            #endregion


            #region SOCIAL NETWORKS AND GAMEPLAY
 
            //SELECT A CHARACTER TO INTERACT WITH.
           SocialNetwork network1 = networks.socialNetworks[0];
           SocialPair sp = network1.getPair(ages[0], ages[1]);

           
            //RETRIEVES ALL PLAYABLE GAMES.
           List<SocialGame> playableGames = networks.getPlayableGames(sp, games);
           Console.WriteLine("NUMBER OF PLAYABLE GAMES: " + playableGames.Count);

           Console.WriteLine("BEFORE");
           Console.WriteLine("Agent A: (" + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp.AgentB.comfort + ", " + sp.AgentB.consideration + ", " + sp.AgentB.curiosity + ")");

           Console.WriteLine("");

            //SELECTS A PLAYABLE GAME.
           if (playableGames.Count > 0)
           {
               sp.playGame(playableGames[1], CKB.getTopic(playableGames[1].gameType).Name);
           }
           Console.WriteLine("AFTER");
           Console.WriteLine("Agent A: (" + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp.AgentB.comfort + ", " + sp.AgentB.consideration + ", " + sp.AgentB.curiosity + ")");

           Console.WriteLine("");

           Console.WriteLine("HOW ABOUT IN ANOTHER NETWORK?");
           SocialNetwork network2 = networks.socialNetworks[1];
           SocialPair sp2 = network2.getPair(ages[0], ages[1]);

           Console.WriteLine("Agent A: (" + sp2.AgentA.comfort + ", " + sp2.AgentA.consideration + ", " + sp2.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp2.AgentB.comfort + ", " + sp2.AgentB.consideration + ", " + sp2.AgentB.curiosity + ")");


           Console.WriteLine("");

           Console.WriteLine("HOW ABOUT WITH ANOTHER PAIR?");
           SocialPair sp3 = network1.getPair(ages[0], ages[2]);

           Console.WriteLine("Agent A: (" + sp3.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp3.AgentB.comfort + ", " + sp.AgentB.consideration + ", " + sp.AgentB.curiosity + ")");

           SocialFact sb = new SocialFact(playableGames[1], sp.AgentA, sp.AgentB);
           socialFacts.Add(sb);

           Console.WriteLine("DONE");

           Console.ReadKey();
            #endregion



            /*           #region SOCIAL NETWORKS

           SocialNetwork network1 = networks.socialNetworks[0];
           SocialPair sp = network1.getPair(agents[0], agents[1]);

           Console.WriteLine("SOCIAL PAIR: " + sp.AgentA.name + ", " + sp.AgentB.name);

           Console.WriteLine("GAMES: " + games.Count);

           List<SocialGame> playableGames = sp.getPlayableGames(games);
           Console.WriteLine("NUMBER OF PLAYABLE GAMES: " + playableGames.Count);


           //sp.playGame(playableGames[0], (CKB.getTopic(playableGames[0].gameType)).Name);//CKB.getTopic(playableGames[0].gameType.SubjectName));


           Console.WriteLine("Agent A: (" + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp.AgentB.comfort + ", " + sp.AgentB.consideration + ", " + sp.AgentB.curiosity + ")");

           foreach (SocialGame sg in playableGames)
           {
               sp.playGame(sg, (CKB.getTopic(sg.gameType)).Name);
           }

           Console.WriteLine("AFTER GAMES");
           Console.WriteLine("Agent A: (" + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp.AgentB.comfort + ", " + sp.AgentB.consideration + ", " + sp.AgentB.curiosity + ")");



           SocialPair sp2 = network1.getPair(agents[0], agents[2]);

           Console.WriteLine("IS THE AGENT STILL HERE?");
           Console.WriteLine("Agent A: (" + sp2.AgentA.comfort + ", " + sp2.AgentA.consideration + ", " + sp2.AgentA.curiosity + ")");
           Console.ReadKey();
            #endregion

           SocialFact sf = new SocialFact(playableGames[0], sp.AgentA, sp.AgentB);

            #region SOCIAL GAMES

            //Wanna play a game?

            //Topic specificTopic = CKB.getTopic(caveGame.gameType);
            #endregion
*/

        }
         

        #region Initialization Methods
        private static void initializeKBs()
        {
            //Initialize the C_KB
            CKB = new KB_C();
            //Initialize the S_KB
            SKB = new KB_S();
        }
        
        private static void initializeGames()
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

        private static List<Agent> initializeAgents()
        {

            List<Agent> agents = new List<Agent>();
            Agent agent0 = new Agent("Player", 0.2f, -0.1f, 0.25f);
            Agent agent1 = new Agent("Agent 1",0.25f,-0.1f,0.25f);
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

        private static SocialNetworkList initializeNetworks(List<Agent> agens)
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

        private static void testNetwork(SocialNetwork n)
        {
            Console.WriteLine("TOPIC: " + n.TopicOfNetwork);
            n.printAllPairs();
            //List<SocialPair> pairs = n.allPairs;

        }
    }
}
