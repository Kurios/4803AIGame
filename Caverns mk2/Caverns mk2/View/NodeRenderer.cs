using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Caverns_mk2.Model;
using Microsoft.Xna.Framework;
using KuriosityXLib._3DHandler;


namespace Caverns_mk2.View
{

    class NodeRenderer
    {
        LinkedList<WorldNode> Nodes = new LinkedList<WorldNode>();
        Effect effect;
        Camera cam;


        public NodeRenderer(Effect effect)
        {
            this.effect = effect;
        }


        public void AddNode(WorldNode node)
        {
            Nodes.AddLast(node);
        }

        public void Draw(GraphicsDevice device)
        {
            if (Nodes.Count > 0)
            {
                foreach (WorldNode node in Nodes)
                {
                    VertexPositionNormalTexture[] primitiveList = new VertexPositionNormalTexture[node.Edges.Count];
                    int i = 0;
                    Color color = Color.Black;
                    switch (node.TerrainType)
                    {
                        case WorldNode.Terrain.Dirt: color = Color.SaddleBrown; break;
                        case WorldNode.Terrain.Forest: color = Color.ForestGreen; break;
                        case WorldNode.Terrain.Grass: color = Color.YellowGreen; break;
                        case WorldNode.Terrain.Sand: color = Color.SeaShell; break;
                        case WorldNode.Terrain.Stone: color = Color.Silver; break;
                    }
                    Texture2D text = new Texture2D(device, 2, 2);
                    Color[] data = new Color[4];
                    List<int> indexes = new List<int>();
                    text.GetData<Color>(data);
                    for (int c = 0; c < data.Length; c++)
                        data[c] = color;
                    text.SetData<Color>(data);
                    foreach (Portal p in node.Edges)
                    {
                        primitiveList[i].TextureCoordinate = new Vector2(p.A.X,p.A.Y);
                        primitiveList[i].Position = p.A;
                        primitiveList[i].Normal = new Vector3(0, 0, 0);
                        indexes.Add(i);
                        i++;
                    }
                    KMesh mesh = new KMesh("floorText", primitiveList, indexes.ToArray());
                    KModel model = new KModel(mesh, text, effect);
                    model.Update(cam);
                    model.Render(device);
                    
                    
                }
            }
        }

        internal void Update(Camera cam)
        {
            this.cam = cam;
        }
    }
}
