using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class Canvas : Widget
    {
        private List<Widget> widgets = new List<Widget> ();

        public override void Initialize ()
        {
            base.Initialize ();

            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            Color = Color.Transparent;
        }

        public void AddWidget (Widget widget)
        {
            widgets.Add (widget);
            widget.SetParent (this);
            widget.Initialize ();
        }

        public override void Update (float deltaTime)
        {
            base.Update (deltaTime);

            foreach (Widget w in widgets)
                w.Update (deltaTime);
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            Scale = spriteBatch.GraphicsDevice.Viewport.Bounds.Size.ToVector2 ();
            Position = Vector2.Zero;

            foreach (Widget w in widgets)
                w.Draw (spriteBatch);
        }
    }
}
