using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public abstract class Widget
    {
        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        public Vector2 Size { get; set; }

        public Overflow Overflow = Overflow.Hidden;

        public Vector2 Origin = Vector2.Zero;

        public float SortingOrder = 0f;

        public Color Color = Color.White;

        public HorizontalAlignment HorizontalAlignment = HorizontalAlignment.Left;
        public VerticalAlignment VerticalAlignment = VerticalAlignment.Top;

        public Widget Parent { get; private set; }

        public List<Widget> Children { get; private set; } = new List<Widget> ();

        public Thickness Margin = Thickness.Zero;
        public Thickness Padding = Thickness.Zero;

        internal void SetParent (Widget parent)
        {
            Parent = parent;
        }

        public void AddChild (Widget widget)
        {
            if (widget == this) throw new ArgumentException ("Cannot pass widget as a child to itself.");
            Children.Add (widget);
            widget.SetParent (this);
            widget.Initialize ();
        }

        internal protected virtual void Initialize ()
        {
        }

        internal protected virtual void Update (float deltaTime)
        {
            foreach (Widget w in Children)
                w.Update (deltaTime);
        }

        internal protected virtual void Draw (SpriteBatch spriteBatch)
        {
            if (SortingOrder <= Parent.SortingOrder)
                SortingOrder = Parent.SortingOrder + 0.01f;

            foreach (Widget w in Children)
                w.Draw (spriteBatch);

            Origin = Vector2.Clamp (Origin, Vector2.Zero, Vector2.One);

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Stretch:
                    {
                        Origin.X = 0;
                        Position = new Vector2 (Parent.Position.X + Parent.Padding.Left + Margin.Left, Position.Y);
                        Size = new Vector2 (Parent.Size.X - (Parent.Padding.Right * 2) - (Margin.Right * 2), Size.Y);
                    } break;

                case HorizontalAlignment.Left:
                    {
                        Origin.X = 0;
                        Position = new Vector2 (Parent.Position.X - (Size.X * Origin.X) + Parent.Padding.Left + Margin.Left, Position.Y);
                        if (Position.X + Size.X > Parent.Position.X + Parent.Size.X - Margin.Right - Parent.Padding.Right)
                        {
                            Size -= new Vector2 ((Position.X + Size.X) - (Parent.Position.X + Parent.Size.X - Margin.Right - Parent.Padding.Right), 0f);
                        }
                    } break;

                case HorizontalAlignment.Center:
                    {
                        Origin.X = 0.5f;
                        Position = new Vector2 (Parent.Position.X + (Parent.Size.X / 2) - (Size.X * Origin.X), Position.Y);
                        if (Position.X < Parent.Position.X + Parent.Padding.Left + Margin.Left)
                        {
                            Position = new Vector2 (Parent.Position.X + Parent.Padding.Left + Margin.Left, Position.Y);
                        }
                        if (Position.X + Size.X > Parent.Position.X + Parent.Size.X - Margin.Right - Parent.Padding.Right)
                        {
                            Size -= new Vector2 ((Position.X + Size.X) - (Parent.Position.X + Parent.Size.X - Margin.Right - Parent.Padding.Right), 0f);
                        }
                    } break;

                case HorizontalAlignment.Right:
                    {
                        Origin.X = 1f;
                        Position = new Vector2 (Parent.Position.X + (Parent.Size.X) - (Size.X * Origin.X) - (Parent.Padding.Right) - Margin.Right, Position.Y);
                        if (Position.X < Parent.Position.X + Parent.Padding.Left + Margin.Left)
                        {
                            Position = new Vector2 (Parent.Position.X + Parent.Padding.Left + Margin.Left, Position.Y);
                            Size -= new Vector2 ((Position.X + Size.X) - (Parent.Position.X + Parent.Size.X - Parent.Padding.Right - Margin.Right), 0f);
                        }
                    } break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Stretch:
                    {
                        Origin.Y = 0f;
                        Position = new Vector2 (Position.X, Parent.Position.Y + Parent.Padding.Top + Margin.Top);
                        Size = new Vector2 (Size.X, Parent.Size.Y - (Parent.Padding.Bottom * 2) - (Margin.Bottom * 2));
                    }
                    break;

                case VerticalAlignment.Top:
                    {
                        Origin.Y = 0f;
                        Position = new Vector2 (Position.X, Parent.Position.Y - (Size.Y * Origin.Y) + Parent.Padding.Top + Margin.Top);
                        if (Position.Y + Size.Y > Parent.Position.Y + Parent.Size.Y - Parent.Padding.Bottom - Margin.Right)
                        {
                            Size -= new Vector2 (0f, (Position.Y + Size.Y) - (Parent.Position.Y + Parent.Size.Y - Parent.Padding.Bottom - Margin.Bottom));
                        }
                    }
                    break;

                case VerticalAlignment.Center:
                    {
                        Origin.Y = 0.5f;
                        Position = new Vector2 (Position.X, Parent.Position.Y + (Parent.Size.Y / 2) - (Size.Y * Origin.Y));
                        if (Position.Y < Parent.Position.Y + Parent.Padding.Top + Margin.Top)
                        {
                            Position = new Vector2 (Position.X, Parent.Position.Y + Parent.Padding.Top + Margin.Top);
                        }
                        if (Position.Y + Size.Y > Parent.Position.Y + Parent.Size.Y - Parent.Padding.Bottom - Margin.Bottom)
                        {
                            Size -= new Vector2 (0f, (Position.Y + Size.Y) - (Parent.Position.Y + Parent.Size.Y - Parent.Padding.Bottom - Margin.Bottom));
                        }
                    }
                    break;

                case VerticalAlignment.Bottom:
                    {
                        Origin.Y = 1f;
                        Position = new Vector2 (Position.X, Parent.Position.Y + Parent.Size.Y - (Size.Y * Origin.Y) - Parent.Padding.Bottom - Margin.Bottom);
                        if (Position.Y < Parent.Position.Y + Parent.Padding.Top + Margin.Top)
                        {
                            Position = new Vector2 (Position.X, Parent.Position.Y + Parent.Padding.Top + Margin.Top);
                            Size -= new Vector2 (0f, (Position.Y + Size.Y) - (Parent.Position.Y + Parent.Size.Y - Parent.Padding.Bottom - Margin.Bottom));
                        }
                    }
                    break;
            }

            if (Overflow == Overflow.Hidden)
                spriteBatch.GraphicsDevice.ScissorRectangle = new Rectangle (Position.ToPoint (), Size.ToPoint ());
        }
    }
}