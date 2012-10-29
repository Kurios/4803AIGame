using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeMaker
{

    public class Gridspace
    {
        //private int x,y;
        public Gridspace()
        {
            x = 0;
            y = 0;
        }

        public Gridspace(int newX, int newY)
        {
            x = newX;
            y = newY;
        }

        public int x
        {
            get;
            set;
        }

        public int y
        {
            get;
            set;
        }

        public bool equals(Gridspace b)
        {
            if(this.x==b.x&&this.y==b.y)
            {
                return true;
            }
            return false;
        }

        public String toString()
        {
            String returned = "Gridspace: (" + x + ", " + y + ")";
            return returned; 
        }


    }
}
