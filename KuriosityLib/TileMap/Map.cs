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
    public class Map
    {

        public List<Character> characterList { get; set; }


        SubMap[,] subMaps;
        Point worldSize;
   

        Random r = new Random();
        //public Map(Game game, int x, int y Texture2D spriteMap)

        public Map(Game game, Vector2 scale, int x, int y, Texture2D spriteMap)
        {
            characterList = new List<Character>();
            subMaps = new SubMap[x/64+1, y/64+1];
            for (int i = 0; i < x/64+1; i++)
            {
                for (int j = 0; j < y/64+1; j++)
                {
                    subMaps[i,j] = new SubMap();
                        for( int u = 0; u < 64; u++)
                        {
                            for (int v = 0; v < 64; v++)
                            {
                                subMaps[i,j].tiles[u,v] = new Tile(x, y, new Rectangle(10 * 32, 6 * 32, 32, 32), spriteMap);
                            }
                        }
                }
            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    switch (r.Next(0,6))
                    {
                        case 0:
                            subMaps[i/64, j/64].tiles[i%64,j%64] = new Tile(x, y, new Rectangle(10 * 32, 6 * 32, 32, 32), spriteMap);
                            break;
                        case 1:
                            subMaps[i / 64, j / 64].tiles[i % 64, j % 64] = new Tile(x, y, new Rectangle(9 * 32, 6 * 32, 32, 32), spriteMap);
                            break;
                        case 2:
                            subMaps[i / 64, j / 64].tiles[i % 64, j % 64] = new Tile(x, y, new Rectangle(10 * 32, 7 * 32, 32, 32), spriteMap);
                            break;
                        case 3:
                            subMaps[i / 64, j / 64].tiles[i % 64, j % 64] = new Tile(x, y, new Rectangle(8 * 32, 7 * 32, 32, 32), spriteMap);
                            break;
                        case 4:
                            subMaps[i / 64, j / 64].tiles[i % 64, j % 64] = new Tile(x, y, new Rectangle(9 * 32, 7 * 32, 32, 32), spriteMap);
                            break;
                        case 5:
                            subMaps[i / 64, j / 64].tiles[i % 64, j % 64] = new Tile(x, y, new Rectangle(10 * 32, 8 * 32, 32, 32), spriteMap);
                            break;
                        case 6:
                            subMaps[i / 64, j / 64].tiles[i % 64, j % 64] = new Tile(x, y, new Rectangle(10 * 32, 9 * 32, 32, 32), spriteMap);
                            break;
                    }
                }
            }
            worldSize = new Point(100, 100);
            // TODO: Construct any child components here
        }

        public Tile getTile(int x, int y)
        {
            if (worldSize.X > x && worldSize.Y > y && x > 0 && y > 0)
            {
                return subMaps[x / 64, y / 64].tiles[x % 64, y % 64];
            }
            return null;
        }

        public bool inBounds(int x, int y)
        {
            return worldSize.X > x && worldSize.Y > y && x > 0 && y > 0;
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
            foreach (SubMap subMap in subMaps)
            {
                foreach (Tile tile in subMap.tiles)
                {
                    tile.spriteResource = spriteMap;
                }
            }
        }
    }
}
