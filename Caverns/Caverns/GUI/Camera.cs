using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Caverns;

using KuriosityXLib.TileMap;

namespace KuriosityXLib.TileMap
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Camera : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Fields

        Game1 game;
        Map map;


        Rectangle position;

        Rectangle Position
        {
            get { return Position; }
            set { position = value; }
        }

        #endregion

        public Camera(Game1 game, Map map)
            : base(game)
        {
            this.game = game;
            this.map = map;

            position = new Rectangle(0, 0, (game.GraphicsDevice.DisplayMode.Width / 32) + 1, (game.GraphicsDevice.DisplayMode.Height / 32) + 1);
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

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            game.SpriteBatch.Begin();
            for (int x = 0; 0 < position.Width; x++) {
                for (int y = 0; 0 < position.Height; y++)
                {
                    map.getTile(x, y).Draw(game.SpriteBatch, 1);
                }
            }
            
        }
    }
}
