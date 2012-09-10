using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.Char
{
    //She is 64x90. 4 frames, 4 directions.
    class Woman : Character
    {
        int timeItt = 0;

        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        int facing = 0;


        public Woman(Texture2D sprite, Map map)
            : base(sprite, map)
        {
        }

        public override void update(GameTime time)
        {
            timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
            timeItt++;
            if (timeItt > 3) timeItt = 0;

        }

        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32, (int)(Position.Y- offset.Y) * 32 - 32 , 64, 90), new Rectangle(64 * timeItt, 90 * facing, 64, 90), Color.Black);
        }
    }
}
