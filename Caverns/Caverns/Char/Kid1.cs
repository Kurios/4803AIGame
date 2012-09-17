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
    class Kid1: DialogCharacter
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

        public Kid1(Texture2D sprite, Map map,Game1 game)
            : base(sprite, map)
        {
            this.PhysicalContact += FoundMe;
            this.gameref = game;
            DialogState state = new DialogState(0,"Awww. I thought you would never find me.\n\n   You wont get me next time though! I promise!");
            state.addResponse("Ok...");
            state.addResponse("To the Next One!");
            state.addResponse("Tau Radience Fills the Galaxy!");
            this.Dialog.addState(state);
            this.Position = new Vector2(20, 20);
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
            TimeSpan eightSecond = new TimeSpan(1250000);
            if(timer > eightSecond){
                timer -= eightSecond;
              
               
            if(this.lastDialogEventNum < 0 && stepsToRun > 0)
            {
                timeItt++;
                if (timeItt > 3) timeItt = 0;
                   Position = Position + new Vector2(0, -1);
                   facing = 3;
                    stepsToRun --;
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

            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 - (32+16), (int)(Position.Y- offset.Y) * 32 - 32 , 64, 80), new Rectangle(64 * timeItt, 80 * facing, 64, 80), Color.White);
            
        }
    }
}
