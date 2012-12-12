using KuriosityXLib._3DHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AI_Idea_Vetting
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class IdeaVett : Microsoft.Xna.Framework.Game
    {
        private Camera camera;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        ///
        private Vector3 cameraPosition = new Vector3(0.0f, 50.0f, 5000.0f);

        private GraphicsDeviceManager graphics;
        private KModel model;
        private KSprite model2;
        private float rot = 0;
        private SpriteBatch spriteBatch;

        public IdeaVett()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Draw(GameTime gameTime)
        {
            model.Update(camera);
            model2.Update(camera);
            GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.DarkSlateBlue, 1.0f, 0);

            model.Render(GraphicsDevice);
            model2.Render(GraphicsDevice);

            // TODO: Add your drawing code here
            //View = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
            //Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), aspectRatio, 1.0f, 10000.0f);
            base.Draw(gameTime);

            //myModel.Draw(Matrix.Identity,Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up),Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), 1.2f, 1.0f, 10000.0f));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// Model myModel;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            VertexPositionNormalTexture[] verticies = new VertexPositionNormalTexture[4];
            verticies[0].Position = new Vector3(-1, 0, 0);
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
            Texture2D texture = Content.Load<Texture2D>("images");
            Effect effect = Content.Load<Effect>("Basic3DShader");
            effect.CurrentTechnique = effect.Techniques["TexturedNoShading"];
            KMesh mesh = new KMesh("Rectangle", verticies, indexes);
            model = new KModel(mesh, texture, effect);

            model2 = new KSprite(texture, effect);
            model2.Position = new Vector3(2, 0, 0);
            camera = new Camera(new Vector3(0, 0, -10));

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            camera.cameraPosition = Vector3.Transform(new Vector3(0, 0, 10), Matrix.CreateRotationY(rot));
            camera.update();
            rot += .01f;
            if (rot > MathHelper.Pi * 2) rot = 0;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
    }
}