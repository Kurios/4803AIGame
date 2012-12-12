using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Caverns_mk2.Model;
using Caverns_mk2.View;
using Caverns_mk2.Controller;

namespace Caverns_mk2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Caverns : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private GameModel model;
        private GameView view;
        private GameController controller;

        public Caverns()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            model = new GameModel();
            view = new GameView();
            controller = new GameController();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateBlue);
            view.Draw(GraphicsDevice);
            base.Draw(gameTime);

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
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Effect baseEffect = Content.Load<Effect>("shaders/Basic3DShader");
            baseEffect.CurrentTechnique = baseEffect.Techniques["RenderSomething"];
            //view.ChangeEffect(baseEffect);

            World node = new World();
            node.Edges.AddLast(new Portal(new Vector3(-1f,-1f,-1),new Vector3(-1f,1f,0)));
            node.Edges.AddLast(new Portal(new Vector3(1f,-1f,1),new Vector3(-1f,-1f,0)));
            node.Edges.AddLast(new Portal(new Vector3(1f,1f,1f),new Vector3(1f,-1f,1f)));
            node.Edges.AddLast(new Portal(new Vector3(-1f,1f,-1),new Vector3(1f,1f,0)));
            
            node.TerrainType = WorldNode.Terrain.Sand;

            NodeRenderer renderer = new NodeRenderer(baseEffect);
            renderer.AddNode(node);
            view.addRenderer(renderer);
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

            model.Update(gameTime);
            controller.Update(model);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
    }
}