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
        public float friendliness;  //How friendly these two agents are toward one another.

        #region Constructors

        public SocialPair(Agent A, Agent B)
        {
            AgentA = A;
            AgentB = B;
            friendliness = (float) Math.Abs(A.consideration - B.consideration);
        }

        #endregion

        #region Methods

        public void update()
        {
            //Update the parameters of the two agents


        }

        public List<SocialGame> getPlayableGames(List<SocialGame> games, Topic tt)
        {
            List<SocialGame> gamesThatCanBePlayed = new List<SocialGame>();

            foreach (SocialGame game in games)
            {

                //if(game.gameType
                //Console.WriteLine("NUM SUBJECTS: " + tt.Subjects.Count);
                if (tt.Subjects.Contains(game.gameType))
                {
                    Console.WriteLine("Threshold: " + game.gameType.comfortThreshold + ", " + game.gameType.considerationThreshold + ", " + game.gameType.curiosityThreshold);

                    if (isComfortableTopic(game, tt) && isCuriousTopic(game, tt))
                    {
                        //Console.WriteLine("ADDED");
                        gamesThatCanBePlayed.Add(game);
                    }
                }

            }
            return gamesThatCanBePlayed;
        }

        private bool isComfortableTopic(SocialGame game, Topic t)
        {
            Agent player;
            Agent target;

            if (AgentA.name.Equals("Player"))
            {
                player = AgentA;
                target = AgentB;
            }
            else
            {
                player = AgentB;
                target = AgentA;
            }


            if (game.gameType.SubjectName.Equals(SubjectType.Cave) || game.gameType.SubjectName.Equals(SubjectType.Girl) || game.gameType.SubjectName.Equals(SubjectType.Player) || game.gameType.SubjectName.Equals(SubjectType.Mushrooms))
            {
                //IF THE TARGET IS NOT CONSIDERATE: DISREGARD PLAYER'S THOUGHTS
                if (target.consideration < 0)
                {
                    //If the target is comfortable with topic,
                    if (target.comfort > game.gameType.comfortThreshold)
                    {
                        return true;
                    }
                }
                //IF TARGET IS CONSIDERATE: TAKE PLAYER THOUGHTS INTO CONSIDERATION
                else
                {
                    if (player.comfort > game.gameType.comfortThreshold && target.comfort > game.gameType.comfortThreshold)
                    {
                        return true;
                    }
                }

            }
            else
            {
                if (player.comfort > game.gameType.comfortThreshold && target.comfort > game.gameType.comfortThreshold)
                {
                    return true;
                }
            }
          
            return false;
        }


        private bool isCuriousTopic(SocialGame game, Topic t)
        {
            Agent player;
            Agent target;

            if (AgentA.name.Equals("Player"))
            {
                player = AgentA;
                target = AgentB;
            }
            else
            {
                player = AgentB;
                target = AgentA;
            }


            if (game.gameType.Equals(SubjectType.Cave) || game.gameType.Equals(SubjectType.Girl) || game.gameType.Equals(SubjectType.Player) || game.gameType.Equals(SubjectType.Mushrooms))
            {

                if (target.curiosity > game.gameType.curiosityThreshold)
                {
                    return true;
                }
            }
            else
            {
                if(player.curiosity > game.gameType.curiosityThreshold)
                {
                    return true;
                }
            }
            return false;
        }



        //Player agent and target agent engage in the game

        public void playGame(SocialGame game, TopicType gameType)
        {
            //Player and target interact between each other.  They just read two different scripts.

            //Based on statistics, conversation can change subtly.

            //Update values

            //IF: 
            Agent player;
            Agent target;

            if (AgentA.name.Equals("Player"))
            {
                player = AgentA;
                target = AgentB;
            }
            else
            {
                player = AgentB;
                target = AgentA;
            }

            //PLAYER-RELATED GAME.
            if (gameType.Equals(TopicType.Player))
                //game.gameType.Equals(SubjectType.Cave) || game.gameType.Equals(SubjectType.Girl) || game.gameType.Equals(SubjectType.Player) || game.gameType.Equals(SubjectType.Mushrooms))
            {
                //TOPICS RELEVANT TO PLAYER

                if (player.comfort < 0)
                {
                    Console.WriteLine("I'm REALLY not comfortable talking about this topic.  Go away.");
                    player.comfort = player.comfort - 0.06f; //Player comfort takes another hit.
                    target.comfort = target.comfort - 0.09f;    //Target comfort takes a hit.
                    target.curiosity = target.curiosity + 0.05f;    //Target becomes more curious about topic.
                }
                else
                {
                    if (player.comfort < game.comfortThreshold)
                    {
                        Console.WriteLine("I'm a little uncomfortable with this topic.");
                        player.comfort = player.comfort - 0.03f;
                        target.curiosity = target.curiosity + 0.01f;
                    }
                    else
                    {
                        if (player.comfort >= 0.1 && player.comfort < 0.3)
                        {
                            Console.WriteLine("I'm a little comfortable with this topic.");
                            if (player.isImportant(target))
                            {
                                player.comfort = player.comfort + 0.05f;
                            }
                            else
                            {
                                player.comfort = player.comfort + 0.02f;
                            }
                        }
                        else if (player.comfort >= 0.3 && player.comfort < 0.7)
                        {

                            if (player.isImportant(target))
                            {
                                player.comfort = player.comfort + 0.08f;
                            }
                            else
                            {
                                player.comfort = player.comfort + 0.06f;
                            }

                            Console.WriteLine("I'm comfortable with this topic.");
                        }
                        else if (player.comfort >= 0.7)
                        {
                            Console.WriteLine("Sure, let's talk!");

                            if (player.isImportant(target))
                            {
                                player.comfort = player.comfort + 0.1f;
                            }
                            else
                            {
                                player.comfort = player.comfort + 0.09f;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("NON-PLAYER GAME");


                if (gameType.Equals(TopicType.Fun))
                {
                    Console.WriteLine("Let's talk about fun!");
                    player.comfort = player.comfort + 0.02f;
                    target.comfort = target.comfort + 0.05f;
                }
                else if (gameType.Equals(TopicType.Friendly))
                {
                    Console.WriteLine("We're friends right?");
                    player.comfort = player.comfort + 0.04f;
                   

                    float bonus = considerationBonus();
                    target.consideration = target.consideration + bonus;
                    player.consideration = player.consideration + bonus;

                }
                else if (gameType.Equals(TopicType.Scary))
                {
                    Console.WriteLine("How creepy...");
                    player.comfort = player.comfort - 0.11f;
                    target.comfort = target.comfort - 0.06f;
                }
                Console.WriteLine("");



            }
        }

        private float considerationBonus()
        {
            float bonus = 0;
            if (AgentA.consideration >= 0.4f && AgentA.consideration<0.6f)
            {
                bonus = 0.02f;
            }
            else if (AgentA.consideration >= 0.6f && AgentA.consideration < 0.8f)
            {
                bonus = 0.03f;
            }
            else
            {
                bonus = 0.05f;
            }
            
            if (AgentB.consideration >= 0.4f && AgentB.consideration < 0.6f)
            {
                bonus =bonus + 0.02f;
            }
            else if (AgentB.consideration >= 0.6f && AgentB.consideration < 0.8f)
            {
                bonus = bonus + 0.03f;
            }
            else
            {
                bonus = bonus + 0.05f;
            }
            return bonus;
        }
        #endregion

        #region Test Methods
        #endregion
    }
}
