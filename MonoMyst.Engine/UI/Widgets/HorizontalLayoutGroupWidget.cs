using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class HorizontalLayoutGroupWidget : Widget
    {
        public override void AddChild (Widget widget)
        {
            base.AddChild (widget);
            widget.VerticalAlignment = VerticalAlignment.Stretch;
            widget.HorizontalAlignment = HorizontalAlignment.Left;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            for (int i = 0; i < Children.Count; i++)
            {
                float paddingLeft = 0;

                if (i - 1 >= 0)
                    paddingLeft += Children [i - 1].DrawPosition.X + Children [i - 1].DrawSize.X;

                Children [i].Position = new Vector2 (paddingLeft, 0);
            }
        }
    }
}
