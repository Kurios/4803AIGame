using KuriosityXLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Caverns.GameScreens
{
    public class BaseGameState : GameState
    {
        #region Fields

        protected Game1 gameref;

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructor

        public BaseGameState(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
            gameref = game;
        }

        #endregion Constructor

        #region XNA Method Region

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;

            base.LoadContent();
        }

        #endregion XNA Method Region
    }
}