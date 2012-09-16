using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KuriosityXLib.TileMap
{
    class MapFactory
    {
        private SubMapFactory subMaps;
        private int x;
        private int y;
        private int[,] maps;


        public MapFactory(SubMapFactory subMaps, int x, int y)
        {
            // TODO: Complete member initialization
            this.subMaps = subMaps;
            this.x = x;
            this.y = y;
            maps = new int[x, y];
        }

        //public 

        internal void setSubSector(int x, int y, int subsector)
        {
            maps[x, y] = subsector;
        }

        internal Map generate(Microsoft.Xna.Framework.Graphics.Texture2D spriteMap)
        {
            Map ret = new Map(x*64, y*64,spriteMap);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    ret.setSubSector(i, j, subMaps.getMap(maps[i, j]));
                }
            }
            return ret;
        }
    }
}
