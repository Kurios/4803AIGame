using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeMaker
{
    class MazeTester
    {
        static void Main()
        {
            Console.WriteLine("YO!");


            Maze m = new Maze(2, 3);
            m.generateMazePrim(0, 0);
            //Console.WriteLine(m.mazeWalls.Count);
            m.print();
            //m.createMazePrim(1, 2);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
