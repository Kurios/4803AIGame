using System;

namespace VettingConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Init Stuffs
            Agent bob = new Agent();

            //Start the program.
            Console.WriteLine("Hello World");
            while (true)
            {
                String line = Console.ReadLine();
                bob.listen(line);
                if (bob.hasResonse())
                {
                    Console.Write(bob.respond() + "\n");
                }
            }
        }
    }
}