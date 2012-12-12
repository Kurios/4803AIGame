using System.Collections.Generic;

namespace KuriosityXLib.TileMap
{
    internal class SubMapFactory
    {
        private List<int[,]> def = new List<int[,]>();
        private TileFactory fact;
        private int head = 0;

        public SubMapFactory(TileFactory factory)
        {
            fact = factory;
            def.Add(new int[32, 32]);
        }

        public int AddSubMap()
        {
            def.Add(new int[32, 32]);
            head++;
            return head;
        }

        public SubMap getMap()
        {
            SubMap ret = new SubMap();
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    ret.tiles[x, y] = fact.getTile(x, y, def[head][x, y]);
                }
            }
            return ret;
        }

        public SubMap getMap(int map)
        {
            SubMap ret = new SubMap();
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    ret.tiles[x, y] = fact.getTile(x, y, def[map][x, y]);
                }
            }
            return ret;
        }

        public void setTile(int x, int y, int tileType)
        {
            def[head][x, y] = tileType;
        }

        public void setTile(int x, int y, int tileType, int subMap)
        {
            while (subMap > head) AddSubMap();
            def[subMap][x, y] = tileType;
        }
    }
}