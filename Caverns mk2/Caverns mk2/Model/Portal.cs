using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Caverns_mk2.Model
{
    class Portal
    {
        public Vector3 A;
        public Vector3 B;

        public Portal(Vector3 a, Vector3 b)
        {
            // TODO: Complete member initialization
            A = a;
            B = b;
        }
        public Vector3 Normal { get { return Vector3.Cross(A, B); } }
    }
}
