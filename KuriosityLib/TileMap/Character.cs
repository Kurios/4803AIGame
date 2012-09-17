using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib.TileMap
{
    /// <summary>
    /// This is an abstract class for a Character that appears in the game.  
    /// This class will serve as the base class for all characters, including the player character.
    /// </summary>
    public abstract class Character
    {
        bool passable = false; 
        public bool Passable{
            get { return passable; }
            set { passable = value; }
        }

        public event EventHandler PhysicalContact;

        public virtual void OnPhysicalContact(Object o) 
        {   
               if (PhysicalContact != null)
                 PhysicalContact(o, EventArgs.Empty);
        }

        //ENUMERATION
        public enum facingDirection
        {
            DOWN = 0,
            LEFT = 1,
            RIGHT = 2,
            UP =3
        };


        /// <summary>
        /// Getter/Setter for Character position.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Getter/Setter for Character sprite.
        /// </summary>
        public Texture2D Sprite { get; set; }

        /// <summary>
        /// Getter/Setter for Character map.
        /// </summary>
        public Map Map { get; set; }

        /// <summary>
        /// Getter/Setter for direction Character is facing.
        /// </summary>
        public facingDirection Direction { get; set; }

        //THE NEXT TWO ARE 'MAYBES'
        /// <summary>
        /// Getter/Setter for boolean that designates if the Character can move.
        /// </summary>
        public Boolean canMove { get; set; }
        /// <summary>
        /// Movement speed of the Character.  Can translate to how many tiles it can cover.
        /// </summary>
        public int moveSpeed { get; set; }


        /// <summary>
        /// Character constructor.  All Characters require a sprite representation and a map.
        /// Note: By default, character is facing DOWN.
        /// </summary>
        /// <param name="sprite">The sprite representation for the character.</param>
        /// <param name="map">The map needed for the character.</param>
        public Character(Texture2D sprite, Map map)
        {
            Sprite = sprite;
            Position = new Vector2();
            Map = map;
            Direction = facingDirection.DOWN;
        }

        public Character(Texture2D sprite, Map map, facingDirection dir)
        {
            Sprite = sprite;
            Position = new Vector2();
            Map = map;
            Direction = dir;
        }

        /// <summary>
        /// Retrieves the bounding box surrounding the character.
        /// 
        /// The bounding box is effectively the character's collider.  If anything touches or moves
        /// past the bounding box, it counts as a hit.
        /// </summary>
        /// <returns>
        /// Returns the rectangle representing the bounding box.
        /// </returns>
        public abstract Rectangle getBoundingRect();

        /// <summary>
        /// Updates the character.
        /// </summary>
        /// <param name="time">The GameTime that has passed.</param>
        public abstract void update(GameTime time);

        /// <summary>
        /// Draws the character.
        /// This draw method is the general 'Draw' method called by the screen.
        /// </summary>
        /// <param name="spriteBatch"> The sprite batch needed to draw things.</param>
        /// <param name="offset">Offset point needed for drawing.</param>
        public abstract void draw(SpriteBatch spriteBatch, Point offset);
    }
}
