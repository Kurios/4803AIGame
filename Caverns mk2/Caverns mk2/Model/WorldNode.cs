using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace Caverns_mk2.Model
{
    /// <summary>
    ///  This class represents a specific "world within a world". The problem, of course with this atitude is it may be confusing to keep track of who actually is the world...
    /// </summary>
    internal class WorldNode
    {
        /// <summary>
        /// This more or less is our links in our graph... It is key'd by the nromal
        /// </summary>
        public Dictionary<Vector3, WorldNode> Links = new Dictionary<Vector3, WorldNode>();
        /// <summary>
        ///  This is the children nodes in the graph.... It is key'd by the median value of the child (relative weighted position ).
        /// </summary>
        public Dictionary<Vector3, WorldNode> Children = new Dictionary<Vector3, WorldNode>();


        public LinkedList<Portal> Edges = new LinkedList<Portal>();
        public WorldNode Parent = null;
        public int Depth;

        public Terrain TerrainType;

        public LinkedList<Vector3> Corners = new LinkedList<Vector3>();

        public String Name;

        
        /// <summary>
        /// Initializes a empty WorldNode
        /// </summary>
        /// <param name="name">The name of this, new worldnode</param>
        /// <param name="parent">The Parent Node</param>
        public WorldNode(String name, WorldNode parent)
        {
            this.Name = name;
            this.Parent = parent;
            if (parent != null) Depth = parent.Depth + 1;
        }

        public enum Terrain
        {
            Grass, Forest, Sand, Dirt, Stone
        }
    }
}
