using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using KuriosityXLib.Dialogs;

namespace KuriosityXLib.TileMap
{
    public abstract class DialogCharacter :Character
    {

        Dialog dialog = new Dialog();
        public Dialog Dialog
        {
            get { return dialog; }
        }
        Texture2D DialogFace;

        public DialogCharacter(Texture2D sprite, Map map) : base(sprite, map) { }


    }
}
