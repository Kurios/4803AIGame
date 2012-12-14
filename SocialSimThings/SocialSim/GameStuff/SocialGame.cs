using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Agents;
using SocialSim.Knowledgebases;
using SocialSim.Knowledgebases;
using SocialSim.Networks;

namespace SocialSim.GameStuff
{
    public class SocialGame
    {

        public Subject gameType;   //The subject that pertains to the game.  What type of game is being played (What subject is being talked about?)


        public float curiosityThreshold;
        public float comfortThreshold;

        public float comfortOffsets;
        public float considerationOffsets;
        public float curiosityOffsets;

        List<String> actorScript;   //What the actor says.
        List<String> targetScript;  //What the target says.

        //A list of conditions that must be met.

        #region Constructors

        public SocialGame(Subject typeOfGame)
        {
            gameType = typeOfGame;
            comfortThreshold = 0;
            //considerationThreshold = 0;
            curiosityThreshold = 0;
            comfortOffsets = 0;
            considerationOffsets = 0;
            curiosityOffsets = 0;

        }

        public SocialGame(Subject typeOfGame, float comfortThresh, float curiosityThresh)
        {
            gameType = typeOfGame;
            comfortThreshold = comfortThresh;
            curiosityThreshold = curiosityThresh;
            comfortOffsets = 0;
            considerationOffsets = 0;
            curiosityOffsets = 0;
        }

        public SocialGame(Subject typeOfGame, float comfort, float consideration, float curiosity)
        {
            gameType = typeOfGame;
            comfortOffsets = comfort;
            considerationOffsets = consideration;
            curiosityOffsets = curiosity;
        }


        #endregion

        #region Methods

        public List<String> getScript(SocialPair sp)
        {
            //Who's who?
            Agent player;
            Agent target;

            if (sp.AgentA.name.Equals("Player"))
            {
                player = sp.AgentA;
                target = sp.AgentB;
            }
            else
            {
                player = sp.AgentB;
                target = sp.AgentA;
            }


            //Cave, Girl, Player, Party, Festival, Games, Gifts, Flowers, Forest, Ghosts, Mushrooms
            List<String> script = new List<String>();

            /*
             * //PLAYER-RELATED GAME.
            if (gameType.Equals(TopicType.Player))
            {
                //TOPICS RELEVANT TO PLAYER
                Console.WriteLine("PLAYER GAME");
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
             */
            if (gameType.SubjectName.ToString().Equals("Player"))
            {
                if (player.comfort < 0)
                {
                    script.Add("How are you doing?");
                    script.Add("I'm fine.  Thank you for asking.");
                    script.Add("It's good to see you outside.  Please, try to relax.");
                    script.Add("Thank you");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort < this.comfortThreshold)
                {
                    script.Add("How are you doing?");
                    script.Add("Not bad.  It's been a little quiet recently.");
                    script.Add("Well, it's good to see you here.  Please try to enjoy yourself okay?");
                    script.Add("Thank you, I'll try.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort >= 0.1 && player.comfort < 0.3)
                {
                    script.Add("How are you doing?");
                    script.Add("I'm doing fine, thank you.  It looks like everyone's doing fine too.");
                    script.Add("Yes, we're all doing fine.  We're all happy to see you out here too.");
                    script.Add("Thanks.");
                    if (player.isImportant(target))
                    {
                       
                    }
                    else
                    {
                        
                    }
                }
                else if (player.comfort >= 0.3 && player.comfort < 0.7)
                {
                    script.Add("How are you doing?");
                    script.Add("Very well, thank you.  How is everyone?");
                    script.Add("We've all been doing well.  It's good to see you're able to join us today.");
                    script.Add("Yes, I am too.");
                    if (player.isImportant(target))
                    {
                       
                    }
                    else
                    {
                        
                    }

                   
                }
                else if (player.comfort >= 0.7)
                {
                    script.Add("How are you doing?");
                    script.Add("I'm doing very well.  It looks like everyone's doing well too.");
                    script.Add("Yes, indeed.");
                    script.Add("It's good to be outside and hope things go well! :)");
                    //Console.WriteLine("Sure, let's talk!");

                    if (player.isImportant(target))
                    {
                    }
                    else
                    {
                    }
                }
                
            }

            else if (gameType.SubjectName.ToString().Equals("Cave"))
            {
                if (player.comfort < 0)
                {
                    script.Add("They say that they're hearing voices from inside the cave.");
                    script.Add("...");
                    script.Add("Forgive me, I didn't mean to bring that up...");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort < this.comfortThreshold)
                {
                    script.Add("They say that they're hearing voices from inside the cave.");
                    script.Add("Please...");
                    script.Add("Sorry.  I didn't mean to upset you.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort >= 0.1 && player.comfort < 0.3)
                {
                    script.Add("They say that they're hearing voices from inside the cave.");
                    script.Add("I wonder if my sister's soul is truly at rest.");
                    script.Add("...I'm sorry.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort >= 0.3 && player.comfort < 0.7)
                {
                    script.Add("They say that they're hearing voices from inside the cave.");
                    script.Add("Voices...?  Are you sure no one's hurt?");
                    script.Add("I'll inform the village elder in time.  Don't worry.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }


                }
                else if (player.comfort >= 0.7)
                {
                    script.Add("They say that they're hearing voices from inside the cave.");
                    script.Add("I hope no one's hurt.");
                    script.Add("Everyone knows to stay away from the cave.  They should be okay.");
                    //Console.WriteLine("Sure, let's talk!");

                    if (player.isImportant(target))
                    {
                    }
                    else
                    {
                    }
                }
                
            }
            else if (gameType.SubjectName.ToString().Equals("Girl"))
            {
                if (player.comfort < 0)
                {
                    script.Add("It must be difficult living by yourself these days.");
                    script.Add("...");
                    script.Add("I'm sorry.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort < this.comfortThreshold)
                {
                    script.Add("It must be difficult living by yourself these days.");
                    script.Add("Please, let's not dwell on this.");
                    script.Add("Sorry, I didn't mean to stir up those memories.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort >= 0.1 && player.comfort < 0.3)
                {
                    script.Add("It must be difficult living by yourself these days.");
                    script.Add("...My sister's in a better place now.  Her death is unfortunate, but I'll get by.");
                    script.Add("Forgive me, I realize it's too soon.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort >= 0.3 && player.comfort < 0.7)
                {
                    script.Add("It must be difficult living by yourself these days.");
                    script.Add("Yes, but I've been managing.  I pray my sister's soul is at peace.");
                    script.Add("I'm sure she is.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }


                }
                else if (player.comfort >= 0.7)
                {
                    script.Add("It must be difficult living by yourself these days.");
                    script.Add("Thank you, but I've been doing well.  My sister may not be with me, but I still have everyone else to help me.");
                    script.Add("I see.  I am happy to see you doing so well.");
                    //Console.WriteLine("Sure, let's talk!");

                    if (player.isImportant(target))
                    {
                    }
                    else
                    {
                    }
                }

            }
            else if (gameType.SubjectName.ToString().Equals("Mushrooms"))
            {
                if (player.comfort < 0)
                {
                    script.Add("Have you picked any mushrooms lately?");
                    script.Add("Mushrooms...");
                    script.Add("Forgive me.  I was insensitive.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort < this.comfortThreshold)
                {
                    script.Add("Have you picked any mushrooms lately?");
                    script.Add("...No, I haven't.");
                    script.Add("I'm sorry.  I shouldn't have brought it up.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort >= 0.1 && player.comfort < 0.3)
                {
                    script.Add("Have you picked any mushrooms lately?");
                    script.Add("No.  Not really.");
                    script.Add("FThey're growing really well these days.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }
                }
                else if (player.comfort >= 0.3 && player.comfort < 0.7)
                {
                    script.Add("Have you picked any mushrooms lately?");
                    script.Add("I completely forgot they were in season this year.");
                    script.Add("I know you love them.  There should be healthy ones for sale sometime soon.");
                    if (player.isImportant(target))
                    {

                    }
                    else
                    {

                    }


                }
                else if (player.comfort >= 0.7)
                {
                    script.Add("Have you picked any mushrooms lately?");
                    script.Add("Mushrooms?  Oh no, not yet, but I plan to.");
                    script.Add("If you prefer, you can always buy them instead!");

                    if (player.isImportant(target))
                    {
                    }
                    else
                    {
                    }
                }

            }
            else if (gameType.SubjectName.ToString().Equals("Party"))
            {

                script.Add("How are the party festivities coming?");
                script.Add("Very well, thank you.  Should you ever want to help, please don't hesitate.");
            }
            else if (gameType.SubjectName.ToString().Equals("Festival"))
            {
                script.Add("Are you ready for the festival?");
                script.Add("Almost.  We still have some things to do.");
            }
            else if (gameType.SubjectName.ToString().Equals("Games"))
            {
                script.Add("Hey, do you have time to play a game?");
                script.Add("Sure.  What game?");
                script.Add("Oh.  Um...can you give me a bit?");
            }
            else if (gameType.SubjectName.ToString().Equals("Gifts"))
            {
                script.Add("Thank you for the present yesterday.");
                script.Add("You're welcome.  I hope they helped raise your spirits :)");
            }
            else if (gameType.SubjectName.ToString().Equals("Flowers"))
            {
                script.Add("Did you like the flowers I sent?");
                script.Add("Yes, thank you very much.");
            }
            else if (gameType.SubjectName.ToString().Equals("Forests"))
            {
                script.Add("The forest has been really quiet lately.");
                script.Add("It has.  I wonder if there's something in the woods.");
            }
            else if (gameType.SubjectName.ToString().Equals("Ghosts"))
            {
                script.Add("Do you believe in ghosts?");
                script.Add("Please, let's not talk about it.");
            }
            return script;

        }

        #region Script Methods
        #endregion


        #endregion
    }
}
