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

        public List<Character> characterList { get; set; }
       

        Tile[,] tiles;
        Random r = new Random();
        public Map(Game game, Vector2 scale, int x, int y, Texture2D spriteMap)
            : base(game)
        {
            characterList = new List<Character>();
            tiles = new Tile[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    switch (r.Next(0,6))
                    {
                        case 0:
                            tiles[i, j] = new Tile(x, y, new Rectangle(10 * 32, 6 * 32, 32, 32), spriteMap);
                            break;
                        case 1:
                            tiles[i, j] = new Tile(x, y, new Rectangle(9 * 32, 6 * 32, 32, 32), spriteMap);
                            break;
                        case 2:
                            tiles[i, j] = new Tile(x, y, new Rectangle(10 * 32, 7 * 32, 32, 32), spriteMap);
                            break;
                        case 3:
                            tiles[i, j] = new Tile(x, y, new Rectangle(8 * 32, 7 * 32, 32, 32), spriteMap);
                            break;
                        case 4:
                            tiles[i, j] = new Tile(x, y, new Rectangle(9 * 32, 7 * 32, 32, 32), spriteMap);
                            break;
                        case 5:
                            tiles[i, j] = new Tile(x, y, new Rectangle(10 * 32, 8 * 32, 32, 32), spriteMap);
                            break;
                        case 6:
                            tiles[i, j] = new Tile(x, y, new Rectangle(10 * 32, 9 * 32, 32, 32), spriteMap);
                            break;
                    }
                }
            }
            // TODO: Construct any child components here
        }

        public Tile getTile(int x, int y)
        {
            if (tiles.GetLength(0) > x && tiles.GetLength(1) > y && x > 0 && y > 0)
            {
                return tiles[x, y];
            }
            return null;
        }

        public bool inBounds(int x, int y)
        {
            return tiles.GetLength(0) > x && tiles.GetLength(1) > y && x > 0 && y > 0;
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
