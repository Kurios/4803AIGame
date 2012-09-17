using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework.Graphics;
using KuriosityXLib.Dialogs;
using Microsoft.Xna.Framework;

namespace Caverns.Char
{
    class CaveIn : DialogCharacter
    {
        int timeItt = 0;

        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        int facing = 1;

        int lastTime = 0;
        Random r = new Random();
        Game1 gameref;

        bool runAway;
        int stepsToRun = 60;

        TimeSpan timer = new TimeSpan();

        Map nextMap;
        public CaveIn(Texture2D sprite, Map map, Game1 game, Map nextMap)
            : base(sprite, map)
        {
            this.PhysicalContact += FoundMe;
            this.gameref = game;
            DialogState state = new DialogState(0, "You come across a cavern.\n\n        Dare you venture?");
            state.addResponse("Hells Yah...",-1);
            state.addResponse("It does look a little dark in there...\n    Maybe after a cup of tea.",-2);
            this.Dialog.addState(state);
            state = new DialogState(1, "Its way to scary to enter. \n    Plus, you gotta find more kids first.");
            state.addResponse("Oh.... Ill look then", -1);
            state.addResponse("Who are you to boss me around silly cave?", 2);
            this.Dialog.addState(state);
            state = new DialogState(2, "Im a cave. You know?");
            state.addResponse("Yes, I do know!", 3);
            state.addResponse("So?", 3);
            state.addResponse("Fine, I'll leave you alone", -2);
            this.Dialog.addState(state);
            state = new DialogState(3, "You should listen to me");
            state.addResponse("Why?", 2);
            state.addResponse("Fine!", -2);
            this.Dialog.addState(state);
            this.Position = new Vector2(14, 10+32);

            this.nextMap = nextMap;
        }

        private void FoundMe(Object sender, EventArgs e)
        {
            if (((PlayerChar)sender).peopleFound < 3)
            {
                gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender,1);      
            }
            else
            {
                gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender);
                if (this.dialogExitState == -1)
                {
                    //Enter the cave
                    this.PhysicalContact -= FoundMe;
                    Map.switchWith(nextMap);
                    foreach (Character c in Map.characterList)
                    {
                        if (c is PlayerChar)
                            nextMap.characterList.Add(c);
                            c.Position = new Vector2(20+64, 20);
                    }
                }
                else
                {
                    //Do Nothing
                }
            }
            //
        }

        public override void update(GameTime time)
        {
            //timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
            timer += time.ElapsedGameTime;
            TimeSpan eightSecond = new TimeSpan(1250000);
            if (timer > eightSecond)
            {
                timer -= eightSecond;


            }
            lastTime = time.TotalGameTime.Seconds;

            if (this.dialogExitState == -1)
            {
                //Enter the cave
                this.PhysicalContact -= FoundMe;
                Map.switchWith(nextMap);
                foreach (Character c in nextMap.characterList)
                {
                    if (c is PlayerChar)
                        c.Position = new Vector2(20, 20+64);
                }
            }
        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X - 1, (int)Position.Y - 1, 1, 2);
        }
        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y-offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32,32,32,32), Color.Black);

            //spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 - (32 + 16), (int)(Position.Y - offset.Y) * 32 - 32, 64, 80), new Rectangle(64 * timeItt, 80 * facing, 64, 80), Color.White);

        }
    }
}
