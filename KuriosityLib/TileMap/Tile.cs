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

        public Texture2D spriteResource {get; set;}

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

        public void Draw(SpriteBatch spriteBatch, int x, int y, float scale)
        {
            //spriteBatch.Begin();
            Console.WriteLine(source);
            spriteBatch.Draw(spriteResource, new Rectangle(x * (int)(source.Width * scale), y * (int)(source.Height * scale), (int)(source.Width * scale), (int)(source.Height * scale)), source, Color.White);
            //spriteBatch.End();
        }
    }
}

