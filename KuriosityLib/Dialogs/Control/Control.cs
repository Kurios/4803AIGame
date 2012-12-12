using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib.Control
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public abstract class Control
    {
        #region Fields

        protected Color color;
        protected bool enabled;
        protected bool hasFocus;
        protected string name;
        protected Vector2 position;
        protected Vector2 size;
        protected SpriteFont spriteFont;
        protected bool tabStop;
        protected string text;
        protected string type;
        protected object value;
        protected bool visible;

        #endregion Fields

        #region Event

        public event EventHandler Selected;

        #endregion Event

        #region Property

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public bool HasFocus
        {
            get { return hasFocus; }
            set { hasFocus = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }

        public SpriteFont SpriteFont
        {
            get { return spriteFont; }
            set { spriteFont = value; }
        }

        public bool TabStop
        {
            get { return tabStop; }
            set { tabStop = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        #endregion Property

        #region Constructor

        public Control()
        {
            Color = Color.White;
            enabled = true;
            visible = true;
            spriteFont = ControlManager.SpriteFont;
        }

        #endregion Constructor

        #region Abstract Methods

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void HandleInput();

        public abstract void Update(GameTime gameTime);

        #endregion Abstract Methods

        #region Virtual Methods

        protected virtual void OnSelected(EventArgs e)
        {
            if (Selected != null)
            {
                Selected(this, e);
            }
        }

        #endregion Virtual Methods
    }
}