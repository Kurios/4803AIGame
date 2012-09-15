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
    class NonPlayableChar: Character
    {
        /// <summary>
        /// NonPlayableChar constructor.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="map"></param>
        public NonPlayableChar(Texture2D sprite, Map map)
            : base(sprite, map)
        {

        }
    }
}
