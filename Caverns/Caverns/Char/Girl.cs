﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework.Graphics;
using KuriosityXLib.Dialogs;
using Microsoft.Xna.Framework;

namespace Caverns.Char
{
    class Girl : DialogCharacter
    {
        int timeItt = 0;

        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        int facing = 2;

        int lastTime = 0;
        Random r = new Random();
        Game1 gameref;

        bool runAway;
        int stepsToRun = 120;

        TimeSpan timer = new TimeSpan();

        public Girl(Texture2D sprite, Map map, Game1 game)
            : base(sprite, map)
        {
            this.PhysicalContact += FoundMe;
            this.gameref = game;
            DialogState state = new DialogState(0, "*purr*");
            state.addResponse("Ok...");
            state.addResponse("Go Away Kitty...");
            state.addResponse("Meow meow meow mix.. !");
            this.Dialog.addState(state);
            this.Position = new Vector2(7, 64 + 27);
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
            TimeSpan eightSecond = new TimeSpan(800000);
            if (timer > eightSecond)
            {
                timer -= eightSecond;


                if (this.lastDialogEventNum < 0 && stepsToRun > 0)
                {
                    timeItt++;
                    if (timeItt > 3) timeItt = 0;
                    Position = Position + new Vector2(0, -1);
                    facing = 3;
                    stepsToRun--;
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
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y-offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32,32,32,32), Color.Black);

            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 - (32 + 16), (int)(Position.Y - offset.Y) * 32 - 32, 56, 80), new Rectangle(65 * timeItt, 96 * facing, 65, 96), Color.White);

        }
    }
}