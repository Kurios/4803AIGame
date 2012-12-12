using Microsoft.Xna.Framework;

namespace KuriosityXLib._3DHandler
{
    public class Camera
    {
        public Camera()
            : this(Vector3.UnitX)
        {
        }

        public Camera(Vector3 position)
        {
            cameraPosition = position;
            cameraTarget = Vector3.Zero;
            aspectRatio = 800 / 600;
            update();
        }

        ~Camera()
        {
        }

        public float aspectRatio { get; set; }

        public Vector3 cameraPosition { get; set; }

        public Vector3 cameraTarget { get; set; }

        public Matrix Projection { get; set; }

        public Matrix View { get; set; }

        public void update()
        {
            View = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), aspectRatio, 1.0f, 10000.0f);
        }
    }
}