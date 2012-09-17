﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KuriosityXLib;
using KuriosityXLib.TileMap;
using KuriosityXLib.Control;
using Microsoft.Xna.Framework.Graphics;

using KuriosityXLib.Dialogs;
using Microsoft.Xna.Framework;

namespace Caverns.GameScreens
{
    public class DialogScreen : BaseGameState
    {
        ControlManager controls;

        DialogCharacter Char1;
        DialogCharacter Char2;

        DialogState curState;

        SpriteFont font;

        Label DialogLabel = new Label();
        List<LinkLabel> Options = new List<LinkLabel>();


        public DialogScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        { 
        
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            controls = new ControlManager(gameref.Content.Load<SpriteFont>("font/title"));
            font = gameref.Content.Load<SpriteFont>("font/title");
        }
        public void CallDialog(DialogCharacter tarChar, DialogCharacter recievingChar, int initalDialogState = 0)
        {
            Char1 = tarChar;
            Char2 = recievingChar;
            SetUpDialog(initalDialogState);

        }

        void SetUpDialog(int targetState)
        {
            GameStateManager.PushState(this);
            controls.Clear();
            curState = Char1.Dialog.states[targetState];
            DialogLabel.Text = curState.stateText;
            DialogLabel.TabStop = false;
            DialogLabel.Position = new Vector2(20, 20);
            DialogLabel.SpriteFont = font;
            if(!controls.Contains(DialogLabel))
                controls.Add(DialogLabel);
            Vector2 pos = new Vector2(200,200);
            foreach (Response res in curState.responses)
            {
                LinkLabel response = new LinkLabel();
                response.Text = res.responseText;
                response.Value = res.nextStateID;
                response.Position = pos;
                response.Selected += dialog_selected;
                response.SpriteFont = font;
                pos.Y += 16;
                controls.Add(response);
                
            }

        }

        private void dialog_selected(Object sender, EventArgs e)
        {
            if (((int)((LinkLabel)sender).Value) < 0)
            {
                GameStateManager.PopState();
            }
            else
            {
                SetUpDialog(((int)((LinkLabel)sender).Value));
            }
                
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            controls.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            gameref.SpriteBatch.Begin();
            base.Draw(gameTime);
            controls.Draw(gameref.SpriteBatch);

            gameref.SpriteBatch.End();
        }
        
    }
}
