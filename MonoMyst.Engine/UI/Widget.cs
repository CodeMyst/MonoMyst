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

        public Vector2 DrawPosition { get; protected set; }
        public Vector2 DrawSize { get; protected set; }

        public List<Widget> Children { get; protected set; } = new List<Widget> ();

        public Widget Parent;

        public float SortingOrder;

        public bool Visible = true;

        public virtual void Initialize ()
        {
            foreach (Widget w in Children)
            {
                w.Content = Content;
                w.GraphicsDevice = GraphicsDevice;
                w.Initialize ();
            }
        }

        public virtual void AddChild (Widget widget)
        {
            widget.Parent = this;
            Children.Add (widget);
        }

        public virtual void Update (float deltaTime)
        {
            foreach (Widget w in Children)
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
                    DrawPosition = new Vector2 (0, DrawPosition.X);
                    if (Parent != null) DrawPosition = new Vector2 (Parent.DrawPosition.X + Position.X, DrawPosition.Y);
                    break;
                case HorizontalAlignment.Center:
                    DrawPosition = new Vector2 (((ScreenWidth / 2) - (int) (Size.X / 2)) + (int) Position.X, DrawPosition.Y);
                    if (Parent != null) DrawPosition = new Vector2 (((Parent.DrawSize.X / 2) - (int) (Size.X / 2)) + (int) Position.X + Parent.DrawPosition.X, DrawPosition.Y);
                    break;
                case HorizontalAlignment.Right:
                    DrawPosition = new Vector2 ((ScreenWidth - (int) Size.X) + (int) Position.X, DrawPosition.Y);
                    if (Parent != null) DrawPosition = new Vector2 ((Parent.DrawSize.X - (int) Size.X) + (int) Position.X + Parent.DrawPosition.X, DrawPosition.Y);
                    break;
                case HorizontalAlignment.Stretch:
                    DrawPosition = new Vector2 (0, DrawPosition.Y);
                    DrawSize = new Vector2 (ScreenWidth, DrawSize.Y);
                    if (Parent != null)
                    {
                        DrawPosition = new Vector2 (Parent.DrawPosition.X, DrawPosition.Y);
                        DrawSize = new Vector2 (Parent.DrawSize.X, DrawSize.Y);
                    }
                    break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    DrawPosition = new Vector2 (DrawPosition.X, 0);
                    if (Parent != null) DrawPosition = new Vector2 (DrawPosition.X, Parent.DrawPosition.Y + Position.Y);
                    break;
                case VerticalAlignment.Center:
                    DrawPosition = new Vector2 (DrawPosition.X, ((ScreenHeight / 2) - (int) (Size.Y / 2)) + (int) Position.Y);
                    if (Parent != null) DrawPosition = new Vector2 (DrawPosition.X, ((Parent.DrawSize.Y / 2) - (int) (Size.Y / 2)) + (int) Position.Y + Parent.DrawPosition.Y);
                    break;
                case VerticalAlignment.Bottom:
                    DrawPosition = new Vector2 (DrawPosition.X, (ScreenHeight - (int) Size.Y) + (int) Position.Y);
                    if (Parent != null) DrawPosition = new Vector2 (DrawPosition.X, (Parent.DrawSize.Y - (int) Size.Y) + (int) Position.Y + Parent.DrawPosition.Y);
                    break;
                case VerticalAlignment.Stretch:
                    DrawPosition = new Vector2 (DrawPosition.X, 0);
                    DrawSize = new Vector2 (DrawSize.X, ScreenHeight);
                    if (Parent != null)
                    {
                        DrawPosition = new Vector2 (DrawPosition.X, Parent.DrawPosition.Y);
                        DrawSize = new Vector2 (DrawSize.X, Parent.DrawSize.Y);
                    }
                    break;
            }

            DrawPosition += new Vector2 (Padding.Left, Padding.Top);
            DrawSize += new Vector2 (Padding.Right + Padding.Left, Padding.Bottom + Padding.Top);

            foreach (Widget w in Children)
                if (w.Visible)
                    w.Draw (spriteBatch);
        }
    }
}