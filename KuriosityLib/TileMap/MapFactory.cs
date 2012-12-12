namespace KuriosityXLib.TileMap
{
    internal class MapFactory
    {
        private int[,] maps;
        private SubMapFactory subMaps;
        private int x;
        private int y;

        public MapFactory(SubMapFactory subMaps, int x, int y)
        {
            // TODO: Complete member initialization
            this.subMaps = subMaps;
            this.x = x;
            this.y = y;
            maps = new int[x, y];
        }

        //public

        internal Map generate(Microsoft.Xna.Framework.Graphics.Texture2D spriteMap)
        {
            Map ret = new Map(x * 32, y * 32, spriteMap);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    ret.setSubSector(i, j, subMaps.getMap(maps[i, j]));
                }
            }
            return ret;
        }

        internal void setSubSector(int x, int y, int subsector)
        {
            maps[x, y] = subsector;
        }
    }
}