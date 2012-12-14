using System;
using KuriosityXLib.Dialogs;
using Microsoft.Xna.Framework.Graphics;

namespace KuriosityXLib.TileMap
{
    public abstract class DialogCharacter : Character
    {
        public int dialogExitState = 0;
        public int lastDialogEventNum = 0;
        public Texture2D Portrait;
        private Dialog dialog = new Dialog();

        public DialogCharacter(Texture2D sprite, Map map)
            : base(sprite, map)
        {
        }

        public event EventHandler DialogEvent;

        public Dialog Dialog
        {
            get { return dialog; }
            set { dialog = value; }
        }

        public virtual void OnDialog(int num)
        {
            if (DialogEvent != null)
                lastDialogEventNum = num;
            DialogEvent(this, EventArgs.Empty);
        }
    }
}