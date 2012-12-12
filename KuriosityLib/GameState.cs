using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace KuriosityXLib
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameState : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Fields and Properties

        protected GameStateManager GameStateManager;
        private List<GameComponent> childComponents;

        private GameState tag;

        public List<GameComponent> Components
        {
            get { return childComponents; }
        }

        public GameState Tag
        {
            get { return tag; }
        }

        #endregion Fields and Properties

        #region Constructor

        public GameState(Game game, GameStateManager manager)
            : base(game)
        {
            GameStateManager = manager;
            childComponents = new List<GameComponent>();
            tag = this;
        }

        #endregion Constructor

        #region XNA Drawable Game Component Methods

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawComp;

            foreach (GameComponent component in childComponents)
                if (component is DrawableGameComponent)
                {
                    drawComp = component as DrawableGameComponent;

                    if (drawComp.Visible)
                        drawComp.Draw(gameTime);
                }
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent component in childComponents)
            {
                if (component.Enabled)
                    component.Update(gameTime);
            }
            base.Update(gameTime);
        }

        #endregion XNA Drawable Game Component Methods

        #region GameState Methods

        internal protected virtual void StateChange(object sender, EventArgs e)
        {
            if (GameStateManager.CurrentState == Tag)
                Show();
            else
                Hide();
        }

        protected virtual void Hide()
        {
            Visible = false;
            Enabled = false;
            foreach (GameComponent component in childComponents)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = false;
            }
        }

        protected virtual void Show()
        {
            Visible = true;
            Enabled = true;
            foreach (GameComponent component in childComponents)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = true;
            }
        }

        #endregion GameState Methods
    }
}