using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib._3DHandler
{
    public class KSprite : KModel
    {
        public KSprite(Texture2D text, Effect effect)
            : base(null, text, effect)
        {
            VertexPositionNormalTexture[] verticies = new VertexPositionNormalTexture[4];
            verticies[0].Position = new Vector3(0, 0, 0);
            verticies[0].Normal = new Vector3(0, 1, 0);
            verticies[0].TextureCoordinate = new Vector2(0, 0);

            verticies[1].Position = new Vector3(1, 0, 0);
            verticies[1].Normal = new Vector3(0, 0, 0);
            verticies[1].TextureCoordinate = new Vector2(1, 0);

            verticies[2].Position = new Vector3(1, 1, 0);
            verticies[2].Normal = new Vector3(0, 1, 0);
            verticies[2].TextureCoordinate = new Vector2(1, 1);

            verticies[3].Position = new Vector3(0, 1, 0);
            verticies[3].Normal = new Vector3(0, 1, 0);
            verticies[3].TextureCoordinate = new Vector2(0, 1);

            int[] indexes = { 0, 1, 3, 1, 2, 3, 3, 1, 0, 3, 2, 1 };

            this.mesh = new KMesh("meshText", verticies, indexes);
        }
    }
}