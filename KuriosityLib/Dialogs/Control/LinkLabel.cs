using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KuriosityXLib.Control
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class LinkLabel : Control
    {
        #region Fields and Properties

        private Color selectedColor = Color.Red;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        #endregion Fields and Properties

        #region Constructor Region

        public LinkLabel()
        {
            TabStop = true;
            HasFocus = false;
            Position = Vector2.Zero;
        }

        #endregion Constructor Region

        #region Abstract Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (hasFocus)
                spriteBatch.DrawString(SpriteFont, Text, Position, selectedColor);
            else
                spriteBatch.DrawString(SpriteFont, Text, Position, Color);
        }

        public override void HandleInput()
        {
            if (!HasFocus)
                return;
            if (InputHandler.KeyReleased(Keys.Enter))
                base.OnSelected(null);
        }

        public override void Update(GameTime gameTime)
        {
        }

        #endregion Abstract Methods
    }
}