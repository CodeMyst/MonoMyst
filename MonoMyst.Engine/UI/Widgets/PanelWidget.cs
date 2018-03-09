using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class PanelWidget : Widget
    {
        public Color Color = Color.White;

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            spriteBatch.Draw (GraphicUtilities.Rectangle, new Rectangle ((int) DrawPosition.X, (int) DrawPosition.Y, (int) DrawSize.X, (int) DrawSize.Y), Color);
        }
    }
}
