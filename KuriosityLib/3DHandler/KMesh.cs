using System;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib._3DHandler
{
    public class KMesh
    {
        public int[] Indicies;
        public String Name;
        public VertexPositionNormalTexture[] verticies;

        public KMesh(String name, VertexPositionNormalTexture[] verticies, int[] indicies)
        {
            this.Name = name;
            this.verticies = verticies;
            this.Indicies = indicies;
        }
    }
}