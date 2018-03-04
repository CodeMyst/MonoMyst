using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class UIHost
    {
        protected ContentManager Content;

        private List<Widget> widgets = new List<Widget> ();

        public UIHost (ContentManager content)
        {
            Content = content;
        }

        public void AddWidget (Widget widget)
        {
            widget.Content = Content;
            widget.Initialize ();
            widgets.Add (widget);
        }

        public virtual void Draw (SpriteBatch spriteBatch)
        {
            foreach (Widget w in widgets)
                w.Draw (spriteBatch);
        }
    }
}
