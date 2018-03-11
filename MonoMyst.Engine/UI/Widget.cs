using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public abstract class Widget
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

        private List<Widget> children = new List<Widget> ();

        public Widget Parent;

        public float SortingOrder;

        public virtual void Initialize ()
        {
            foreach (Widget w in children)
            {
                w.Content = Content;
                w.GraphicsDevice = GraphicsDevice;
                w.Initialize ();
            }
        }

        public void AddChild (Widget widget)
        {
            widget.Parent = this;
            children.Add (widget);
        }

        public virtual void Update (float deltaTime)
        {
            foreach (Widget w in children)
                w.Update (deltaTime);
        }

        public virtual void Draw (SpriteBatch spriteBatch)
        {
            DrawSize = Size;

            if (Parent != null)
            {
                SortingOrder = Parent.SortingOrder + 0.01f;
            }

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    DrawPosition.X = 0;
                    if (Parent != null) DrawPosition.X = Parent.DrawPosition.X;
                    break;
                case HorizontalAlignment.Center:
                    DrawPosition.X = ((ScreenWidth / 2) - (int) (Size.X / 2)) + (int) Position.X;
                    if (Parent != null) DrawPosition.X = ((Parent.DrawSize.X / 2) - (int) (Size.X / 2)) + (int) Position.X + Parent.DrawPosition.X;
                    break;
                case HorizontalAlignment.Right:
                    DrawPosition.X = (ScreenWidth - (int) Size.X) + (int) Position.X;
                    if (Parent != null) DrawPosition.X = (Parent.DrawSize.X - (int) Size.X) + (int) Position.X + Parent.DrawPosition.X;
                    break;
                case HorizontalAlignment.Stretch:
                    DrawPosition.X = 0;
                    DrawSize.X = ScreenWidth;
                    if (Parent != null)
                    {
                        DrawPosition.X = Parent.DrawPosition.X;
                        DrawSize.X = Parent.DrawSize.X;
                    }
                    break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    DrawPosition.Y = 0;
                    if (Parent != null) DrawPosition.Y = Parent.DrawPosition.Y;
                    break;
                case VerticalAlignment.Center:
                    DrawPosition.Y = ((ScreenHeight / 2) - (int) (Size.Y / 2)) + (int) Position.Y;
                    if (Parent != null) DrawPosition.Y = ((Parent.DrawSize.Y / 2) - (int) (Size.Y / 2)) + (int) Position.Y + Parent.DrawPosition.Y;
                    break;
                case VerticalAlignment.Bottom:
                    DrawPosition.Y = (ScreenHeight - (int) Size.Y) + (int) Position.Y;
                    if (Parent != null) DrawPosition.Y = (Parent.DrawSize.Y - (int) Size.Y) + (int) Position.Y + Parent.DrawPosition.Y;
                    break;
                case VerticalAlignment.Stretch:
                    DrawPosition.Y = 0;
                    DrawSize.Y = ScreenHeight;
                    if (Parent != null)
                    {
                        DrawPosition.Y = Parent.DrawPosition.Y;
                        DrawSize.Y = Parent.DrawSize.Y;
                    }
                    break;
            }

            DrawPosition.X += Padding.Left;
            DrawPosition.Y += Padding.Top;
            DrawSize.X -= Padding.Right + Padding.Left;
            DrawSize.Y -= Padding.Bottom + Padding.Top;

            foreach (Widget w in children)
                w.Draw (spriteBatch);
        }
    }
}