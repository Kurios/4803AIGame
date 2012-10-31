using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeMaker
{
    public class Maze
    {

        public Maze(int xDim, int yDim)
        {
            list = new List<Gridspace>();
            mazePassages = new List<Wall>();

            xDimension = xDim;
            yDimension = yDim;
            mazeWalls = getWalls();
            for (int y = 0; y < yDimension; y++)
            {
                for (int x = 0; x < xDimension; x++)
                {
                    Gridspace cell = new Gridspace(x, y);
                    list.Add(cell);
                }
            }
        }

        public List<Gridspace> list
        {
            get;
            set;
        }

        public List<Wall> mazeWalls
        {
            get;
            set;
        }

        public List<Wall> mazePassages
        {
            get;
            set;
        }

        public int xDimension
        {
            get;
            set;
        }

        public int yDimension
        {
            get;
            set;
        }

        public List<Wall> getWalls()
        {
            List<Wall> walls = new List<Wall>();

            for (int y = 0; y < yDimension; y++)
            {
                for (int x = 0; x < xDimension; x++)
                {
                    //Corner-cases
                    Gridspace cell = new Gridspace(x, y);
                    Gridspace botCell = new Gridspace(x, y + 1);
                    Gridspace rightCell = new Gridspace(x + 1, y);
                    Gridspace leftCell = new Gridspace(x - 1, y);
                    Gridspace topCell = new Gridspace(x, y - 1);
                    //Top-left
                    if ((x == 0) && (y == 0))
                    {
                        walls.Add(new Wall(cell, botCell));
                        walls.Add(new Wall(cell, rightCell));
                    }
                    //Bot-left
                    else if ((x == 0) && (y == yDimension))
                    {
                        walls.Add(new Wall(topCell, cell));
                        walls.Add(new Wall(cell, rightCell));
                    }
                    //Top-right
                    else if ((x == xDimension) && (y == 0))
                    {
                        walls.Add(new Wall(cell, botCell));
                        walls.Add(new Wall(leftCell, cell));
                    }
                    //Bot-right
                    else if ((x == xDimension) && (y == yDimension))
                    {
                        walls.Add(new Wall(topCell, cell));
                        walls.Add(new Wall(leftCell, cell));
                    }
                    //General case.
                    else
                    {
                        Wall w = new Wall(topCell, cell);

                        if (!contains((walls), new Wall(topCell, cell)))
                        {
                            if (topCell.y >= 0)
                            {
                                walls.Add(new Wall(topCell, cell));
                            }
                        }
                        if (!contains(walls, new Wall(leftCell, cell)))
                        {
                            if (leftCell.x >= 0)
                            {
                                walls.Add(new Wall(leftCell, cell));
                            }
                        }
                        if (!contains(walls, new Wall(cell, botCell)))
                        {
                            if (botCell.y < yDimension)
                            {
                                walls.Add(new Wall(cell, botCell));
                            }
                        }
                        if (!contains(walls, new Wall(cell, rightCell)))
                        {
                            if (rightCell.x < xDimension)
                            {
                                walls.Add(new Wall(cell, rightCell));
                            }
                        }
                    }
                }
            }
            return walls;
        }

        public bool contains(List<Wall> walls, Wall w)
        {
            foreach (Wall wall in walls)
            {
                if (wall.equals(w))
                {
                    return true;
                }
            }
            return false;
        }

        public bool contains(List<Gridspace> grids, Gridspace gs)
        {
            foreach (Gridspace grid in grids)
            {
                if (grid.equals(gs))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Wall> getAdjWalls(Gridspace gs)
        {
            List<Wall> adjWalls = new List<Wall>();

            foreach (Wall w in mazeWalls)
            {
                if (w.GridspaceA.equals(gs) || w.GridspaceB.equals(gs))
                {
                    adjWalls.Add(w);
                }
            }
            return adjWalls;
        }

        public void generateMazePrim(int startPointX, int startPointY)
        {
            Gridspace startpoint = new Gridspace();
            List<Wall> theWalls = new List<Wall>();
            List<Gridspace> inMaze = new List<Gridspace>();
            if (startPointX < xDimension && startPointY < yDimension)
            {
                startpoint = new Gridspace(startPointX, startPointY);
            }

            //Add start point
            inMaze.Add(startpoint);

            //Starting point's walls.
            foreach (Wall wal in getAdjWalls(startpoint))
            {
                theWalls.Add(wal);
            }
            //The actual Prim's algorithm
            while (theWalls.Count > 0)
            {
                //Wall wall = theWalls[0];
                Random r = new Random();
                int index = r.Next(0, theWalls.Count);
                Wall wall = theWalls[index];
                Gridspace checkToAddA = wall.GridspaceA;
                Gridspace checkToAddB = wall.GridspaceB;

                if (!contains(inMaze,checkToAddA))
                {
                    inMaze.Add(checkToAddA);
                    mazePassages.Add(wall);
                    foreach (Wall wal in getAdjWalls(checkToAddA))
                    {
                        theWalls.Add(wal);
                    }
                }
                else if (!contains(inMaze, checkToAddB))
                {
                    inMaze.Add(checkToAddB);
                    mazePassages.Add(wall);
                    //thePassages.Add(wall);
                    foreach (Wall wal in getAdjWalls(checkToAddB))
                    {
                        theWalls.Add(wal);
                    }
                }
                theWalls.Remove(wall);
            }

            foreach (Wall mazePass in mazePassages)
            {
                if(contains(mazeWalls, mazePass))
                {
                    mazeWalls.Remove(mazePass);
                }
            }
        }

        /*public void createMazePrim(int startPointX, int startPointY)
       {
           List<Gridspace> inMaze = new List<Gridspace>();
           List<Wall> theWalls = new List<Wall>();
           List<Wall> thePassages = new List<Wall>();

           Gridspace startpoint = new Gridspace();
           if (startPointX < xDimension && startPointY < yDimension)
           {
               startpoint = new Gridspace(startPointX, startPointY);
           }

           //Starting point
           inMaze.Add(startpoint);

           //Starting point's walls.
           foreach (Wall wal in getWalls(startpoint))
           {
               theWalls.Add(wal);
           }

           //The actual Prim's algorithm
           while (theWalls.Count > 0)
           {
               Wall wall = theWalls[0];

               Gridspace checkToAdd = new Gridspace(wall.GridspaceB.x, wall.GridspaceB.y);

               if (!inMaze.Contains(checkToAdd))
               {
                   inMaze.Add(checkToAdd);
                   thePassages.Add(wall);
                   foreach (Wall wal in getWalls(checkToAdd))
                   {
                       theWalls.Add(wal);
                   }
               }
               theWalls.Remove(wall);
           }
       }*/

        public void print()
        {
            Console.WriteLine("MAZE: ");
            foreach (Gridspace g in list)
            {
                Console.WriteLine(g.toString());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("WALLS");
            foreach (Wall w in mazeWalls)
            {
                Console.WriteLine(w.toString());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("PASSAGES");
            foreach (Wall pass in mazePassages)
            {
                Console.WriteLine(pass.toString());
            }

        }

        
       
    }
}
