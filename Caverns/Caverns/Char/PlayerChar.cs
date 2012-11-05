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
    class PlayerChar : DialogCharacter
    {

        public enum PlayerState
        {

        }
        //A Player Character has a timer and able to tell which direction they're facing.
        int timeItt = 0;

        public int keyCount = 0;
        public int peopleFound = 0;

        public double movementSpeed = 0;
        public double TileFindingSpeed = 0;

        public int tilesFound = 0;

        public LinkedList<double> moves = new LinkedList<double>();
        public LinkedList<double> newSquares = new LinkedList<double>();

        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        public int facing = 0;

        private Game1 gameref;

        TimeSpan timer = new TimeSpan();
        
        /// <summary>
        /// Player Character constructor.  It calls the base class' constructor.
        /// </summary>
        /// <param name="sprite">The sprite to be used to move the Player Character.</param>
        /// <param name="map">The map associated with the Player Character.</param>
        public PlayerChar(Texture2D sprite, Map map, Game game)
            : base(sprite, map)
        {
            PhysicalContact += hitMe;
            this.gameref = (Game1)game;
        }

        private void hitMe(Object sender, EventArgs e)
        {
            gameref.MapScreen.playerHit();
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

            double curTime = time.TotalGameTime.TotalSeconds;
            


            timer += time.ElapsedGameTime;
            TimeSpan eightSecond = new TimeSpan(1250000);
            if (timer > eightSecond)
            {
                timer -= eightSecond;


                Vector2 proposedMove = new Vector2();
                if (InputHandler.KeyDown(Keys.Down))
                {
                    facing = (int)facingDirection.DOWN;
                    proposedMove = Position + new Vector2(0, 1);
                }
                else if (InputHandler.KeyDown(Keys.Up))
                {
                    facing = (int)facingDirection.UP;
                    proposedMove = Position + new Vector2(0, -1);
                }
                else if (InputHandler.KeyDown(Keys.Left))
                {
                    facing = (int)facingDirection.LEFT;
                    proposedMove = Position + new Vector2(-1, 0);
                }
                else if (InputHandler.KeyDown(Keys.Right))
                {
                    facing = 2;
                    proposedMove = Position + new Vector2(1, 0);
                }


                if (Map.canMove((int)proposedMove.X, (int)proposedMove.Y, this))
                {
                    Position = proposedMove;
                    timeItt++;
                    if (timeItt > 3) timeItt = 0;
                    moves.AddFirst(curTime);
                    if (Map.pcMove((int)proposedMove.X, (int)proposedMove.Y))
                    {
                        tilesFound++;
                        newSquares.AddFirst(curTime);
                    }
                }
                LinkedList<double> toBeDeleted = new LinkedList<double>();
                foreach(double m in moves)
                {
                    if(m < (curTime - 4)) toBeDeleted.AddFirst(m); 
                }
                foreach(double m in toBeDeleted)
                {
                    moves.Remove(m);
                }
                moveSpeed = moves.Count / 4;

                LinkedList<double> toBeDeletedTiles = new LinkedList<double>();
                foreach (double m in newSquares )
                {
                    if (m < (curTime - 4)) toBeDeletedTiles.AddFirst(m);
                }
                foreach (double m in toBeDeletedTiles)
                {
                    newSquares.Remove(m);
                }
                TileFindingSpeed = newSquares.Count / 4;

                Character[] chars = Map.checkForCharacter((int)proposedMove.X, (int)proposedMove.Y, this);
                foreach (Character c in chars)
                {
                    //EventArgs e = new EventArgs();
                    c.OnPhysicalContact(this);
                }
            }

         

        }

        /// <summary>
        /// Retrieves the Player Character's bounding box.
        /// </summary>
        /// <returns></returns>
        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 1, 2);
        }

        /// <summary>
        /// Draws the Player Character
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="offset"></param>
        public override void draw(SpriteBatch spriteBatch,Point offset)
        {
            spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X -offset.X) * 32, (getBoundingRect().Y - offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32, 32, 10, 10), Color.White);

            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 - 16, (int)(Position.Y - offset.Y) * 32 - 16, 64, 80), new Rectangle(64 * timeItt, 80 * facing, 64, 80), Color.White);
        }
    }
}
