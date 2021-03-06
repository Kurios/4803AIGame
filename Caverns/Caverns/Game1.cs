using Caverns.GameScreens;
using KuriosityXLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SocialSim.Networks;
using SocialSim;
using KuriosityXLib.Dialogs;

///Kurios: The starting point.
///Credit to where credit is due!
///
///http://xnagpa.net/xna4rpg.php
///9/5/2012
///Not Intended for resale or distrobution for profit. (At the moment). Consider this a MIT style licence.
///
namespace Caverns
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region XNA Fields

        public readonly Rectangle ScreenRect;
        private GameStateManager gameStateManager;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        #endregion XNA Fields

        #region GameStates

        private MapScreen mapScreen;
        private TitleScreen titleScreen;

        public DialogScreen DialogScreen { get; set; }

        public TimedInfoScreen InfoScreen { get; set; }

        public SocialNetwork Network;

        public SocialNetworkList Networks;

        public SocialSimPack SocialSimStuff;

        public MapScreen MapScreen
        {
            get { return mapScreen; }
        }

        #endregion GameStates

        public Game1()
        {
            //SOCIAL SIM STUFF
            SocialSimPack simPack = new SocialSimPack();
            SocialSimStuff = simPack;
            Networks = simPack.networks;
            Network = simPack.networks.getSocialNetwork(0);
            //END
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            //graphics.ToggleFullScreen();

            //graphics.GraphicsDevice.
            graphics.SynchronizeWithVerticalRetrace = false;
            this.IsFixedTimeStep = false;

            //this.TargetElapsedTime = this.TargetElapsedTime.TotalSeconds 2;
            graphics.ApplyChanges();

            ScreenRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            Content.RootDirectory = "Content";

            Components.Add(new InputHandler(this));

            gameStateManager = new GameStateManager(this);
            Components.Add(gameStateManager);

            EtaProductionsScreen etaScreen = new EtaProductionsScreen(this, gameStateManager);
            mapScreen = new MapScreen(this, gameStateManager);
            titleScreen = new TitleScreen(this, gameStateManager);
            InfoScreen = new TimedInfoScreen(this, gameStateManager);
            InfoScreen.addElement("", 1);
            InfoScreen.addElement("3...", 1);
            InfoScreen.addElement("3... 2...", 1);
            InfoScreen.addElement("3... 2... 1...", 1);
            InfoScreen.addElement("3... 2... 1... \n\n         Ready or not! Here I come!", 1);
            gameStateManager.ChangeState(titleScreen);
            gameStateManager.PushState(etaScreen);
            gameStateManager.PushState(mapScreen);
            
            DialogScreen = new DialogScreen(this, gameStateManager);

           
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateGray);

            // TODO: Add your drawing code here

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
            if (InputHandler.KeyPressed(Keys.Escape))
                this.Exit();
            if (InputHandler.KeyPressed(Keys.RightAlt) && InputHandler.KeyPressed(Keys.Enter))
                graphics.ToggleFullScreen();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
    }
}