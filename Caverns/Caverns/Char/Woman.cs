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

        int lastTime = 0;
        Random r = new Random();


        public Woman(Texture2D sprite, Map map)
            : base(sprite, map)
        {
        }

        public override void update(GameTime time)
        {
            timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
            timeItt++;
            if (timeItt > 3) timeItt = 0;

           if( lastTime !=  time.TotalGameTime.Seconds){
               switch (r.Next(0, 3))
               {

                   case 0:
                       if (Map.inBounds((int)Position.X, (int)Position.Y + 1))
                           Position = Position + new Vector2(0, 1);
                       break;
                   case 1:
                       if (Map.inBounds((int)Position.X, (int)Position.Y - 1))
                           Position = Position + new Vector2(0, -1);
                       break;
                   case 2:
                       if (Map.inBounds((int)Position.X - 1, (int)Position.Y))
                           Position = Position + new Vector2(-1, 0);
                       break;
                   case 3:
                       if (Map.inBounds((int)Position.X + 1, (int)Position.Y))
                           Position = Position + new Vector2(1, 0);
                       break;
               }
            }
           lastTime = time.TotalGameTime.Seconds;
        }

        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32, (int)(Position.Y- offset.Y) * 32 - 32 , 64, 90), new Rectangle(64 * timeItt, 90 * facing, 64, 90), Color.White);
        }
    }
}
