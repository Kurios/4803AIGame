using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeMaker
{
    public class Wall
    {
        //Wall has two Gridspaces
       // List<Gridspace> adjCells;
        public Wall(Gridspace A)
        {
            GridspaceA = A;
        }
        public Wall(Gridspace A, Gridspace B)
        {
            GridspaceA = A;
            GridspaceB = B;
        }

        public Gridspace GridspaceA
        {
            get;
            set;
        }
        public Gridspace GridspaceB
        {
            get;
            set;
        }

        public bool equals(Wall w)
        {
            if (this.GridspaceA.equals(w.GridspaceA))
            {
                if (this.GridspaceB.equals(w.GridspaceB))
                {
                    return true;
                }
            }

            if (this.GridspaceB.equals(w.GridspaceA))
            {
                if (this.GridspaceA.equals(w.GridspaceB))
                {
                    return true;
                }
            }
            return false;
        }

        public Gridspace getOppositeSpace(Gridspace gs)
        {
            if (GridspaceA.equals(gs))
            {
                return GridspaceB;
            }
            else
            {
                return GridspaceA;
            }
        }
        public String toString()
        {
            String returned = "WALL: [" + GridspaceA.toString() + ", " + GridspaceB.toString() + "]";
            return returned;
        }
    }
}
