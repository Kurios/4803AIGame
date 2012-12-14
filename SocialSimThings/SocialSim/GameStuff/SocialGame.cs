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

            if (target.name.Equals("Ghost"))
            {
                if (player.comfort >= 0.65)
                {
                    script.Add("She awaits you in the cave...");
                    script.Add("...Who?!");
                }
                else
                {
                    script.Add("You are not ready to face her...");
                    script.Add("...");
                }
                return script;
            }
            else
            {

                if (gameType.SubjectName.ToString().Equals("Player"))
                {
                    if (player.comfort < 0)
                    {
                        script.Add("How are you doing?");
                        script.Add("I'm fine.  Thank you for asking.");
                        script.Add("It's good to see you outside.  Please, try to relax.");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("Thank you");
                        }
                        else
                        {
                            script.Add("Thank you");
                        }
                    }
                    else if (player.comfort < this.comfortThreshold)
                    {
                        script.Add("How are you doing?");
                        script.Add("Not bad.  It's been a little quiet recently.");
                        script.Add("Well, it's good to see you here.  Please try to enjoy yourself okay?");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("Thank you, I'll try.");
                        }
                        else
                        {
                            script.Add("Thank you, I'll try.");
                        }
                    }
                    else if (player.comfort >= 0.1 && player.comfort < 0.3)
                    {
                        script.Add("How are you doing?");
                        script.Add("I'm doing fine, thank you.  It looks like everyone's doing fine too.");
                        script.Add("Yes, we're all doing fine.  We're all happy to see you out here too.");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("Thanks.");
                        }
                        else
                        {
                            script.Add("Thanks.");
                        }
                    }
                    else if (player.comfort >= 0.3 && player.comfort < 0.7)
                    {
                        script.Add("How are you doing?");
                        script.Add("Very well, thank you.  How is everyone?");
                        script.Add("We've all been doing well.  It's good to see you're able to join us today.");
                       
                        if (player.isImportant(target))
                        {
                            script.Add("Yes, I am too.");
                        }
                        else
                        {
                            script.Add("Yes, I am too.");
                        }


                    }
                    else if (player.comfort >= 0.7)
                    {
                        script.Add("How are you doing?");
                        script.Add("I'm doing very well.  It looks like everyone's doing well too.");
                        script.Add("Yes, indeed.");
                       
                        //Console.WriteLine("Sure, let's talk!");

                        if (player.isImportant(target))
                        {
                            script.Add("It's good to be outside and hope things go well! :)");
                        }
                        else
                        {
                            script.Add("It's good to be outside and hope things go well! :)");
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
                            script.Add("...");
                        }
                        else
                        {
                            script.Add("...");
                        }
                    }
                    else if (player.comfort < this.comfortThreshold)
                    {
                        script.Add("They say that they're hearing voices from inside the cave.");
                        script.Add("Please...");
                        script.Add("Sorry.  I didn't mean to upset you.");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("It's fine.");
                        }
                        else
                        {
                            script.Add("It's fine.");
                        }
                    }
                    else if (player.comfort >= 0.1 && player.comfort < 0.3)
                    {
                        script.Add("They say that they're hearing voices from inside the cave.");
                        script.Add("I wonder if my sister's soul is truly at rest.");
                        script.Add("...I'm sorry.");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("It's okay.");
                        }
                        else
                        {
                            script.Add("It's okay.");
                        }
                    }
                    else if (player.comfort >= 0.3 && player.comfort < 0.7)
                    {
                        script.Add("They say that they're hearing voices from inside the cave.");
                        script.Add("Voices...?  Are you sure no one's hurt?");
                        script.Add("I'll inform the village elder in time.  Don't worry.");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("I hope everyone's okay.");
                        }
                        else
                        {
                            script.Add("I hope everyone's okay.");
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
                            script.Add("I hope so.");
                        }
                        else
                        {
                            script.Add("I hope so.");
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
                            script.Add("...");
                        }
                        else
                        {
                            script.Add("...");
                        }
                    }
                    else if (player.comfort < this.comfortThreshold)
                    {
                        script.Add("It must be difficult living by yourself these days.");
                        script.Add("Please, let's not dwell on this.");
                        script.Add("Sorry, I didn't mean to stir up those memories.");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("It's too soon...");
                        }
                        else
                        {
                            script.Add("It's too soon...");
                        }
                    }
                    else if (player.comfort >= 0.1 && player.comfort < 0.3)
                    {
                        script.Add("It must be difficult living by yourself these days.");
                        script.Add("...My sister's in a better place now.  Her death is unfortunate, but I'll get by.");
                        script.Add("Forgive me, I realize it's too soon.");
                       
                        if (player.isImportant(target))
                        {
                            script.Add("It's fine.");
                        }
                        else
                        {
                            script.Add("It's fine.");
                        }
                    }
                    else if (player.comfort >= 0.3 && player.comfort < 0.7)
                    {
                        script.Add("It must be difficult living by yourself these days.");
                        script.Add("Yes, but I've been managing.  I pray my sister's soul is at peace.");
                        script.Add("I'm sure she is.");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("Yes...");
                        }
                        else
                        {
                            script.Add("Yes...");
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
                            script.Add("Thank you, as am I.");
                        }
                        else
                        {
                            script.Add("Thank you, as am I.");
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
                            script.Add("Mushrooms...");
                        }
                        else
                        {
                            script.Add("Mushrooms...");
                        }
                    }
                    else if (player.comfort < this.comfortThreshold)
                    {
                        script.Add("Have you picked any mushrooms lately?");
                        script.Add("...No, I haven't.");
                        script.Add("I'm sorry.  I shouldn't have brought it up.");
                       
                        if (player.isImportant(target))
                        {
                            script.Add("Mushrooms...");
                        }
                        else
                        {
                            script.Add("Mushrooms...");
                        }
                    }
                    else if (player.comfort >= 0.1 && player.comfort < 0.3)
                    {
                        script.Add("Have you picked any mushrooms lately?");
                        script.Add("No.  Not really.");
                        script.Add("They're growing really well these days.");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("Shrooms...");
                        }
                        else
                        {
                            script.Add("Shrooms...");
                        }
                    }
                    else if (player.comfort >= 0.3 && player.comfort < 0.7)
                    {
                        script.Add("Have you picked any mushrooms lately?");
                        script.Add("I completely forgot they were in season this year.");
                        script.Add("I know you love them.  There should be healthy ones for sale sometime soon.");
                        
                        if (player.isImportant(target))
                        {
                            script.Add("Shrooms...!");
                        }
                        else
                        {
                            script.Add("Shrooms...!");
                        }


                    }
                    else if (player.comfort >= 0.7)
                    {
                        script.Add("Have you picked any mushrooms lately?");
                        script.Add("Mushrooms?  Oh no, not yet, but I plan to.");
                        script.Add("If you prefer, you can always buy them instead!");
                        

                        if (player.isImportant(target))
                        {
                            script.Add("SHROOMS...!");
                        }
                        else
                        {
                            script.Add("SHROOMS...!");
                        }
                    }

                }
                else if (gameType.SubjectName.ToString().Equals("Party"))
                {

                    script.Add("How are the party festivities coming?");
                    script.Add("Very well, thank you.  Should you ever want to help, please don't hesitate.");
                    if (player.isImportant(target))
                    {
                        script.Add("I'll think about it.");
                    }
                    else
                    {
                        script.Add("I'll think about it.");
                    }
                }
                else if (gameType.SubjectName.ToString().Equals("Festival"))
                {
                    script.Add("Are you ready for the festival?");
                    script.Add("Almost.  We still have some things to do.");
                    if (player.isImportant(target))
                    {
                        script.Add("Okay.  Let me know if you need help.");
                    }
                    else
                    {
                        script.Add("Okay.  Let me know if you need help.");
                    }
                }
                else if (gameType.SubjectName.ToString().Equals("Games"))
                {
                    script.Add("Hey, do you have time to play a game?");
                    script.Add("Sure.  What game?");
                    if (player.isImportant(target))
                    {
                        script.Add("Oh.  Um...can you give me a bit?");
                    }
                    else
                    {
                        script.Add("Oh.  Um...can you give me a bit?");
                    }
                    
                }
                else if (gameType.SubjectName.ToString().Equals("Gifts"))
                {
                    script.Add("Thank you for the present yesterday.");
                    script.Add("You're welcome.  I hope they helped raise your spirits :)");
                    if (player.isImportant(target))
                    {
                        script.Add("They did.  Thank you.");
                    }
                    else
                    {
                        script.Add("They did.  Thank you.");
                    }
                }
                else if (gameType.SubjectName.ToString().Equals("Flowers"))
                {
                    script.Add("Did you like the flowers I sent?");
                    script.Add("Yes, thank you very much.");
                    if (player.isImportant(target))
                    {
                        script.Add("You're most welcome.");
                    }
                    else
                    {
                        script.Add("You're most welcome.");
                    }
                }
                else if (gameType.SubjectName.ToString().Equals("Forests"))
                {
                    script.Add("The forest has been really quiet lately.");
                    script.Add("It has.  I wonder if there's something in the woods.");
                    if (player.isImportant(target))
                    {
                        script.Add("I hope not.");
                    }
                    else
                    {
                        script.Add("I hope not.");
                    }
                }
                else if (gameType.SubjectName.ToString().Equals("Ghosts"))
                {
                    script.Add("Do you believe in ghosts?");
                    script.Add("Please, let's not talk about it.");
                    if (player.isImportant(target))
                    {
                        script.Add("Sorry.");
                    }
                    else
                    {
                        script.Add("Sorry.");
                    }
                }
            }
            return script;

        }

        #region Script Methods
        #endregion


        #endregion
    }
}
