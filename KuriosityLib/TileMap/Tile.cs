using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Standard Zelda Tile - 32x32

namespace KuriosityXLib.TileMap
{
    public class Tile
    {
        #region fields

        private Vector2 position;

        /*
        int type;

        int Type
        {
            get{ return type; }
        }
        */

        public Rectangle accentText { get; set; }

        public Rectangle baseText { get; set; }

        public bool Explored { get; set; }

        public bool Passible { get; set; }

        public Texture2D spriteResource { get; set; }

        public Rectangle topText { get; set; }

        private Vector2 Position
        {
            get { return position; }
        }

        #endregion fields

        #region constructor

        public Tile(int x, int y, Rectangle baseText, Texture2D spriteRebaseText)
        {
            position = new Vector2(x, y);
            this.baseText = baseText;
            this.spriteResource = spriteRebaseText;
        }

        #endregion constructor

        public void Draw(SpriteBatch spriteBatch, Point pos, Point offset, float scale, Color color)
        {
            //spriteBatch.Begin();
            //Console.WriteLine(baseText);
            spriteBatch.Draw(spriteResource, new Rectangle((pos.X - offset.X) * (int)(baseText.Width * scale), (pos.Y - offset.Y) * (int)(baseText.Height * scale), (int)(baseText.Width * scale), (int)(baseText.Height * scale)), baseText, color);

            if (!accentText.IsEmpty) spriteBatch.Draw(spriteResource, new Rectangle((pos.X - offset.X) * (int)(accentText.Width * scale), (pos.Y - offset.Y) * (int)(accentText.Height * scale), (int)(accentText.Width * scale), (int)(accentText.Height * scale)), accentText, color);

            if (!topText.IsEmpty) spriteBatch.Draw(spriteResource, new Rectangle((pos.X - offset.X) * (int)(topText.Width * scale), (pos.Y - offset.Y) * (int)(topText.Height * scale), (int)(topText.Width * scale), (int)(topText.Height * scale)), topText, color);

            //spriteBatch.End();
        }
    }
}