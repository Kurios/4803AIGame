using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using KuriosityXLib;
using Microsoft.Xna.Framework.Input;

namespace Caverns.Char
{
    //She is 64x90. 4 frames, 4 directions.
    class PlayerChar : Character
    {
        int timeItt = 0;

        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        int facing = 0;


        public PlayerChar(Texture2D sprite, Map map)
            : base(sprite, map)
        {
        }

        public override void update(GameTime time)
        {
            timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
            timeItt++;

            if (timeItt > 3) timeItt = 0;

            if (InputHandler.KeyPressed(Keys.Down))
            {
                if(Map.inBounds((int)Position.X,(int)Position.Y+1))
                    Position = Position + new Vector2(0, 1);
            }
            else if (InputHandler.KeyPressed(Keys.Up))
            {
                if (Map.inBounds((int)Position.X, (int)Position.Y - 1)) 
                    Position = Position + new Vector2(0, -1);
            }
            else if (InputHandler.KeyPressed(Keys.Left))
            {
                if (Map.inBounds((int)Position.X - 1, (int)Position.Y)) 
                    Position = Position + new Vector2(-1, 0);
            }
            else if (InputHandler.KeyPressed(Keys.Right))
            {
                if (Map.inBounds((int)Position.X + 1, (int)Position.Y)) 
                    Position = Position + new Vector2(1, 0);
            }

        }

        public override void draw(SpriteBatch spriteBatch,Point offset)
        {
            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32-32, (int)(Position.Y - offset.Y) * 32 - 32, 64, 90), new Rectangle(64 * timeItt, 90 * facing, 64, 90), Color.BlueViolet);
        }
    }
}
