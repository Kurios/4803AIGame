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
        static List<SocialGame> games;
        static List<Agent> agents;
        static SocialNetworkList networks;

        static void Main()
        {
            #region INITIALIZATION

           initializeKBs(); //Initializes the Knowledgebases
           initializeGames();   //Initializes all the games that can be played
           initializeAgents();  //Initializes all the agents that will be in the game
           initializeNetworks();    //Initializes all networks for the game
            #endregion

 
            #region SOCIAL NETWORKS

           SocialNetwork network1 = networks.socialNetworks[0];
           SocialPair sp = network1.getPair(agents[0], agents[1]);

           Console.WriteLine("SOCIAL PAIR: " + sp.AgentA.name + ", " + sp.AgentB.name);

           Console.WriteLine("GAMES: " + games.Count);

           List<SocialGame> playableGames = sp.getPlayableGames(games);
           Console.WriteLine("NUMBER OF PLAYABLE GAMES: " + playableGames.Count);

           Console.WriteLine("Agent: " + sp.AgentA.name);
           Console.WriteLine("Values: " + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity);

           sp.playGame(playableGames[0]);

           Console.WriteLine("OFFSETS: " + playableGames[0].comfortOffsets + ", " + playableGames[0].considerationOffsets + ", " + playableGames[0].curiosityOffsets);

           Console.WriteLine("Agent After: " + sp.AgentA.name);
           Console.WriteLine("Values: " + sp.AgentA.comfort + ", " + sp.AgentA.consideration + ", " + sp.AgentA.curiosity);
           Console.ReadKey();
            #endregion

           SocialFact sf = new SocialFact(playableGames[0], sp.AgentA, sp.AgentB);

            #region SOCIAL GAMES

            //Wanna play a game?

            //Topic specificTopic = CKB.getTopic(caveGame.gameType);
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

            //Console.WriteLine("NUMBER OF GAMES: " + games.Count);

            //Cave, Girl, Player, Party, Festival, Games, Gifts, Flowers, Forest, Ghosts, Mushrooms
           /* SocialGame caveGame = new SocialGame(new Subject(SubjectType.Cave));
            SocialGame girlGame = new SocialGame(new Subject(SubjectType.Girl));
            SocialGame playerGame = new SocialGame(new Subject(SubjectType.Player));
            SocialGame partyGame = new SocialGame(new Subject(SubjectType.Party));
            SocialGame festivalGame = new SocialGame(new Subject(SubjectType.Festival));
            SocialGame gamesGame = new SocialGame(new Subject(SubjectType.Games));
            SocialGame giftsGame = new SocialGame(new Subject(SubjectType.Gifts));
            SocialGame flowersGame = new SocialGame(new Subject(SubjectType.Flowers));
            SocialGame forestGame = new SocialGame(new Subject(SubjectType.Forest));
            SocialGame ghostsGame = new SocialGame(new Subject(SubjectType.Ghosts));
            SocialGame mushroomsGame = new SocialGame(new Subject(SubjectType.Mushrooms));

            games.Add(caveGame);
            games.Add(girlGame);
            games.Add(playerGame);

            games.Add(mushroomsGame);
            games.Add(partyGame);
            games.Add(festivalGame);
            games.Add(gamesGame);
            games.Add(giftsGame);
            games.Add(flowersGame);
            games.Add(forestGame);
            games.Add(ghostsGame);
            */

        }

        private static void initializeAgents()
        {

            agents = new List<Agent>();
            Agent agent0 = new Agent("Player", 0.9f, 0.9f, 0.9f);
            Agent agent1 = new Agent("Agent 1",0.0f,0.0f,0.0f);
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
        }

        private static void initializeNetworks()
        {
            networks = new SocialNetworkList();

            SocialNetwork sadNetwork = new SocialNetwork(new Topic(TopicType.Sad));
            SocialNetwork scaryNetwork = new SocialNetwork(new Topic(TopicType.Scary));
            SocialNetwork funNetwork = new SocialNetwork(new Topic(TopicType.Fun));
            SocialNetwork friendlyNetwork = new SocialNetwork(new Topic(TopicType.Friendly));

            sadNetwork.generateNetwork(agents);
            scaryNetwork.generateNetwork(agents);
            funNetwork.generateNetwork(agents);
            friendlyNetwork.generateNetwork(agents);

            networks.addSocialNetwork(sadNetwork);
            networks.addSocialNetwork(scaryNetwork);
            networks.addSocialNetwork(funNetwork);
            networks.addSocialNetwork(friendlyNetwork);
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
