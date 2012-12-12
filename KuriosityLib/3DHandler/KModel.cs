using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib._3DHandler
{
    public class KModel
    {
        public Effect effect;
        public KMesh mesh;
        public PrimitiveType primitiveType = PrimitiveType.LineStrip;
        public Texture2D texture;
        private Vector3 position;
        private EffectParameter xProjection;

        private EffectParameter xView;

        private EffectParameter xWorld;

        public KModel(KMesh mesh, Texture2D text, Effect effect)
        {
            this.mesh = mesh;
            this.texture = text;
            this.effect = effect;
            xProjection = effect.Parameters["xProjection"];
            xView = effect.Parameters["xView"];
            xWorld = effect.Parameters["xWorld"];
            effect.Parameters["xTexture"].SetValue(texture);
            this.Position = Vector3.Zero;
            this.Facing = Vector3.Left;
            this.Scale = new Vector3(1, 1, 1);
        }

        public Vector3 Facing { get; set; }

        public Vector3 Position { get { return position; } set { value.Normalize(); position = value; } }

        public Vector3 Scale { get; set; }

        public void Render(GraphicsDevice device)
        {
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawUserIndexedPrimitives(primitiveType, mesh.verticies, 0, mesh.verticies.Length, mesh.Indicies, 0, mesh.verticies.Length - 1 , VertexPositionNormalTexture.VertexDeclaration);
            }
        }

        public void Update(Camera cam)
        {
            if (xProjection == null) throw new Exception("Holey Shit... Theres no projection... dispite the fact that there actually is... Did I mention my computer is going mad? ");
            if (cam == null) throw new Exception("We have no camera object");
            if (cam.Projection == null) throw new Exception("The camera contains no Projection Matrix");
            if (!(cam.Projection is Matrix)) throw new Exception("Somehow my matrix isnt a matrix... ");
            Matrix toBeCopied = cam.Projection;
            xProjection.SetValue(toBeCopied);
            xView.SetValue(cam.View);
            Matrix worldMatrix = Matrix.CreateWorld(Position, Facing, Vector3.Up) * Matrix.CreateScale(Scale);
            xWorld.SetValue(worldMatrix);
        }
    }
}