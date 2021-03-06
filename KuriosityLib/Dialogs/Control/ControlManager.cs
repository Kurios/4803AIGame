using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KuriosityXLib.Control
{
    /// <summary>
    /// This is a game component that implements List \<Control\>
    /// </summary>
    public class ControlManager : List<Control>
    {
        #region Fields and Properties

        public int selectedControl = 0;

        private static SpriteFont spriteFont;

        public static SpriteFont SpriteFont
        {
            get { return spriteFont; }
        }

        #endregion Fields and Properties

        #region Constructors

        public ControlManager(SpriteFont font)
            : base()
        {
            spriteFont = font;
        }

        public ControlManager(SpriteFont font, int capacity)
            : base(capacity)
        {
            spriteFont = font;
        }

        public ControlManager(SpriteFont font, IEnumerable<Control> collection)
            : base(collection)
        {
            spriteFont = font;
        }

        #endregion Constructors

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control c in this)
            {
                if (c.Visible)
                    c.Draw(spriteBatch);
            }
        }

        public void NextControl()
        {
            if (Count == 0)
                return;
            int currentControl = selectedControl;
            this[selectedControl].HasFocus = false;
            do
            {
                selectedControl++;
                if (selectedControl == Count)
                    selectedControl = 0;
                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                    break;
            } while (currentControl != selectedControl);
            this[selectedControl].HasFocus = true;
        }

        public void PreviousControl()
        {
            if (Count == 0)
                return;
            int currentControl = selectedControl;
            this[selectedControl].HasFocus = false;
            do
            {
                selectedControl--;
                if (selectedControl < 0)
                    selectedControl = Count - 1;
                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                    break;
            } while (currentControl != selectedControl);
            this[selectedControl].HasFocus = true;
        }

        public void Update(GameTime time)
        {
            if (Count == 0) return;
            foreach (Control c in this)
            {
                if (c.Enabled) c.Update(time);
                if (c.HasFocus) c.HandleInput();
            }

            if (InputHandler.KeyPressed(Keys.Up))
                PreviousControl();
            else if (InputHandler.KeyPressed(Keys.Down))
                NextControl();
        }

        #endregion Methods
    }
}