using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using KuriosityXLib._3DHandler;
using Microsoft.Xna.Framework;

namespace Caverns_mk2.View
{
    class GameView
    {
        Effect effect;
        Camera cam = new Camera();

        LinkedList<NodeRenderer> renderers = new LinkedList<NodeRenderer>();
        float rot = 0;

        internal void Draw(Microsoft.Xna.Framework.Graphics.GraphicsDevice GraphicsDevice)
        {
            /*
            int points = 10;
            VertexPositionColor[] primitiveList = new VertexPositionColor[points];

            for (int x = 0; x < points / 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    primitiveList[(x * 2) + y] = new VertexPositionColor(
                        new Vector3(x * 100, y * 100, 0), Color.White);
                }
            }
            Matrix viewMatrix = Matrix.CreateLookAt(new Vector3(0.0f, 0.0f, 1.0f), Vector3.Zero, Vector3.Up);
            Matrix projectionMatrix = Matrix.CreateOrthographicOffCenter(0, (float)GraphicsDevice.Viewport.Width, (float)GraphicsDevice.Viewport.Height, 0, 1.0f, 1000.0f);
            // Initialize an array of indices of type short.
            short[] lineListIndices = new short[(points * 2) - 2];

            // Populate the array with references to indices in the vertex buffer
            for (int i = 0; i < points - 1; i++)
            {
                lineListIndices[i * 2] = (short)(i);
                lineListIndices[(i * 2) + 1] = (short)(i + 1);
            }

            GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                PrimitiveType.LineList,
                primitiveList,
                0,  // vertex buffer offset to add to each element of the index buffer
                8,  // number of vertices in pointList
                lineListIndices,  // the index buffer
                0,  // first index element to read
                7   // number of primitives to draw
            );
            */

            cam.cameraPosition = new Vector3((float)Math.Cos(rot) * 10,(float)Math.Sin(rot) * 10,(float)Math.Sin(rot));
            cam.cameraTarget = new Vector3(0, 0, 0);
            rot += .1f;
            cam.update();
            foreach (NodeRenderer node in renderers)
            {
                node.Update(cam);
            }
           // This is the draw-y code...
           //DrawNodes();
            foreach (NodeRenderer node in renderers)
            {
                node.Draw(GraphicsDevice);
            }

        }

        internal void ChangeEffect(Microsoft.Xna.Framework.Graphics.Effect baseEffect)
        {
            effect = baseEffect;
        }

        internal void addRenderer(NodeRenderer renderer)
        {
            renderers.AddLast(renderer);
        }
    }
}
