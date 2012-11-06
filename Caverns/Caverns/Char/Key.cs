using System;
using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.Char
{
    internal class Key : Character
    {
        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        private int facing = 1;

        private bool found = false;
        private Game1 gameref;
        private int lastTime = 0;
        private Random r = new Random();
        private int stepsToRun = 60;
        private int timeItt = 0;
        private TimeSpan timer = new TimeSpan();

        public Key(Texture2D sprite, Map map, Game1 game)
            : base(sprite, map)
        {
            this.PhysicalContact += FoundMe;
            this.gameref = game;

            this.Position = new Vector2(45, 17);
        }

        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y-offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32,32,32,32), Color.Black);
            if (!found)
                spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 + 5, (int)(Position.Y - offset.Y) * 32, 15, 32), new Rectangle(0, 0, 15, 32), Color.White);
        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 1, 1);
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
            ((PlayerChar)sender).keyCount++;
            this.found = true;
            this.Passable = true;
            this.PhysicalContact -= FoundMe;
        }
    }
}