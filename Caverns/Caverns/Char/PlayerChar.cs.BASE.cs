﻿using System;
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
                facing = 0;
                if (Map.canMove((int)Position.X, (int)Position.Y + 1, this ))
                {
                    Position = Position + new Vector2(0, 1);
                }
            }
            else if (InputHandler.KeyPressed(Keys.Up))
            {
                facing = 3;
                if (Map.canMove((int)Position.X, (int)Position.Y - 1, this ))
                {
                    Position = Position + new Vector2(0, -1);
                }
            }
            else if (InputHandler.KeyPressed(Keys.Left))
            {
                facing = 1;
                if (Map.canMove((int)Position.X - 1, (int)Position.Y, this ))
                {
                    Position = Position + new Vector2(-1, 0);
                }
            }
            else if (InputHandler.KeyPressed(Keys.Right))
            {
                facing = 2;
                if (Map.canMove((int)Position.X + 1, (int)Position.Y, this ))
                {
                    Position = Position + new Vector2(1, 0);
                }
            }

        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X - 1, (int)Position.Y - 1, 1, 2);
        }


        public override void draw(SpriteBatch spriteBatch,Point offset)
        {
            spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y - offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32, 32, 32, 32), Color.White);

            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 - (32+16), (int)(Position.Y - offset.Y) * 32 - 32, 64, 80), new Rectangle(64 * timeItt, 80 * facing, 64, 80), Color.BlueViolet);
        }
    }
}