using Caverns;
using KuriosityXLib._3DHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib.TileMap
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class MapCamera : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Fields

        internal Camera camera;
        private Vector4[] data;
        private Character focus;
        private Game1 game;
        private Map map;
        private Texture2D mapDef;
        private Rectangle position;
        private KSprite sprite;

        public Color Color { get; set; }

        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle ScreenDef { get; set; }

        #endregion Fields

        public MapCamera(Game1 game, Map map)
            : base(game)
        {
            this.game = game;
            this.map = map;
            position = new Rectangle(0, 0, (game.ScreenRect.Width / 32) + 1, (game.ScreenRect.Height / 32) + 1);
            ScreenDef = new Rectangle(0, 0, (game.ScreenRect.Width / 32) + 1, (game.ScreenRect.Height / 32) + 1);
            Color = Color.White;
            this.camera = new Camera(new Vector3(0, 0, -10));
            LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (focus != null)
            {
                Position = new Rectangle((int)focus.Position.X - ScreenDef.Width / 2, (int)focus.Position.Y - ScreenDef.Height / 2, Position.Width, Position.Height);

                //And Make sure it doesnt go off the map
                if (Position.X < 1)
                    position.X = 1;
                if (Position.Y < 1)
                    position.Y = 1;
                if ((Position.X + (Position.Width / 2)) > map.Width)
                    position.X = map.Width - Position.Width / 2;
                if ((Position.Y + (Position.Height / 2)) > map.Height)
                    position.Y = map.Height - Position.Height / 2;
            }
            for (int x = Position.X; x < position.Width + Position.X; x++)
            {
                for (int y = Position.Y; y < position.Height + Position.Y; y++)
                {
                    if (map.getTile(x, y) != null)
                    {
                        //map.getTile(x, y).Draw(game.SpriteBatch, new Point(x, y), position.Location, 1, Color);
                        //map.getTile(x, y).baseText.X;
                    }
                }
            }

            foreach (Character character in map.characterList)
            {
                if (position.Contains((int)character.Position.X, (int)character.Position.Y))
                {
                    //character.draw(game.SpriteBatch, position.Location);
                }
            }
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public void Render(GraphicsDevice device)
        {
            sprite.Render(device);
        }

        public void SetFocus(Character pc)
        {
            focus = pc;
        }

        public void setMap(Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            camera.update();
            sprite.Update(camera);
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            Effect mapShader = game.Content.Load<Effect>("shaders/Basic3DShader");
            mapShader.CurrentTechnique = mapShader.Techniques["TexturedNoShading"];
            mapDef = game.Content.Load<Texture2D>("tilemap/woodsLandForest");
            sprite = new KSprite(mapDef, mapShader);
            base.LoadContent();
        }
    }
}