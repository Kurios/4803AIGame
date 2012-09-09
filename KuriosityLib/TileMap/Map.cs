using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace KuriosityXLib.TileMap
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Map : Microsoft.Xna.Framework.GameComponent
    {
        Tile[,] tiles;

        public Map(Game game, Vector2 scale, int x, int y, Texture2D spriteMap)
            : base(game)
        {
            tiles = new Tile[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    tiles[i, j] = new Tile(x,y,new Rectangle(0,0,32,32),spriteMap);
                }
            }
            // TODO: Construct any child components here
        }

        public Tile getTile(int x, int y)
        {
            return tiles[x, y];
        }
    }
}
