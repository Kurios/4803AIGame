using System;
using System.Collections.Generic;
using KLib.NerualNet.emotionState;
using KuriosityXLib;
using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SocialSim;
using SocialSim.Agents;
using SocialSim.Knowledgebases;
using SocialSim.Networks;
using SocialSim.GameStuff;
using KuriosityXLib.Dialogs;
using SocialSim;

namespace Caverns.Char
{
    public class BlankChar : DialogCharacter
    {
        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        private int facing = 1;

        private Game1 gameref;
        private int lastTime = 0;
        private Random r = new Random();
        private bool runAway;
        private int stepsToRun = 60;
        private int timeItt = 0;
        protected Agent agent;
        private TimeSpan timer = new TimeSpan();
        private SocialPair spLast;
        private List<SocialGame> gameLast;
        private KB_C topicLast;

        public BlankChar(Texture2D sprite, Map map, Game1 game, Agent agent)
            : base(sprite, map)
        {
            this.PhysicalContact += TalkToMe;
            this.gameref = game;
            this.Position = new Vector2(45, 17);
            this.agent = agent;
        }

        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y-offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32,32,32,32), Color.Black);

            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 - (32 + 16), (int)(Position.Y - offset.Y) * 32 - 32, 50, 64), new Rectangle(32 * timeItt, 32 * facing, 32, 32), Color.White);
        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X - 1, (int)Position.Y - 1, 1, 2);
        }

        public override void update(GameTime time)
        {
            //timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
            timer += time.ElapsedGameTime;
            TimeSpan eightSecond = new TimeSpan(1250000);
            if (timer > eightSecond)
            {
                timer -= eightSecond;
                /*
                if (this.lastDialogEventNum < 0 && stepsToRun > 0)
                {
                    timeItt++;
                    if (timeItt > 3) timeItt = 0;
                    Position = Position + new Vector2(0, -1);
                    facing = 3;
                    stepsToRun--;
                }
                 */
            }
            if (lastDialogEventNum < 0)
            {
                spLast.playGame(gameLast[Math.Abs(lastDialogEventNum)], topicLast.getTopic(gameLast[Math.Abs(this.lastDialogEventNum)].gameType).Name);
                lastDialogEventNum = 0;
            }
            lastTime = time.TotalGameTime.Seconds;
        }

        private void TalkToMe(Object sender, EventArgs e)
        {
            //((PlayerChar)sender).peopleFound++;
            //gameref.Network.ToString();
            
            //List<SocialGame> games = new List<SocialGame>();


            List<SocialGame> games = gameref.SocialSimStuff.games;  //List of games populated
            //TODO: Figure out how to initialize this games thing... 
            
            /*TO JACK: Jack, I modified more further down.  The commented out code are your original lines*/

            KB_C CKB = gameref.SocialSimStuff.CKB;  //CKB has been initialized.  CKB is populated.
            KB_S SKB = gameref.SocialSimStuff.SKB;  //SKB has been initialized.  SKB is populated.
            SocialPair sp = gameref.Network.getPair(((BlankChar)sender).agent, this.agent); //INVALID CAST EXCEPTION!
            List<SocialGame> playableGames = gameref.Networks.getPlayableGames(sp, games);  //Retrieves the set of playable games.

            //END LIST
            
            Dialog d = new Dialog();
            //INITIAL DIALOG STATE: 

            DialogState state = new DialogState(0, "Hi there.");


            for (int i = 0; Math.Abs(i) < playableGames.Count; i++)
            {
                state.addResponse(playableGames[Math.Abs(i)].gameType.SubjectName.ToString(), i+1);
            }
            //d.addState(state);
            for (int i = 0; Math.Abs(i) < playableGames.Count; i++)
            {
                List<String> spResponses = playableGames[i].getScript(sp);
                if (playableGames[i].gameType.SubjectName == SubjectType.Girl || playableGames[i].gameType.SubjectName == SubjectType.Mushrooms || playableGames[i].gameType.SubjectName == SubjectType.Cave || playableGames[i].gameType.SubjectName == SubjectType.Player)
                {
                    //Subjects: NPC starts dialog. Player, Girl, Mushrooms, Cave
                    //state = new DialogState(0, spResponses[0]);
                    for (int j = 0; j < spResponses.Count; j += 2) //0 = initial statement, 1 = first response. and so on...
                    {
                        d.addState(state);
                        state = new DialogState(i + 1 + j * 20, spResponses[j]);
                        if (spResponses.Count > j + 2)
                            state.addResponse(spResponses[j + 1], i + 1 + (j + 1 ) * 20);
                        else
                            state.addResponse(spResponses[j + 1], i + 1 * -1);
                    }
                }
                else
                {
                    d.addState(state);
                    state = new DialogState(i + 1 , "");
                    for (int j = 0; j < spResponses.Count; j += 2) //0 = initial statement, 1 = first response. and so on...
                    {
                        //state = new DialogState(i + 1 + j * 20, spResponses[j]);
                        if (spResponses.Count > j + 1)
                        {
                            state.addResponse(spResponses[j], i + 1 + (j + 1) * 20);
                            d.addState(state);
                            state = new DialogState(i + 1 + (j + 1) * 20, spResponses[j + 1]);
                        }
                        else
                            state.addResponse(spResponses[j], i + 1 * -1);
                    }
                }
            }
            /*for( int i =  0 ; Math.Abs(i) > games.Count ; i-- )
            {
                state.addResponse(games[i].gameType.SubjectName.ToString(), i);
                //Adds responses based on game
            }*/
            d.addState(state);
            Dialog = d;
            Console.WriteLine(d.ToString());
            gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender);

            //Doesnt Return a String....
            
            //sp.playGame(games[Math.Abs(d.currentID)], CKB.getTopic(games[Math.Abs(d.currentID)].gameType).Name);    //ONLY modifies values based on algorithm.

            spLast = sp;
            gameLast = playableGames;
            topicLast = CKB;
            //sp.playGame(playableGames[Math.Abs(this.lastDialogEventNum)], CKB.getTopic(playableGames[Math.Abs(this.lastDialogEventNum)].gameType).Name);    //ONLY modifies values based on algorithm.
            
            
            //Assuming a Array of Strings, in the order NPC action, then. Player Dialog Options.

           /* String[] spResponses = new String[2];
            state = new DialogState(0,spResponses[0]);
            for (int i = 1; i > spResponses.Length; i++)
            {
                state.addResponse(spResponses[i]);
            }
            */
            /*
            //Subjects: NPC starts dialog. Player, Girl, Mushrooms, Cave
            List<String> spResponses = playableGames[Math.Abs(d.currentID)].getScript(sp);
            state = new DialogState(0, spResponses[0]);
            for (int i = 1; i < spResponses.Count; i++) //0 = initial statement, 1 = first response. and so on...
            {
                state.addResponse(spResponses[i]);
            }
            
            d = new Dialog();
            d.addState(state);
            Dialog = d;

            gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender);

            //this.PhysicalContact -= FoundMe;
             * */
        }

        //private void ResumeDialog(Object sender, EventArgs e)
    }
}
