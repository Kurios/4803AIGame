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
        //HEY!  groups[index] = subexpression for regexpression.
        public static Map CreateMap(Game game,Texture2D spriteMap, String[] gameDesc){
            Map ret = null;
            //int subMapCounter = 0;
            Regex tileRegex = new Regex(@"t (?:(\d+),(\d+)) (?:(\d+),(\d+)|null) (?:(\d+),(\d+)|null) (true)?");    //This is looking at specific locations in the original tile map.  The 2nd to last entry is a 'refernce' to be used for the submap, and the string is a reference to determine what the tile corresponds to.
            Regex subMapRegex = new Regex(@"(\d+)\-(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)  ?(\d+)"); //This is defined to be the tiles specified for a submap
            Regex mapDefine = new Regex(@"md (\d+) (\d+)"); //This is defined as the dimensions of the map.
            //Regex subMapModeRegex = new Regex(@"(?:(\d),(\d)|null) (?:(\d),(\d)|null) (?:(\d),(\d)|null) (true|false)");
            Regex mapSet = new Regex(@"ms (\d+) (\d+) (\d+)");
            //Regex mapCreate = new Regex(
            //Regex tileRegex = new Regex(@"(?:(\d),(\d)|null) (?:(\d),(\d)|null) (?:(\d),(\d)|null) (true|false)");
            MatchCollection matches;
            MapFactory mapFact = null;
            TileFactory tiles = new TileFactory(spriteMap);
            SubMapFactory subMaps = new SubMapFactory(tiles);
            
            //For each string of lines in the textual map
            foreach (String line in gameDesc)
            {
                //If this is defined to be a map,
                if (mapDefine.IsMatch(line))
                {
                    matches = mapDefine.Matches(line);
                    mapFact = new MapFactory(subMaps, int.Parse(matches[0].Groups[1].Value), int.Parse(matches[0].Groups[2].Value));
                }
                //If it is information for a tile,
                else if (tileRegex.IsMatch(line))
                {
                    matches = tileRegex.Matches(line);  //Collection of matches based on regex
                    //[1],[2] = first set of (\d+),(\d+)
                    tiles.SetBaseSprite(new Rectangle(int.Parse(matches[0].Groups[1].Value)*32, int.Parse(matches[0].Groups[2].Value)*32, 32, 32));
                    //[3] [4] = second set of (\d+),(\d+).  Most often, both are null.
                    if (matches[0].Groups[3].Success)
                    {
                        tiles.SetAccentSprite(new Rectangle(int.Parse(matches[0].Groups[3].Value)*32, int.Parse(matches[0].Groups[4].Value)*32, 32, 32));
                    }
                    //[5] = passability [6] = third set of (\d+),(\d+).  Most often, both are null.
                    if (matches[0].Groups[5].Success)
                    {
                        tiles.SetTopSprite(new Rectangle(int.Parse(matches[0].Groups[5].Value)*32, int.Parse(matches[0].Groups[6].Value)*32, 32, 32));
                    }
                    //[7] = Passability
                    tiles.SetPassible(matches[0].Groups[7].Success);
                    tiles.AddTile();
                }
                //Or if it is information for a submap,
                else if (subMapRegex.IsMatch(line))
                {
                    matches = subMapRegex.Matches(line);
                    //From the first tile entry onward...
                    for (int x = 0; x < 32; x++)
                    {
                        //[2] = row entry, [x+3] = col entry, [1] = sub-map
                        subMaps.setTile(x, int.Parse(matches[0].Groups[2].Value), int.Parse(matches[0].Groups[x + 3].Value), int.Parse(matches[0].Groups[1].Value));
                    }
                    if (int.Parse(matches[0].Groups[1].Value) == 31) subMaps.AddSubMap();
                }
                //If it is defined for a specific submap (Submap 1-2, Submap 2-2, etc...),
                else if (mapSet.IsMatch(line))
                {
                    matches = mapSet.Matches(line);
                    mapFact.setSubSector(int.Parse(matches[0].Groups[1].Value), int.Parse(matches[0].Groups[2].Value), int.Parse(matches[0].Groups[3].Value));
                }
                else
                {
                    throw new System.ArgumentException("Line does not match known regex lines", "line");
                }
            }
            
            //Generate the sprite map based on the map returned.  spriteMap is the 2D map used as a reference.
            ret = mapFact.generate(spriteMap);
            return ret;
        }
        

    }
}
