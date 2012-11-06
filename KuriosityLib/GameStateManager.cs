using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace KuriosityXLib
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameStateManager : Microsoft.Xna.Framework.GameComponent
    {
        #region Event

        public event EventHandler OnStageChange;

        #endregion Event

        #region Fields and Properties

        private const int drawOrderInc = 100;
        private const int startDrawOrder = 5000;
        private int drawOrder;
        private Stack<GameState> gamestates = new Stack<GameState>();

        public GameState CurrentState
        {
            get { return gamestates.Peek(); }
        }

        #endregion Fields and Properties

        #region Constructor

        public GameStateManager(Game game)
            : base(game)
        {
            drawOrder = startDrawOrder;
        }

        #endregion Constructor

        #region XNA Methods

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        #endregion XNA Methods

        #region Methods

        public void AddState(GameState newState)
        {
            gamestates.Push(newState);
            Game.Components.Add(newState);
            OnStageChange += newState.StateChange;
        }

        public void ChangeState(GameState newState)
        {
            while (gamestates.Count > 0) RemoveState();

            newState.DrawOrder = startDrawOrder;
            drawOrder = startDrawOrder;

            AddState(newState);

            if (OnStageChange != null)
            {
                OnStageChange(this, null);
            }
        }

        public void PopState()
        {
            if (gamestates.Count > 0)
            {
                RemoveState();
                drawOrder -= drawOrderInc;

                if (OnStageChange != null)
                {
                    OnStageChange(this, null);
                }
            }
        }

        public void PushState(GameState newState)
        {
            drawOrder += drawOrderInc;
            newState.DrawOrder = drawOrder;
            AddState(newState);

            if (OnStageChange != null)
            {
                OnStageChange(this, null);
            }
        }

        public void RemoveState()
        {
            GameState State = gamestates.Peek();
            OnStageChange -= State.StateChange;
            Game.Components.Remove(State);
            gamestates.Pop();
        }

        #endregion Methods
    }
}