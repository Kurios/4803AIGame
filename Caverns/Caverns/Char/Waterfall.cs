using System;
using KuriosityXLib.Dialogs;
using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.Char
{
    internal class Waterfall : DialogCharacter
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
        private TimeSpan timer = new TimeSpan();

        public Waterfall(Texture2D sprite, Map map, Game1 game)
            : base(sprite, map)
        {
            this.PhysicalContact += FoundMe;
            this.gameref = game;
            DialogState state = new DialogState(0, "You come across a cavern.\n\n        Dare you venture?");
            state.addResponse("Hells Yah...", -1);
            state.addResponse("It does look a little dark in there...\n    Maybe after a cup of tea.", -2);
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
            this.Position = new Vector2(14, 10 + 32);
        }

        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y-offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32,32,32,32), Color.Black);
            if (!Passable)
                spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32, (int)(Position.Y - offset.Y) * 32, 96, 96), new Rectangle(32 * 16, 32 * 15, 96, 96), Color.White);
        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X - 1, (int)Position.Y - 1, 3, 3);
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
        }

        private void FoundMe(Object sender, EventArgs e)
        {
            if (((PlayerChar)sender).keyCount < 2)
            {
                //gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender, 1);
            }
            else
            {
                this.PhysicalContact -= FoundMe;
                this.Passable = true;
                this.Position = new Vector2(-100, -100);

                //this.done = true;
                //gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender);
                if (this.dialogExitState == -1)
                {
                    //Enter the cave
                    this.PhysicalContact -= FoundMe;
                }
                else
                {
                    //Do Nothing
                }
            }

            //
        }
    }
}