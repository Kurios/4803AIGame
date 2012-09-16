using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using KuriosityXLib;

namespace Caverns.GameScreens
{

    class EtaProductionsScreen : BaseGameState
    {

        Texture2D backgroundText;
        Texture2D middleText;
        Texture2D foregroundText;

        byte red = 0;
        byte green = 0;
        byte blue = 0;

        public EtaProductionsScreen(Game1 game, GameStateManager manager) : base(game, manager) { }


        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            base.LoadContent();
            backgroundText = Content.Load<Texture2D>("backgrounds/Lensflare");
            middleText = Content.Load<Texture2D>("backgrounds/cloudText");
            foregroundText = Content.Load<Texture2D>("backgrounds/Top");
            
        }
        public override void Update(GameTime gameTime)
        {
            //gameref.
            base.Update(gameTime);
            if (gameTime.TotalGameTime.Seconds > 2)
                GameStateManager.PopState();
        }
        public override void Draw(GameTime gameTime)
        {
            red += 1;
            green -= 1;
            blue = (byte)((int)red % (int)green);

            gameref.SpriteBatch.Begin();
            gameref.SpriteBatch.Draw(backgroundText, gameref.ScreenRect, Color.White);
            gameref.SpriteBatch.Draw(middleText, gameref.ScreenRect, new Color((int)red, (int)green, (int)blue));
            gameref.SpriteBatch.Draw(foregroundText, gameref.ScreenRect, Color.White);
            gameref.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
