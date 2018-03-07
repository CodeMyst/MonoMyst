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
            GraphicsDevice = graphicsDevice;
        }

        public void AddWidget (Widget widget)
        {
            widget.Content = Content;
            widget.GraphicsDevice = GraphicsDevice;
            widget.Initialize ();
            widgets.Add (widget);
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            foreach (Widget w in widgets)
                w.Draw (spriteBatch);
        }
    }
}
