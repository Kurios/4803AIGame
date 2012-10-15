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

    public class TimedInfoScreen : BaseGameState
    {

        private class DisplayElement
        {
            public string String;
            public int seconds;

            public DisplayElement(string str, int time)
            {
                this.String = str;
                this.seconds = time;
            }
        }
        ;

        Texture2D backgroundText;
        Texture2D middleText;
        Texture2D foregroundText;
        SpriteFont font;
        byte red = 0;
        byte green = 0;
        byte blue = 0;

        Queue<DisplayElement> elements = new Queue<DisplayElement>();

        public TimedInfoScreen(Game1 game, GameStateManager manager) : base(game, manager) { }


        TimeSpan span = new TimeSpan();

        public void addElement(string text, int time)
        {
            elements.Enqueue(new DisplayElement(text, time));
        }
        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            base.LoadContent();
            //backgroundText = Content.Load<Texture2D>("backgrounds/Lensflare");
            middleText = Content.Load<Texture2D>("backgrounds/cloudText");
            font = Content.Load<SpriteFont>("font/dialog");
            //foregroundText = Content.Load<Texture2D>("backgrounds/Top");

        }
        public override void Update(GameTime gameTime)
        {
            TimeSpan second = new TimeSpan(0, 0, 1);
            span += gameTime.ElapsedGameTime;

            if (span > second)
            {
                span -= second;

                if (elements.Peek() == null)
                    GameStateManager.PopState();
                else if (elements.Peek().seconds > 0)
                    elements.Peek().seconds--;
                else
                    elements.Dequeue();

                if (elements.Peek() == null)
                    GameStateManager.PopState();

            }
            //gameref.
            base.Update(gameTime);
            
        }
        public override void Draw(GameTime gameTime)
        {


            gameref.SpriteBatch.Begin();

            gameref.SpriteBatch.Draw(middleText, gameref.ScreenRect, Color.Black);
            if(elements.Count > 0)
                gameref.SpriteBatch.DrawString(font, elements.Peek().String, new Vector2(100, 100), Color.White);
            gameref.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
