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
        Character focus;

        Rectangle position;
        public Rectangle ScreenDef { get; set; }

        Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }

        #endregion

        public Camera(Game1 game, Map map)
            : base(game)
        {
            this.game = game;
            this.map = map;

            position = new Rectangle(0, 0, (game.ScreenRect.Width/32) + 1, (game.ScreenRect.Height / 32) + 1);
            ScreenDef = new Rectangle(0, 0, (game.ScreenRect.Width / 32) + 1, (game.ScreenRect.Height / 32) + 1);
            
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

        public void SetFocus(Character pc)
        {
            focus = pc;
        }
        public void setMap(Map map)
        {
            this.map = map;
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if(focus != null)
                Position = new Rectangle((int)focus.Position.X-ScreenDef.Width/2, (int)focus.Position.Y-ScreenDef.Height/2, Position.Width, Position.Height);
            for (int x = Position.X; x < position.Width+Position.X; x++) {
                for (int y = Position.Y; y < position.Height+Position.Y; y++)
                {
                    if(map.getTile(x,y) != null)
                        map.getTile(x, y).Draw(game.SpriteBatch,new Point(x,y), position.Location, 1);
                }
            }
            foreach (Character character in map.characterList)
            {
                if (position.Contains((int)character.Position.X, (int)character.Position.Y))
                {
                    character.draw(game.SpriteBatch,position.Location);
                }
            }
            
        }
    }
}
