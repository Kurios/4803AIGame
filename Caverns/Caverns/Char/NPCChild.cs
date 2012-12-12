using System;

using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.Char
{
    internal class NPCChild : NonPlayableChar
    {
        public NPCChild(Texture2D sprite, Map map)
            : base(sprite, map)
        {
        }

        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            throw new NotImplementedException();
        }

        public override void update(GameTime time)
        {
            throw new NotImplementedException();
        }
    }
}