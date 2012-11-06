using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace KuriosityXLib
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        #region Globals

        private static KeyboardState keyboardState;
        private static KeyboardState lastKeyboardState;

        #endregion Globals

        #region Properties

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        #endregion Properties

        #region Constructor

        public InputHandler(Game game)
            : base(game)
        {
            keyboardState = Keyboard.GetState();
        }

        #endregion Constructor

        #region XNA Methods

        /// <summary>
        /// </summary>
        ///
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
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        #endregion XNA Methods

        #region General Methods

        public static void Flush()
        {
            lastKeyboardState = keyboardState;
        }

        #endregion General Methods

        #region Keyboard

        public static bool KeyDown(Keys key)
        {
            return (keyboardState.IsKeyDown(key));
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }

        #endregion Keyboard
    }
}