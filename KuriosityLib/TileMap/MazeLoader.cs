using System;
using System.Collections.Generic;
using MazeMaker;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

            //SubMapFactory submaps = fillSubMapsWithMaze(tiles, m, passes);
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

        private static SubMapFactory fillSubMaps(TileFactory tileSet, Maze mint, List<Wall> passes)
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
                            submaps.setTile(c, r, tile, (y * mint.xDimension) + x);
                        }
                    }
                    submaps.AddSubMap();
                }
            }
            return submaps;
        }

        private static SubMapFactory fillSubMapsWithMaze(TileFactory tileSet, Maze mint, List<Wall> passes)
        {
            SubMapFactory submaps = new SubMapFactory(tileSet);

            //Row submap
            for (int y = 0; y < mint.yDimension; y++)
            {
                //Col submap
                for (int x = 0; x < mint.xDimension; x++)
                {
                    Gridspace gs = new Gridspace(x, y);

                    //This is the maze that must be generated within the submap.
                    Maze subMaze = new Maze(8, 8);
                    subMaze.generateMazePrim(0, 0);

                    //Row of a submap
                    for (int r = 0; r < 32; r++)
                    {
                        //Col of a submap
                        for (int c = 0; c < 32; c++)
                        {
                            //What submaze tile are we looking at?
                            int subX = getSubMazeX(c);
                            int subY = getSubMazeY(r);
                            Gridspace subGrid = new Gridspace(subX, subY);
                            int tile = getTile(c, r, mint, gs, passes);
                            submaps.setTile(c, r, tile, (y * mint.xDimension) + x);
                            if (c > 0 && c < 31 && r > 0 && r < 31)   //If it is not a wall...
                            {
                                tile = getSubMazeTile(c, r, subMaze, subGrid, subMaze.getAdjPassages(subGrid));
                                submaps.setTile(c, r, tile, (y * mint.xDimension) + x);
                            }
                        }
                    }
                    submaps.AddSubMap();
                }
            }
            return submaps;
        }

        private static TileFactory fillTileFactory(Texture2D spriteMap)
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

        private static List<String> getOpenSpaces(Maze mint, Gridspace gspace, List<Wall> passableWalls)
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

        private static int getSubMazeTile(int cc, int rr, Maze mint, Gridspace gspace, List<Wall> passableWalls)
        {
            List<String> passableWays = getOpenSpaces(mint, gspace, passableWalls);

            //WALL-SPACE
            int c = (cc + 1) % 4;
            int r = (rr + 1) % 4;

            //TOP
            if (r == 1)
            {
                if (passableWays.Contains("UP"))
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }

            //RIGHT
            else if (c == 0)
            {
                if (passableWays.Contains("RIGHT"))
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }

            //BOTTOM
            else if (r == 0)
            {
                if (passableWays.Contains("DOWN"))
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }

            //LEFT
            else if (c == 1)
            {
                if (passableWays.Contains("LEFT"))
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }
            else
            {
                //return -1;  //This is going to crash the damn thing, but...
                Random rand = new Random();
                /*if (rand.Next(0, 10)<=1)
                {
                    return 5;
                }*/
                return 4;
            }
        }

        private static int getSubMazeX(int r)
        {
            if (r >= 0 && r <= 3)
            {
                return 0;
            }
            else if (r > 3 && r <= 7)
            {
                return 1;
            }
            else if (r > 7 && r <= 11)
            {
                return 2;
            }
            else if (r > 11 && r <= 15)
            {
                return 3;
            }
            else if (r > 15 && r <= 19)
            {
                return 4;
            }
            else if (r > 19 && r <= 23)
            {
                return 5;
            }
            else if (r > 23 && r <= 27)
            {
                return 6;
            }
            return 7;
        }

        private static int getSubMazeY(int r)
        {
            if (r >= 0 && r <= 3)
            {
                return 0;
            }
            else if (r > 3 && r <= 7)
            {
                return 1;
            }
            else if (r > 7 && r <= 11)
            {
                return 2;
            }
            else if (r > 11 && r <= 15)
            {
                return 3;
            }
            else if (r > 15 && r <= 19)
            {
                return 4;
            }
            else if (r > 19 && r <= 23)
            {
                return 5;
            }
            else if (r > 23 && r <= 27)
            {
                return 6;
            }
            return 7;
        }

        private static int getTile(int c, int r, Maze mint, Gridspace gspace, List<Wall> passableWalls)
        {
            List<String> passableWays = getOpenSpaces(mint, gspace, passableWalls);

            //TOP
            if (r == 0 && (c > 0 || c < 31))
            {
                if (passableWays.Contains("UP") && (c > 11 && c <= 15))
                {
                    return 4;
                }
                else
                {
                    return 0;
                }
            }

            //RIGHT
            else if (c == 31 && (r > 0 || r < 31))
            {
                if (passableWays.Contains("RIGHT") && (r > 11 && r <= 15))
                {
                    return 4;
                }
                else
                {
                    return 1;
                }
            }

            //BOTTOM
            else if (r == 31 && (c > 0 || c < 31))
            {
                if (passableWays.Contains("DOWN") && (c > 11 && c <= 15))
                {
                    return 4;
                }
                else
                {
                    return 2;
                }
            }

            //LEFT
            else if (c == 0 && (r > 0 || r < 31))
            {
                if (passableWays.Contains("LEFT") && (r >= 11 && r <= 15))
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
                Random rand = new Random();
                /*if (rand.Next(0, 10)<=1)
                {
                    return 5;
                }*/
                return 4;
            }
        }
    }
}