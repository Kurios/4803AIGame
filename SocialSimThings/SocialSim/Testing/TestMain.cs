﻿using System;
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
               sp.playGame(playableGames[0], CKB.getTopic(playableGames[1].gameType).Name);
               List<String> script = playableGames[0].getScript(sp);
               Console.WriteLine(script[0]);
               Console.WriteLine(script[1]);
               Console.WriteLine(script[2]);
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

           playableGames = networks.getPlayableGames(sp, games);
           Console.WriteLine("NUMBER OF PLAYABLE GAMES: " + playableGames.Count);

           Console.WriteLine("BEFORE");
           Console.WriteLine("Agent A: (" + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp.AgentB.comfort + ", " + sp.AgentB.consideration + ", " + sp.AgentB.curiosity + ")");

           Console.WriteLine("");

           //SELECTS A PLAYABLE GAME.
           if (playableGames.Count > 0)
           {
               sp.playGame(playableGames[0], CKB.getTopic(playableGames[1].gameType).Name);
               List<String> script = playableGames[0].getScript(sp);
               Console.WriteLine(script[0]);
               Console.WriteLine(script[1]);
               Console.WriteLine(script[2]);
           }
           Console.WriteLine("AFTER");
           Console.WriteLine("Agent A: (" + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp.AgentB.comfort + ", " + sp.AgentB.consideration + ", " + sp.AgentB.curiosity + ")");

           Console.WriteLine("");

           playableGames = networks.getPlayableGames(sp, games);
           Console.WriteLine("NUMBER OF PLAYABLE GAMES: " + playableGames.Count);

           Console.WriteLine("BEFORE");
           Console.WriteLine("Agent A: (" + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp.AgentB.comfort + ", " + sp.AgentB.consideration + ", " + sp.AgentB.curiosity + ")");

           Console.WriteLine("");

           //SELECTS A PLAYABLE GAME.
           if (playableGames.Count > 0)
           {
               sp.playGame(playableGames[0], CKB.getTopic(playableGames[1].gameType).Name);
               List<String> script = playableGames[0].getScript(sp);
               Console.WriteLine(script[0]);
               Console.WriteLine(script[1]);
               Console.WriteLine(script[2]);
           }
           Console.WriteLine("AFTER");
           Console.WriteLine("Agent A: (" + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity + ")");
           Console.WriteLine("Agent B: (" + sp.AgentB.comfort + ", " + sp.AgentB.consideration + ", " + sp.AgentB.curiosity + ")");

           Console.WriteLine("");

           sp = network1.getPair(ages[0], ages[2]);
           Console.WriteLine("Ages: " + ages[2].name);

           sp.playGame(playableGames[0], CKB.getTopic(playableGames[1].gameType).Name);
           List<String> script2 = playableGames[0].getScript(sp);
           Console.WriteLine("Script2: " + script2[0]);
           Console.WriteLine("DONE");

           Console.ReadKey();
            #endregion

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
            Agent agent0 = new Agent("Player", 0.75f, -0.1f, 0.55f);
            Agent agent1 = new Agent("Agent 1",0.75f,-0.1f,0.55f);
            Agent agent2 = new Agent("Ghost", 0.1f, 0.1f, 0.1f);
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
