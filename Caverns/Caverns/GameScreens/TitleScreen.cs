using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using KuriosityXLib;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using KuriosityXLib.Control;

namespace Caverns.GameScreens
{
    class TitleScreen : BaseGameState
    {
        #region Field

        Texture2D backgroundImage;
        LinkLabel newLabel;
        LinkLabel continueLabel;

        ControlManager controlManager;

        ControlManager ControlManager
        {
            get { return controlManager; }
        }

        #endregion

        #region Contstructor

        public TitleScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion
        #region XNA Methods

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
            //newLabel.Selected += new EventHandler(newLabel_Selected);
         
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

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            ControlManager.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            gameref.SpriteBatch.Begin();

            base.Draw(gameTime);

            

            gameref.SpriteBatch.Draw(backgroundImage, gameref.ScreenRect, Color.White);

            controlManager.Draw(gameref.SpriteBatch);

            gameref.SpriteBatch.End();
        }
        #endregion
    }
}
