﻿using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib.TileMap
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SubMap
    {
        private int tilesExplored = 0;

        public SubMap()
        {
            characterList = new List<Character>();
            tiles = new Tile[32, 32];
        }

        public List<Character> characterList { get; set; }

        public Tile[,] tiles { get; set; }

        public bool canMove(int x, int y, Character character)
        {
            Rectangle bounds = character.getBoundingRect();
            bool ret = true;
            if (inBounds(x, y))
            {
                foreach (Character entity in characterList)
                {
                    if (character != entity)
                        ret = ret && !entity.getBoundingRect().Intersects(new Rectangle(x, y, bounds.Width / 32, bounds.Height / 32)) && !entity.getBoundingRect().Contains(new Rectangle(x, y, bounds.Width / 32, bounds.Height / 32));
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        public SubMap Clone()
        {
            SubMap clone = new SubMap();
            clone.tiles = (Tile[,])tiles.Clone();
            return clone;
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

        public bool isPassable(int x, int y)
        {
            Tile ret = getTile(x, y);
            if (ret == null)
            {
                return false;
            }
            return ret.Passible;
        }

        public Boolean pcMove(int x, int y)
        {
            if (inBounds(x, y))
            {
                if (getTile(x, y).Explored)
                    return false;
                else
                {
                    getTile(x, y).Explored = true;
                    tilesExplored++;
                    return true;
                }
            }
            return false;
        }

        public void setSpriteMap(Texture2D spriteMap)
        {
            foreach (Tile tile in tiles)
            {
                tile.spriteResource = spriteMap;
            }
        }

        public void update(GameTime time)
        {
            foreach (Character entity in characterList)
            {
                entity.update(time);
            }
        }
    }
}