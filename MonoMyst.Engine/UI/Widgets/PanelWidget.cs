using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class PanelWidget : Widget
    {
        public HorizontalAlignment HorizontalAlignment;
        public VerticalAlignment VerticalAlignment;

        public Vector2 Position = Vector2.Zero;
        public Vector2 Size = Vector2.One;
        public Color Color = Color.White;

        private int ScreenWidth => GraphicsDevice.Viewport.Width;
        private int ScreenHeight => GraphicsDevice.Viewport.Height;

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            int x = 0;
            int y = 0;
            int sizeX = (int) Size.X;
            int sizeY = (int) Size.Y;

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    x = 0;
                    break;
                case HorizontalAlignment.Center:
                    x = ((ScreenWidth / 2) - (int) (Size.X / 2)) + (int) Position.X;
                    break;
                case HorizontalAlignment.Right:
                    x = (ScreenWidth - (int) Size.X) + (int) Position.X;
                    break;
                case HorizontalAlignment.Stretch:
                    x = 0;
                    sizeX = ScreenWidth;
                    break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    y = 0;
                    break;
                case VerticalAlignment.Center:
                    y = ((ScreenHeight / 2) - (int) (Size.Y / 2)) + (int) Position.Y;
                    break;
                case VerticalAlignment.Bottom:
                    y = (ScreenHeight - (int) Size.Y) + (int) Position.Y;
                    break;
                case VerticalAlignment.Stretch:
                    y = 0;
                    sizeY = ScreenHeight;
                    break;
            }

            spriteBatch.Draw (GraphicUtilities.Rectangle, new Rectangle (x, y, sizeX, sizeY), Color);
        }
    }
}
