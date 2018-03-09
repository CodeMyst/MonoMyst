using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class Widget
    {
        public GraphicsDevice GraphicsDevice;
        public ContentManager Content;

        public HorizontalAlignment HorizontalAlignment;
        public VerticalAlignment VerticalAlignment;

        public Vector2 Position = Vector2.Zero;
        public Vector2 Size = Vector2.One;
        public Thickness Padding = Thickness.Zero;

        protected int ScreenWidth => GraphicsDevice.Viewport.Width;
        protected int ScreenHeight => GraphicsDevice.Viewport.Height;

        protected Vector2 DrawPosition;
        protected Vector2 DrawSize;

        public Widget Parent;

        public virtual void Initialize () { }

        public virtual void Draw (SpriteBatch spriteBatch)
        {
            DrawSize = Size;

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    DrawPosition.X = 0;
                    break;
                case HorizontalAlignment.Center:
                    DrawPosition.X = ((ScreenWidth / 2) - (int) (Size.X / 2)) + (int) Position.X;
                    break;
                case HorizontalAlignment.Right:
                    DrawPosition.X = (ScreenWidth - (int) Size.X) + (int) Position.X;
                    break;
                case HorizontalAlignment.Stretch:
                    DrawPosition.X = 0;
                    DrawSize.X = ScreenWidth;
                    break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    DrawPosition.Y = 0;
                    break;
                case VerticalAlignment.Center:
                    DrawPosition.Y = ((ScreenHeight / 2) - (int) (Size.Y / 2)) + (int) Position.Y;
                    break;
                case VerticalAlignment.Bottom:
                    DrawPosition.Y = (ScreenHeight - (int) Size.Y) + (int) Position.Y;
                    break;
                case VerticalAlignment.Stretch:
                    DrawPosition.Y = 0;
                    DrawSize.Y = ScreenHeight;
                    break;
            }

            DrawPosition.X += Padding.Left;
            DrawPosition.Y += Padding.Top;
            DrawSize.X -= Padding.Right + Padding.Left;
            DrawSize.Y -= Padding.Bottom + Padding.Top;
        }
    }
}
