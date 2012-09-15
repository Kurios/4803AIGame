using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public class SubMap
    {

        public List<Character> characterList { get; set; }
       

        public Tile[,] tiles {get;set;}

        public SubMap()
        {
            characterList = new List<Character>();
            tiles = new Tile[64,64];
        }

        public Tile getTile(int x, int y)
        {
            if (tiles.GetLength(0) > x && tiles.GetLength(1) > y && x > 0 && y > 0)
            {
                return tiles[x, y];
            }
            return null;
        }

        public SubMap Clone()
        {
            SubMap clone = new SubMap();
            clone.tiles = (Tile[,]) tiles.Clone();
            return clone;
        }
            
        public bool inBounds(int x, int y)
        {
            return tiles.GetLength(0) > x && tiles.GetLength(1) > y && x > 0 && y > 0;
        }

        public bool isPassable(int x, int y)
        {
            Tile ret = getTile(x, y);
            if (ret == null)
            {
                return false;
            }
            return ret.Passible;
        }

        public bool canMove(int x, int y, Character character)
        {
            Rectangle bounds = character.getBoundingRect();
            bool ret = true;
            if (inBounds(x, y))
            {
                foreach (Character entity in characterList)
                {
                    if(character != entity)
                        ret = ret && !entity.getBoundingRect().Intersects(new Rectangle(x, y, bounds.Width/32, bounds.Height/32)) && !entity.getBoundingRect().Contains(new Rectangle(x, y, bounds.Width/32, bounds.Height/32));
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }
        public void update(GameTime time)
        {
            foreach (Character entity in characterList)
            {
                entity.update(time);
            }
        }

        public void setSpriteMap(Texture2D spriteMap)
        {
            foreach (Tile tile in tiles)
            {
                tile.spriteResource = spriteMap;
            }
        }
    }
}
