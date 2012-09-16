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
    /// <summary>
    /// A Nonplayable character.  In contrast to a PlayableCharacter, a Nonplayable character may not
    /// have movement options, but has dialog options.
    /// </summary>
    /// 


    abstract class NonPlayableChar: DialogCharacter
    {
        //int timeItt = 0;
        /// <summary>
        /// NonPlayableChar constructor.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="map"></param>
        public NonPlayableChar(Texture2D sprite, Map map)
            : base(sprite, map)
        {

        }

        //public abstract void update(GameTime time);
        public override void update(GameTime time)
        {

        }
        


        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X - 1, (int)Position.Y - 1, 1, 2);
        }

        //public abstract void draw(SpriteBatch spriteBatch, Point offset);

        public override void draw(SpriteBatch spriteBatch, Point offset)
        {

        }
         
    }
}
