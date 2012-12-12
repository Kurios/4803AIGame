using System;
using KuriosityXLib;
using KuriosityXLib.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.GameScreens
{
    internal class TitleScreen : BaseGameState
    {
        #region Field

        private Texture2D backgroundImage;
        private LinkLabel continueLabel;
        private ControlManager controlManager;
        private LinkLabel newLabel;

        private ControlManager ControlManager
        {
            get { return controlManager; }
        }

        #endregion Field

        #region Contstructor

        public TitleScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion Contstructor

        #region XNA Methods

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            gameref.SpriteBatch.Begin();

            base.Draw(gameTime);

            gameref.SpriteBatch.Draw(backgroundImage, gameref.ScreenRect, Color.White);

            controlManager.Draw(gameref.SpriteBatch);

            gameref.SpriteBatch.End();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            ControlManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            ContentManager content = gameref.Content;
            backgroundImage = content.Load<Texture2D>("backgrounds/titleScreen2");

            base.LoadContent();

            SpriteFont menuFont = content.Load<SpriteFont>("font/title");
            controlManager = new ControlManager(menuFont);

            newLabel = new LinkLabel();
            newLabel.Position = new Vector2(600, 400);
            newLabel.Text = "New Game";
            newLabel.Color = Color.Brown;
            newLabel.SelectedColor = Color.Chocolate;
            newLabel.TabStop = true;
            newLabel.HasFocus = true;
            newLabel.Selected += new EventHandler(newLabel_Selected);

            ControlManager.Add(newLabel);

            continueLabel = new LinkLabel();
            continueLabel.Position = new Vector2(600, 450);
            continueLabel.Text = "Continue";
            continueLabel.Color = Color.Brown;
            continueLabel.SelectedColor = Color.Chocolate;
            continueLabel.TabStop = true;
            continueLabel.HasFocus = false;

            ControlManager.Add(continueLabel);
        }

        private void newLabel_Selected(Object sender, EventArgs e)
        {
            if (sender == newLabel)
            {
                //GameStateManager.PushState(gameref.MapScreen);
                //GameStateManager.PushState(gameref.InfoScreen);
            }
        }

        #endregion XNA Methods
    }
}