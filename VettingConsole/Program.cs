using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VettingConsole
{
    class Program
    {

        

        static void Main(string[] args)
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
