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
    
    /// <summary>
    /// This is the player character, a child of the Character class.
    /// </summary>
    class PlayerChar : Character
    {

        public enum PlayerState
        {

        }
        //A Player Character has a timer and able to tell which direction they're facing.
        int timeItt = 0;

        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        int facing = 0;
        
        /// <summary>
        /// Player Character constructor.  It calls the base class' constructor.
        /// </summary>
        /// <param name="sprite">The sprite to be used to move the Player Character.</param>
        /// <param name="map">The map associated with the Player Character.</param>
        public PlayerChar(Texture2D sprite, Map map);

        public PlayerChar(Texture2D sprite, Map map, Game game)
            : base(sprite, map)
        {
        }

        /// <summary>
        /// Updates the Player Character based on gametime.
        /// The character timer is utilized in this method, and for the time being, it is here that the
        /// character changes his or her direction based on what is pressed.
        /// </summary>
        /// <param name="time">Time related to the gameTime</param>
        /// 
        //update() will be updated with helper methods and to use the enumeration to determine direction facing.
        public override void update(GameTime time)
        {
            timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
            timeItt++;

            if (timeItt > 3) timeItt = 0;

            

            if (InputHandler.KeyPressed(Keys.Down))
            {
                facing = (int)facingDirection.DOWN;
                if (Map.canMove((int)Position.X, (int)Position.Y + 1, this ))
                {
                    Position = Position + new Vector2(0, 1);
                }
            }
            else if (InputHandler.KeyPressed(Keys.Up))
            {
                facing = (int)facingDirection.UP;
                if (Map.canMove((int)Position.X, (int)Position.Y - 1, this ))
                {
                    Position = Position + new Vector2(0, -1);
                }
            }
            else if (InputHandler.KeyPressed(Keys.Left))
            {
                facing = (int)facingDirection.LEFT;
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

        /// <summary>
        /// Retrieves the Player Character's bounding box.
        /// </summary>
        /// <returns></returns>
        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X - 1, (int)Position.Y - 1, 1, 2);
        }

        /// <summary>
        /// Draws the Player Character
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="offset"></param>
        public override void draw(SpriteBatch spriteBatch,Point offset)
        {
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y - offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32, 32, 32, 32), Color.White);

            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 - (32+16), (int)(Position.Y - offset.Y) * 32 - 32, 64, 80), new Rectangle(64 * timeItt, 80 * facing, 64, 80), Color.BlueViolet);
        }
    }
}
