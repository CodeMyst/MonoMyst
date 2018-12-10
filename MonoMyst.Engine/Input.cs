using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine
{
    public class Input
    {
        private static KeyboardState previousKeyboardState;
        private static KeyboardState currentKeyboardState;

        private static MouseState previousMouseState;
        private static MouseState currentMouseState;

        internal protected void StartState ()
        {
            currentKeyboardState = Keyboard.GetState ();
            currentMouseState = Mouse.GetState ();
        }

        internal protected void EndState ()
        {
            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;
        }

        public static bool IsKeyHeld (Keys key) => currentKeyboardState.IsKeyDown (key);
        public static bool IsKeyPressed (Keys key) => currentKeyboardState.IsKeyDown (key) && !previousKeyboardState.IsKeyDown (key);
        public static bool IsKeyUp (Keys key) => currentKeyboardState.IsKeyUp (key) && !previousKeyboardState.IsKeyUp (key);

        public static bool IsLeftMouseHeld () => currentMouseState.LeftButton == ButtonState.Pressed;
        public static bool IsLeftMousePressed () => currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;

        public static Point MousePosition => currentMouseState.Position;
    }
}