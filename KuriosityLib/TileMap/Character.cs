using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib.TileMap
{
    public abstract class Character
    {
        public Vector2 Position { get; set; }

        public Texture2D Sprite { get; set; }

        public Map Map { get; set; }

        public Character(Texture2D sprite, Map map)
        {
            Sprite = sprite;
            Position = new Vector2();
            Map = map;
        }

        public abstract Rectangle getBoundingRect();

        public abstract void update(GameTime time);

        public abstract void draw(SpriteBatch spriteBatch, Point offset);
    }
}
