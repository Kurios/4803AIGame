using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using KuriosityXLib;
using Microsoft.Xna.Framework.Input;

using Caverns.Dialogs;

namespace Caverns.Char
{
    class NPCChild : NonPlayableChar
    {
         public NPCChild(Texture2D sprite, Map map)
            : base(sprite, map)
        {
        }

         public override void update(GameTime time)
         {
             throw new NotImplementedException();
         }

         public override void draw(SpriteBatch spriteBatch, Point offset)
         {
             throw new NotImplementedException();
         }

    }
}
