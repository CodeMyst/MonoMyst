using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MonoMyst.Engine.ECS.Components;

namespace MonoMyst.Engine.UI
{
    public class ButtonComponent : SpriteComponent
    {
        public event Action OnHovered;
        public event Action OnPressed;

        private MouseState lastMouseState;
        private MouseState currentMouseState;

        private bool hovering;

        public override void Update (float deltaTime)
        {
            base.Update (deltaTime);

            currentMouseState = Mouse.GetState ();

            Rectangle buttonRect = new Rectangle (Entity.Position.ToPoint (), Size);
            Rectangle mouseRect = new Rectangle (Camera.Main.ScreenToWorld (currentMouseState.Position), new Point (1));

            if (buttonRect.Intersects (mouseRect))
            {
                hovering = true;
                OnHovered?.Invoke ();
            }
            else
            {
                hovering = false;
            }

            if (hovering && currentMouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                OnPressed?.Invoke ();

            lastMouseState = currentMouseState;
        }
    }
}
