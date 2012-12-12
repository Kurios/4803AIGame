using System;

namespace MazeMaker
{
    internal class MazeTester
    {
        private static void Main()
        {
            Console.WriteLine("YO!");

            Maze m = new Maze(2, 2);
            m.generateMazePrim(0, 0);

            //Console.WriteLine(m.mazeWalls.Count);
            m.print();

            //m.createMazePrim(1, 2);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}