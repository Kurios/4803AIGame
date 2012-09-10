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


namespace KuriosityXLib.Control
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
        public class LinkLabel : Control
        {
            #region Fields and Properties
            Color selectedColor = Color.Red;
            public Color SelectedColor

            {
                get { return selectedColor; }
                set { selectedColor = value; }
            }

            #endregion
            #region Constructor Region
            
            public LinkLabel()
            {
                TabStop = true;
                HasFocus = false;
                Position = Vector2.Zero;
            }
            
            #endregion
            #region Abstract Methods
            
            public override void Update(GameTime gameTime)
            {
            }
            
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
            #endregion
    }
}
