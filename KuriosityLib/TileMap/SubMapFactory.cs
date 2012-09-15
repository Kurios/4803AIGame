using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KuriosityXLib.TileMap
{
    class SubMapFactory
    {
        List<int[,]> def = new List<int[,]>();
        int head = 0;
        TileFactory fact;

        public SubMapFactory(TileFactory factory)
        {
            fact = factory;
            def.Add(new int[64, 64]);
        }

        public int AddSubMap()
        {
            def.Add(new int[64, 64]);
            head++;
            return head;
        }

        public void setTile(int x, int y, int tileType)
        {
            def[head][x,y] = tileType;
        }

        public void setTile(int x, int y, int tileType, int subMap)
        {
            def[subMap][x, y] = tileType;
        }

        public SubMap getMap()
        {
            SubMap ret = new SubMap();
            for (int x = 0; x < 64; x++)
            {
                for (int y = 0; y < 64; y++)
                {
                    ret.tiles[x, y] = fact.getTile(x, y, def[head][x, y]);
                }
            }
            return ret;
        }

        public SubMap getMap(int map)
        {
            SubMap ret = new SubMap();
            for (int x = 0; x < 64; x++)
            {
                for (int y = 0; y < 64; y++)
                {
                    ret.tiles[x, y] = fact.getTile(x, y, def[map][x, y]);
                }
            }
            return ret;
        }
    }
}
