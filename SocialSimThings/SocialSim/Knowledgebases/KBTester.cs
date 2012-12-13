using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialSim.Knowledgebases;

using SocialSim.Agents;
using SocialSim.GameStuff;

namespace SocialSim
{
    class KBTester
    {
        /*static void Main()
        {
            printCKB();
            //printSKB();
            Console.ReadKey();
        }*/
        
        //Testing Culture Knowledgebase
        private static void printCKB()
        {
            KB_C CKB = new KB_C();

            List<Topic> CKBTopics = CKB.TopicList;
            Console.WriteLine("# TOPICS: " + CKBTopics.Count);
            Console.WriteLine("");

            foreach (Topic t in CKBTopics)
            {

                if (t.Name == TopicType.Friendly)
                {
                    Console.WriteLine("Topic: Friendly");
                }
                else if (t.Name == TopicType.Fun)
                {
                    Console.WriteLine("Topic: Fun");
                }
                else if (t.Name == TopicType.Player)
                {
                    Console.WriteLine("Topic: Related to Player");
                }
                else if (t.Name == TopicType.Scary)
                {
                    Console.WriteLine("Topic: Scary");
                }

                printSubjects(t);
            }

        }

        //Print the Social Knowledgebase
        private static void printSKB()
        {
            KB_S SKB = new KB_S();

            SocialGame girlGame = new SocialGame(new Subject(SubjectType.Girl));
            SocialGame playerGame = new SocialGame(new Subject(SubjectType.Player));

            Agent agent1 = new Agent("agent1");
            Agent agent2 = new Agent("agent2");
            Agent agent3 = new Agent("agent3");
            Agent agent4 = new Agent("agent4");

            SocialFact sf1 = new SocialFact(girlGame, agent1, agent2);
            SocialFact sf2 = new SocialFact(playerGame, agent1, agent2);
            SocialFact sf3 = new SocialFact(girlGame, agent3, agent1);

            SKB.addNewFact(sf1);
            SKB.addNewFact(sf2);
            SKB.addNewFact(sf3);

            List<SocialFact> factsByAgent = SKB.getSocialFactsByAgent(agent2);
            Console.WriteLine("FOUND: " + factsByAgent.Count + " FACTS.");


            List<SocialFact> factsByGame = SKB.getSocialFactsBySubject(new Subject(SubjectType.Girl));
            Console.WriteLine("FOUND: " + factsByGame.Count + " FACTS.");

            //SocialFact sf1 = new SocialFact()

        }

        private static void printSubjects(Topic t)
        {
            List<Subject> subjects = t.Subjects;

            foreach (Subject subName in subjects)
            {

                if (subName.SubjectName == SubjectType.Cave)
                {
                    Console.WriteLine("Subject: Cave");
                }
                else if (subName.SubjectName == SubjectType.Festival)
                {
                    Console.WriteLine("Subject: Festival");
                }
                else if (subName.SubjectName == SubjectType.Flowers)
                {
                    Console.WriteLine("Subject: Flowers");
                }
                else if (subName.SubjectName == SubjectType.Forest)
                {
                    Console.WriteLine("Subject: Forest");
                }
                else if (subName.SubjectName == SubjectType.Games)
                {
                    Console.WriteLine("Subject: Games");
                }
                else if (subName.SubjectName == SubjectType.Ghosts)
                {
                    Console.WriteLine("Subject: Ghosts");
                }
                else if (subName.SubjectName == SubjectType.Gifts)
                {
                    Console.WriteLine("Subject: Gifts");
                }
                else if (subName.SubjectName == SubjectType.Girl)
                {
                    Console.WriteLine("Subject: Girl");
                }
                else if (subName.SubjectName == SubjectType.Mushrooms)
                {
                    Console.WriteLine("Subject: Mushrooms");
                }
                else if (subName.SubjectName == SubjectType.Party)
                {
                    Console.WriteLine("Subject: Party");
                }
                else if (subName.SubjectName == SubjectType.Player)
                {
                    Console.WriteLine("Subject: Player");
                }
              
            }
            Console.WriteLine("");
        }

    }
}
