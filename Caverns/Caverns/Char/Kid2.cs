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
    class Kid2 : DialogCharacter
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
        int stepsToRun = 10;

        public Texture2D Falling;

        TimeSpan timer = new TimeSpan();

        public Kid2(Texture2D sprite, Map map, Game1 game)
            : base(sprite, map)
        {
            this.PhysicalContact += FoundMe;
            this.gameref = game;
            DialogState state = new DialogState(0, "... !");
            state.addResponse("Ok...");
            state.addResponse("Allways the mute one.");
            state.addResponse("Noone expects the spanish dictionary!");
            this.Dialog.addState(state);
            this.Position = new Vector2(30, 18);
        }

        private void FoundMe(Object sender, EventArgs e)
        {
            gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender);
            this.PhysicalContact -= FoundMe;
            
        }

        public override void update(GameTime time)
        {
            //timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
            timer += time.ElapsedGameTime;
            TimeSpan fourSecond = new TimeSpan(4000000);
            if (timer > fourSecond)
            {
                timer -= fourSecond;


                if (this.lastDialogEventNum < 0 && stepsToRun > 0)
                {
                    //timeItt++;
                    if (timeItt > 3) timeItt = 0;
                    //Position = Position + new Vector2(0, -1);
                    facing = 3;
                    stepsToRun--;
                    if(stepsToRun == 7)
                    {
                        this.Map.getTile((int)Position.X, (int)Position.Y).topText = new Rectangle(32, 6 * 32, 32, 32);
                        this.Map.getTile((int)Position.X, (int)Position.Y).Passible = false;
                    }
                    if (stepsToRun == 0)
                        this.Passable = true;
                }
            }
            lastTime = time.TotalGameTime.Seconds;
        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X - 1, (int)Position.Y - 1, 1, 2);
        }
        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y-offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32,32,480,480), Color.Black);
            if (stepsToRun <= 6)
            {
                spriteBatch.Draw(Falling, new Rectangle((int)(Position.X - offset.X) * 32, (int)(Position.Y - offset.Y) * 32, 32, 32), new Rectangle((stepsToRun - 6) / 4 * 120, ((stepsToRun - 6) % 4 * 120), 120, 120), Color.White);
            }
            else
            {
                spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32, (int)(Position.Y - offset.Y) * 32 - 32, 64, 80), new Rectangle(120 * timeItt+30, 120 * facing+60, 60, 60), Color.White);
            }
        }
    }
}
