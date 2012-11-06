using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib.Control
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Label : Control
    {
        #region Constructor Region

        public Label()
        {
            tabStop = false;
        }

        #endregion Constructor Region

        #region Abstract Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Text, Position, Color);
        }

        public override void HandleInput()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        #endregion Abstract Methods
    }
}