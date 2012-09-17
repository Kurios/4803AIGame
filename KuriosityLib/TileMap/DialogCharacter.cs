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

        int lastDialogEventNum = 0;
        int dialogExitState = 0;

        public event EventHandler DialogEvent;

        public virtual void OnDialog(int num)
        {
            if (DialogEvent != null)
                lastDialogEventNum = num;
                DialogEvent(this, EventArgs.Empty);
        }


        public DialogCharacter(Texture2D sprite, Map map) : base(sprite, map) { }


    }
}
