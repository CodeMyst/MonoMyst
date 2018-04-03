using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class UIHost : MonoMystObject
    {
        protected Game Game;

        protected ContentManager Content;

        private List<Canvas> canvasses = new List<Canvas> ();

        private MouseState currentMouseState;
        private MouseState previousMouseState;

        public UIHost (Game game)
        {
            Game = game;

            Content = new ContentManager (Game.Services)
            {
                RootDirectory = "Content"
            };
        }

        public void AddCanvas (Canvas canvas)
        {
            canvasses.Add (canvas);
            canvas.Initialize ();
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            foreach (Canvas c in canvasses)
                c.Draw (spriteBatch);
        }

        public override void Update (float deltaTime)
        {
            foreach (Canvas c in canvasses)
                c.Update (deltaTime);

            currentMouseState = Mouse.GetState ();

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                Widget widgetAtMousePosition = GetWidgetAtPosition (currentMouseState.Position.ToVector2 ());
                if (widgetAtMousePosition != null)
                    widgetAtMousePosition.OnClicked?.Invoke ();
            }

            previousMouseState = currentMouseState;
        }

        public Widget GetWidgetAtPosition (Vector2 position)
        {
            Widget widget = null;

            foreach (Canvas c in canvasses)
                foreach (Widget w in c.Children)
                    if (new Rectangle (w.Position.ToPoint (), w.Scale.ToPoint ()).Contains (position))
                        if (widget == null || (widget != null && w.SortingOrder > widget.SortingOrder))
                            widget = w;

            return widget;
        }
    }
}
