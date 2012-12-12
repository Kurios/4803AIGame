using System;
using System.Collections.Generic;
using KuriosityXLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.GameScreens
{
    public class TimedInfoScreen : BaseGameState
    {
        private Texture2D backgroundText;

        private byte blue = 0;

        private Queue<DisplayElement> elements = new Queue<DisplayElement>();

        private SpriteFont font;

        private Texture2D foregroundText;

        private byte green = 0;

        private Texture2D middleText;

        private byte red = 0;

        private TimeSpan span = new TimeSpan();

        public TimedInfoScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
        }

        public void addElement(string text, int time)
        {
            elements.Enqueue(new DisplayElement(text, time));
        }

        public override void Draw(GameTime gameTime)
        {
            gameref.SpriteBatch.Begin();

            gameref.SpriteBatch.Draw(middleText, gameref.ScreenRect, Color.Black);
            if (elements.Count > 0)
                gameref.SpriteBatch.DrawString(font, elements.Peek().String, new Vector2(100, 100), Color.White);
            gameref.SpriteBatch.End();
            base.Draw(gameTime);
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

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            base.LoadContent();

            //backgroundText = Content.Load<Texture2D>("backgrounds/Lensflare");
            middleText = Content.Load<Texture2D>("backgrounds/cloudText");
            font = Content.Load<SpriteFont>("font/dialog");

            //foregroundText = Content.Load<Texture2D>("backgrounds/Top");
        }

        private class DisplayElement
        {
            public int seconds;
            public string String;

            public DisplayElement(string str, int time)
            {
                this.String = str;
                this.seconds = time;
            }
        }
        ;
    }
}