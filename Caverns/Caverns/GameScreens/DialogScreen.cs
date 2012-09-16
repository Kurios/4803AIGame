using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KuriosityXLib;
using KuriosityXLib.TileMap;
using KuriosityXLib.Control;
using Microsoft.Xna.Framework.Graphics;

using KuriosityXLib.Dialogs;

namespace Caverns.GameScreens
{
    class DialogScreen : BaseGameState
    {
        ControlManager controls;

        DialogCharacter Char1;
        DialogCharacter Char2;

        public DialogScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        { 
        
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            controls = new ControlManager(gameref.Content.Load<SpriteFont>("font/title"));
        }
        public void CallDialog(DialogCharacter tarChar, DialogCharacter recievingChar, int initalDialogState = 0)
        {
            Char1 = tarChar;
            Char2 = recievingChar;
        }

        void SetUpDialog(int targetState)
        {
            Dialog log;
        }
    }
}
