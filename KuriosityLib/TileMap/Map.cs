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

        public int tilesExplored = 0;

        public int totalTiles
        {
            get { return  Width* Height; }
        }

        SubMap[,] subMaps;
        Point worldSize;
   
        public int Width {
            get{return worldSize.X;}
        }

        public int Height {
            get{return worldSize.Y;}
        }

        Random r = new Random();

        //public Map(Game game, int x, int y Texture2D spriteMap)

        public Map(Game game, Vector2 scale, int x, int y, Texture2D spriteMap)
        {
            characterList = new List<Character>();
            subMaps = new SubMap[x/32+1, y/32+1];
            for (int i = 0; i < x/32+1; i++)
            {
                for (int j = 0; j < y/32+1; j++)
                {
                    subMaps[i,j] = new SubMap();
                        for( int u = 0; u < 32; u++)
                        {
                            for (int v = 0; v < 32; v++)
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
                            subMaps[i/32, j/32].tiles[i%32,j%32] = new Tile(x, y, new Rectangle(10 * 32, 6 * 32, 32, 32), spriteMap);
                            break;
                        case 1:
                            subMaps[i / 32, j / 32].tiles[i % 32, j % 32] = new Tile(x, y, new Rectangle(9 * 32, 6 * 32, 32, 32), spriteMap);
                            break;
                        case 2:
                            subMaps[i / 32, j / 32].tiles[i % 32, j % 32] = new Tile(x, y, new Rectangle(10 * 32, 7 * 32, 32, 32), spriteMap);
                            break;
                        case 3:
                            subMaps[i / 32, j / 32].tiles[i % 32, j % 32] = new Tile(x, y, new Rectangle(8 * 32, 7 * 32, 32, 32), spriteMap);
                            break;
                        case 4:
                            subMaps[i / 32, j / 32].tiles[i % 32, j % 32] = new Tile(x, y, new Rectangle(9 * 32, 7 * 32, 32, 32), spriteMap);
                            break;
                        case 5:
                            subMaps[i / 32, j / 32].tiles[i % 32, j % 32] = new Tile(x, y, new Rectangle(10 * 32, 8 * 32, 32, 32), spriteMap);
                            break;
                        case 6:
                            subMaps[i / 32, j / 32].tiles[i % 32, j % 32] = new Tile(x, y, new Rectangle(10 * 32, 9 * 32, 32, 32), spriteMap);
                            break;
                    }
                }
            }
            worldSize = new Point(100, 100);
            throw new System.InvalidOperationException();
            // TODO: Construct any child components here
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">tiles X</param>
        /// <param name="y">tiles y</param>
        public Map(int x, int y,Texture2D spriteMap)
        {
            characterList = new List<Character>();
            subMaps = new SubMap[x / 32 + 1, y / 32 + 1];
            for (int i = 0; i < x / 32 + 1; i++)
            {
                for (int j = 0; j < y / 32 + 1; j++)
                {
                    subMaps[i, j] = new SubMap();
                    for (int u = 0; u < 32; u++)
                    {
                        for (int v = 0; v < 32; v++)
                        {
                            subMaps[i, j].tiles[u, v] = new Tile(x, y, new Rectangle(10 * 32, 6 * 32, 32, 32), spriteMap);
                        }
                    }
                }
            }
            this.worldSize = new Point(x, y);
        }

        public Tile getTile(int x, int y)
        {
            if (worldSize.X > x && worldSize.Y > y && x > 0 && y > 0)
            {
                return subMaps[x / 32, y / 32].tiles[x % 32, y % 32];
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
            if (inBounds(x, y) && subMaps[x/32,y/32].tiles[x%32,y%32].Passible)
            {
                foreach (Character entity in characterList)
                {
                    if (!character.Passable)
                    {
                        if (character != entity)
                            ret = ret && !entity.getBoundingRect().Intersects(new Rectangle(x, y, bounds.Width / 32, bounds.Height / 32)) && !entity.getBoundingRect().Contains(new Rectangle(x, y, bounds.Width / 32, bounds.Height / 32));
                    }
                 }
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Null if none, the char in the square if one</returns>
        public Character[] checkForCharacter(int x, int y,Character character)
        {
            List<Character> ret = new List<Character>();
            Rectangle bounds = character.getBoundingRect();
            foreach (Character entity in characterList)
            {
                 if(character != entity)
                 {
                   if(entity.getBoundingRect().Intersects(new Rectangle(x, y, bounds.Width/32, bounds.Height/32)) || entity.getBoundingRect().Contains(new Rectangle(x, y, bounds.Width/32, bounds.Height/32)))
                   {
                       ret.Add(entity);
                   }
                 }
            }
            return ret.ToArray();
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

        public void switchWith(Map map)
        {
            this.subMaps = map.subMaps;
            this.worldSize = map.worldSize;
            this.characterList = map.characterList;
        }

        internal void setSubSector(int i, int j, SubMap subMap)
        {
            subMaps[i, j] = subMap;
        }

        public Boolean pcMove(int x, int y)
        {
            if (inBounds(x, y))
            {
                return subMaps[x / 32, y / 32].pcMove(x, y);
            }
            return false;
        }
    }
}
