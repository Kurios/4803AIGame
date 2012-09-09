using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Standard Zelda Tile - 32x32

namespace KuriosityXLib.TileMap
{
    public class Tile
    { 
        #region fields

        Vector2 position;

        /*
        int type;
        
        int Type
        {
            get{ return type; }
        }
        */
        Vector2 Position
        {
            get { return position; }
        }

        Texture2D spriteResource;

        Rectangle source;

        #endregion

        #region constructor

        public Tile(int x, int y, Rectangle source, Texture2D spriteResource)
        {
            position = new Vector2(x,y);
            this.source = source;
            this.spriteResource = spriteResource;
        }
        #endregion

        public void Draw(SpriteBatch spriteBatch, float scale)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(spriteResource, source, new Rectangle((int)position.X, (int)position.Y, (int)(source.Width * scale), (int)(source.Height * scale)), Color.White);
        }
    }
}

