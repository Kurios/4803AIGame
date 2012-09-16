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
        public static Map CreateMap(Game game,Texture2D spriteMap, String[] gameDesc){
            Map ret = null;
            //int subMapCounter = 0;
            Regex tileRegex = new Regex(@"t (?:(\d),(\d)|null) (?:(\d),(\d)|null) (?:(\d),(\d)|null) (true|false)");
            Regex subMapRegex = new Regex(@"(\d+)\-(\d+)  ?(\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+) (\d+)");
            Regex mapDefine = new Regex(@"md (\d+) (\d+)");
            //Regex subMapModeRegex = new Regex(@"(?:(\d),(\d)|null) (?:(\d),(\d)|null) (?:(\d),(\d)|null) (true|false)");
            Regex mapSet = new Regex(@"ms (\d+) (\d+) (\d+)");
            //Regex mapCreate = new Regex(
            //Regex tileRegex = new Regex(@"(?:(\d),(\d)|null) (?:(\d),(\d)|null) (?:(\d),(\d)|null) (true|false)");
            MatchCollection matches;
            MapFactory mapFact = null;
            foreach (String line in gameDesc)
            {
                TileFactory tiles = new TileFactory(spriteMap);
                SubMapFactory subMaps = new SubMapFactory(tiles);
                
                if (mapDefine.IsMatch(line))
                {
                    matches = mapDefine.Matches(line);
                    mapFact = new MapFactory(subMaps, int.Parse(matches[0].Value), int.Parse(matches[1].Value));
                }
                else if (tileRegex.IsMatch(line))
                {
                    matches = tileRegex.Matches(line);
                    tiles.SetBaseSprite(new Rectangle(int.Parse(matches[0].Value), int.Parse(matches[1].Value), 32, 32));
                    if (matches[2].Success)
                    {
                        tiles.SetAccentSprite(new Rectangle(int.Parse(matches[2].Value), int.Parse(matches[3].Value), 32, 32));
                    }
                    if (matches[4].Success)
                    {
                        tiles.SetTopSprite(new Rectangle(int.Parse(matches[4].Value), int.Parse(matches[5].Value), 32, 32));
                    }
                    tiles.SetPassible(bool.Parse(matches[6].Value));
                }
                else if (subMapRegex.IsMatch(line))
                {
                    matches = subMapRegex.Matches(line);
                    for (int x = 0; x < 64; x++)
                    {
                        subMaps.setTile(x, int.Parse(matches[1].Value), int.Parse(matches[x + 2].Value), int.Parse(matches[0].Value));
                    }
                    if (int.Parse(matches[0].Value) == 63) subMaps.AddSubMap();
                }
                else if (mapSet.IsMatch(line))
                {
                    matches = mapSet.Matches(line);
                    mapFact.setSubSector(int.Parse(matches[0].Value), int.Parse(matches[1].Value), int.Parse(matches[2].Value));
                }
                else
                {
                    throw new System.ArgumentException("Line does not match known regex lines", "line");
                }
            }
            ret = mapFact.generate(spriteMap);
            return ret;
        }
        

    }
}
