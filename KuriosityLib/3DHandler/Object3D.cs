using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib._3DHandler
{
    public class Object3D
    {
        public Camera camera;
        public Effect effect;
        public Model model;

        public Object3D(Camera cam)
        {
            camera = cam;
        }

        ~Object3D()
        {
        }

        public Vector3 Position { get; set; }

        public Vector3 Rotation { get; set; }

        public void Draw(GraphicsDevice device)
        {
            Matrix World = Matrix.CreateRotationX(Rotation.X) * Matrix.CreateRotationY(Rotation.Y) * Matrix.CreateRotationZ(Rotation.Z) * Matrix.CreateTranslation(Position);
            model.Draw(World, camera.View, camera.Projection);
            /*
            foreach(ModelMesh mesh in model.Meshes) {
                foreach(Effect meffect in mesh.Effects)
                {
                    if (meffect is BasicEffect)
                    {
                        //We treat it as a BasicEffect
                        foreach(EffectPass pass in effect.CurrentTechnique.Passes)
                        {
                            pass.Apply();
                            model.Draw();
                    }
                    else
                    {
                        //We set parameters by hand...
                    }
                }
                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3, VertexPositionColor.VertexDeclaration);
                }
            }
             */
        }

        public void loadModel()
        {
        }
    }
}