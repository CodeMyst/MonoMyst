using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class UIHost
    {
        protected ContentManager Content;
        protected GraphicsDevice GraphicsDevice;

        private List<Widget> widgets = new List<Widget> ();

        public UIHost (ContentManager content, GraphicsDevice graphicsDevice)
        {
            Content = content;
            Content.RootDirectory = "Content";
            GraphicsDevice = graphicsDevice;
        }

        public void AddWidget (Widget widget)
        {
            widget.Content = Content;
            widget.GraphicsDevice = GraphicsDevice;
            widget.Initialize ();
            widgets.Add (widget);
        }

        public void Update (float deltaTime)
        {
            foreach (Widget w in widgets)
                w.Update (deltaTime);
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            foreach (Widget w in widgets)
                if (w.Visible)
                    w.Draw (spriteBatch);
        }
    }
}
