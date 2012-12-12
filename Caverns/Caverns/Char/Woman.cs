using System;
using KuriosityXLib.Dialogs;
using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.Char
{
    //She is 64x90. 4 frames, 4 directions.
    internal class Woman : DialogCharacter
    {
        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        private int facing = 0;

        private Game1 gameref;
        private int lastTime = 0;
        private Random r = new Random();
        private int timeItt = 0;

        public Woman(Texture2D sprite, Map map, Game1 game)
            : base(sprite, map)
        {
            this.PhysicalContact += EeekSomeoneTouchedMe;
            this.gameref = game;
            DialogState state = new DialogState(0, "Eeek! you touched me!");
            state.addResponse("ok...");
            state.addResponse("That I did");
            this.Dialog.addState(state);
        }

        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y - offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32, 32, 32, 32), Color.Black);

            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 - (32 + 16), (int)(Position.Y - offset.Y) * 32 - 32, 64, 80), new Rectangle(64 * timeItt, 80 * facing, 64, 80), Color.White);
        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X - 1, (int)Position.Y - 1, 1, 2);
        }

        public override void update(GameTime time)
        {
            //timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));

            if (lastTime != time.TotalGameTime.Seconds)
            {
                timeItt++;
                if (timeItt > 3) timeItt = 0;
            }

            if (lastTime != time.TotalGameTime.Seconds)
            {
                switch (r.Next(0, 5))
                {
                    case 0:
                        if (Map.canMove((int)Position.X, (int)Position.Y + 1, this))
                        {
                            Position = Position + new Vector2(0, 1);
                            facing = 0;
                        }
                        break;

                    case 1:
                        if (Map.canMove((int)Position.X, (int)Position.Y - 1, this))
                        {
                            Position = Position + new Vector2(0, -1);
                            facing = 3;
                        }
                        break;

                    case 2:
                        if (Map.canMove((int)Position.X - 1, (int)Position.Y, this))
                        {
                            Position = Position + new Vector2(-1, 0);
                            facing = 1;
                        }
                        break;

                    case 3:
                        if (Map.canMove((int)Position.X + 1, (int)Position.Y, this))
                        {
                            Position = Position + new Vector2(1, 0);
                            facing = 2;
                        }
                        break;
                }
            }
            lastTime = time.TotalGameTime.Seconds;
        }

        private void EeekSomeoneTouchedMe(Object sender, EventArgs e)
        {
            gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender);
        }
    }
}