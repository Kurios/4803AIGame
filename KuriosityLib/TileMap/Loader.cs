using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace KuriosityXLib.TileMap
{
    public class Loader
    {
        static Map CreateMap(Game game,Texture2D spriteMap, String[] gameDesc){
            Map ret = null;
            int mode = 0;
            Regex tile = new Regex("(\\d+\\,\\d+) ((\\d+\\,\\d+)|null) ((\\d+\\,\\d+)|null) (?:(true|false))");
            foreach (String line in gameDesc)
            {
                
                TileFactory tiles = new TileFactory(spriteMap);

                SubMapFactory subMaps = new SubMapFactory(tiles);

                MapFactory mapFact = new MapFactory(subMaps);

                ret = new Map(game, new Vector2(1, 1), 100, 100, spriteMap);
                return ret;
            }
            return ret;
        }
        

    }
}
