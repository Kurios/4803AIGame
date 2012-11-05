using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MazeMaker;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text.RegularExpressions;

namespace KuriosityXLib.TileMap
{
    public class MazeLoader
    {
        //public static Map createMap(Game game, Texture2D spriteMap, Maze m, String[] tileData)
        public static Map createMap(Game game, Texture2D spriteMap, Maze m)
        {
            //EACH MAP: 64x64
            //int mazeYDimension = m.yDimension;
            //int mazeXDimension = m.xDimension;
            Map ret = null;
            int[,] mazeMap = new int[m.xDimension, m.yDimension];    //This will be used to store data about the map.
            
            //TILE FACTORY:
            TileFactory tiles = fillTileFactory(spriteMap);
            //SubMapFactory submaps = new SubMapFactory(tiles);
            //MapFactory mapFact = new MapFactory(submaps, m.xDimension, m.yDimension);


            //HAS THE MAZE ALREADY BEEN GENERATED?  IF NOT, USE:
           // m.generateMazePrim(0,0);   //Generate the maze.

            //GRAB THE PASSAGES
            List<Wall> passes = m.mazePassages;

            //SUBMAP FACTORY:
            SubMapFactory submaps = fillSubMaps(tiles, m, passes);

            //MAP FACTORY:
            MapFactory mapFact = new MapFactory(submaps, m.xDimension, m.yDimension);

            for (int y = 0; y < m.yDimension; y++)
            {
                for (int x = 0; x < m.xDimension; x++)
                {
                    mapFact.setSubSector(x, y, (y * m.xDimension + x));
                }

            }

            ret = mapFact.generate(spriteMap);
            return ret;
        }

        static TileFactory fillTileFactory(Texture2D spriteMap)
        {
            TileFactory tiles = new TileFactory(spriteMap);
            //Regex tileRegex = new Regex(@"t (?:(\d+),(\d+)) (?:(\d+),(\d+)|null) (?:(\d+),(\d+)|null) (true) (\d+) (FLOOR|WALL)");    //This is looking at specific locations in the original tile map.  The 2nd to last entry is a 'refernce' to be used for the submap, and the string is a reference to determine what the tile corresponds to.

            //HARD-CODING ADDED TILES.

            /*
             * 0 = Top Wall
             * 1 = Right Wall
             * 2 = Bottom Wall
             * 3 = Left Wall
             * 4 = Floor
             * 5 = Rock
             * Note: NO Borders yet.
             */

            //TOP WALL
            tiles.SetBaseSprite(new Rectangle(21 * 32, 54 * 32, 32, 32));
            tiles.SetPassible(false);
            tiles.AddTile();
            
            //RIGHT WALL
            tiles.SetBaseSprite(new Rectangle(16 * 32, 52 * 32, 32, 32));
            tiles.SetPassible(false);
            tiles.AddTile();
            
            //BOT WALL
            tiles.SetBaseSprite(new Rectangle(17 * 32, 51 * 32, 32, 32));
            tiles.SetPassible(false);
            tiles.AddTile();

            //LEFT WALL
            tiles.SetBaseSprite(new Rectangle(18 * 32, 52 * 32, 32, 32));
            tiles.SetPassible(false);
            tiles.AddTile();

            //FLOOR
            tiles.SetBaseSprite(new Rectangle(17 * 32, 52 * 32, 32, 32));
            tiles.SetPassible(true);
            tiles.AddTile();

            //ROCK OBSTACLE
            tiles.SetBaseSprite(new Rectangle(19 * 32, 50 * 32, 32, 32));
            tiles.SetPassible(false);
            tiles.AddTile();
           
            return tiles;
        }
        static SubMapFactory fillSubMaps(TileFactory tileSet, Maze mint, List<Wall> passes)
        {
            SubMapFactory submaps = new SubMapFactory(tileSet);

            //Row submap
            for (int y = 0; y < mint.yDimension; y++)
            {
                //Col submap
                for (int x = 0; x < mint.xDimension; x++)
                {
                    Gridspace gs = new Gridspace(x, y);
                    //List<Wall> adjWalls = mint.getAdjWalls(gs); //List of adjacent walls of specified gridspace

                    //Row of a submap
                    for (int r = 0; r < 32; r++)
                    {
                        //Col of a submap
                        for (int c = 0; c < 32; c++)
                        {
                            int tile = getTile(c, r, mint, gs, passes);
                            submaps.setTile(c, r, tile, (y*mint.xDimension)+x);

                        }

                    }
                    submaps.AddSubMap();
                }
            }
            return submaps;
        }

        static List<String> getOpenSpaces(Maze mint, Gridspace gspace, List<Wall> passableWalls)
        {
            List<String> passes = new List<String>();
            
            List<Wall> adjacents = mint.getAdjPassages(gspace);
            int xDiff = 0;
            int yDiff = 0;

            foreach (Wall adjWall in adjacents)
            {
                if (mint.contains(adjacents, adjWall))
                {
                    Gridspace otherSpace = adjWall.getOppositeSpace(gspace);

                    //Determine the difference of spacing:
                    xDiff = gspace.x - otherSpace.x;    //-1 means otherSpace is to the right, 1 means to the left.
                    yDiff = gspace.y - otherSpace.y;    //-1 means below, 1 means above.

                    if (xDiff == 1)
                    {
                        passes.Add("LEFT");
                    }
                    else if (xDiff == -1)
                    {
                        passes.Add("RIGHT");
                    }

                    if (yDiff == 1)
                    {
                        passes.Add("UP");
                    }
                    else if (yDiff == -1)
                    {
                        passes.Add("DOWN");
                    }

                }
            }
            return passes;
        }

        static int getTile(int c, int r, Maze mint, Gridspace gspace, List<Wall> passableWalls)
        {

            List<String> passableWays = getOpenSpaces(mint, gspace, passableWalls);

            //TOP
            if (r <=1 && (c > 0 || c <30))
            {
                if (passableWays.Contains("UP")&&(c >= 14 && c <= 17))
                {
                    return 4;
                }
                else
                {
                    return 0;
                }
            }
            //RIGHT
            else if (c >= 30 && (r > 0 || r <30))
            {
                if (passableWays.Contains("RIGHT") && (r >= 14 && r <= 17))
                {
                    return 4;
                }
                else
                {
                    return 1;
                }
            }
            //BOTTOM
            else if (r >=30 && (c > 0 || c < 30))
            {
                if (passableWays.Contains("DOWN") && (c >= 14 && c <= 17))
                {
                    return 4;
                }
                else
                {
                    return 2;
                }
            }
            //LEFT
            else if (c <=1 && (r > 0 || r < 30))
            {
                if (passableWays.Contains("LEFT") && (r >= 14 && r <= 17))
                {
                    return 4;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                //return -1;  //This is going to crash the damn thing, but...
                return 4;
            }
        }
    }

}