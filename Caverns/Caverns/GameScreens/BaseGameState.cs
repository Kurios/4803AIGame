using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KuriosityXLib;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using KuriosityXLib.Control;
using Microsoft.Xna.Framework;

namespace Caverns.GameScreens
{
    class BaseGameState : GameState
    {
        #region Fields

        protected Game1 gameref;
        

        #endregion
        
        #region Properties

        

        #endregion

        #region Constructor

        public BaseGameState(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
            gameref = game;
        }

        #endregion
        #region XNA Method Region
        
        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        #endregion


    }
}
