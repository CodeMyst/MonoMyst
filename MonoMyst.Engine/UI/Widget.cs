using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.ECS;

namespace MonoMyst.Engine.UI
{
    public abstract class Widget : MonoMystObject
    {
        public Transform Transform;

        public Vector2 Position
        {
            get { return Transform.Position; }
            set { Transform = new Transform (value, Transform.Rotation, Transform.Scale); }
        }

        public float Rotation
        {
            get { return Transform.Rotation; }
            set { Transform = new Transform (Transform.Position, value, Transform.Scale); }
        }

        public Vector2 Scale
        {
            get { return Transform.Scale; }
            set { Transform = new Transform (Transform.Position, Transform.Rotation, value); }
        }

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
            Children.Add (widget);
            widget.SetParent (this);
            widget.Initialize ();
        }

        public override void Update (float deltaTime)
        {
            base.Update (deltaTime);

            foreach (Widget w in Children)
                w.Update (deltaTime);
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

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
                        Position = new Vector2 (Parent.Position.X + Parent.Padding.Left, Position.Y);
                        Scale = new Vector2 (Parent.Scale.X - (Parent.Padding.Right * 2), Scale.Y);
                    } break;

                case HorizontalAlignment.Left:
                    {
                        Origin.X = 0;
                        Position = new Vector2 (Parent.Position.X - (Scale.X * Origin.X) + Parent.Padding.Left, Position.Y);
                        if (Position.X + Scale.X > Parent.Position.X + Parent.Scale.X - Parent.Padding.Right)
                        {
                            Scale -= new Vector2 ((Position.X + Scale.X) - (Parent.Position.X + Parent.Scale.X - Parent.Padding.Right), 0f);
                        }
                    } break;

                case HorizontalAlignment.Center:
                    {
                        Origin.X = 0.5f;
                        Position = new Vector2 (Parent.Position.X + (Parent.Scale.X / 2) - (Scale.X * Origin.X), Position.Y);
                        if (Position.X < Parent.Position.X + Parent.Padding.Left)
                        {
                            Position = new Vector2 (Parent.Position.X + Parent.Padding.Left, Position.Y);
                        }
                        if (Position.X + Scale.X > Parent.Position.X + Parent.Scale.X - Parent.Padding.Right)
                        {
                            Scale -= new Vector2 ((Position.X + Scale.X) - (Parent.Position.X + Parent.Scale.X - Parent.Padding.Right), 0f);
                        }
                    } break;

                case HorizontalAlignment.Right:
                    {
                        Origin.X = 1f;
                        Position = new Vector2 (Parent.Position.X + (Parent.Scale.X) - (Scale.X * Origin.X) - (Parent.Padding.Right), Position.Y);
                        if (Position.X < Parent.Position.X + Parent.Padding.Left)
                        {
                            Position = new Vector2 (Parent.Position.X + Parent.Padding.Left, Position.Y);
                            Scale -= new Vector2 ((Position.X + Scale.X) - (Parent.Position.X + Parent.Scale.X - Parent.Padding.Right), 0f);
                        }
                    } break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Stretch:
                    {
                        Origin.Y = 0f;
                        Position = new Vector2 (Position.X, Parent.Position.Y + Parent.Padding.Top);
                        Scale = new Vector2 (Scale.X, Parent.Scale.Y - (Parent.Padding.Bottom * 2));
                    }
                    break;

                case VerticalAlignment.Top:
                    {
                        Origin.Y = 0f;
                        Position = new Vector2 (Position.X, Parent.Position.Y - (Scale.Y * Origin.Y) + Parent.Padding.Top);
                        if (Position.Y + Scale.Y > Parent.Position.Y + Parent.Scale.Y - Parent.Padding.Bottom)
                        {
                            Scale -= new Vector2 (0f, (Position.Y + Scale.Y) - (Parent.Position.Y + Parent.Scale.Y - Parent.Padding.Bottom));
                        }
                    }
                    break;

                case VerticalAlignment.Center:
                    {
                        Origin.Y = 0.5f;
                        Position = new Vector2 (Position.X, Parent.Position.Y + (Parent.Scale.Y / 2) - (Scale.Y * Origin.Y));
                        if (Position.Y < Parent.Position.Y + Parent.Padding.Top)
                        {
                            Position = new Vector2 (Position.X, Parent.Position.Y + Parent.Padding.Top);
                        }
                        if (Position.Y + Scale.Y > Parent.Position.Y + Parent.Scale.Y - Parent.Padding.Bottom)
                        {
                            Scale -= new Vector2 (0f, (Position.Y + Scale.Y) - (Parent.Position.Y + Parent.Scale.Y - Parent.Padding.Bottom));
                        }
                    }
                    break;

                case VerticalAlignment.Bottom:
                    {
                        Origin.Y = 1f;
                        Position = new Vector2 (Position.X, Parent.Position.Y + Parent.Scale.Y - (Scale.Y * Origin.Y) - Parent.Padding.Bottom);
                        if (Position.Y < Parent.Position.Y + Parent.Padding.Top)
                        {
                            Position = new Vector2 (Position.X, Parent.Position.Y + Parent.Padding.Top);
                            Scale -= new Vector2 (0f, (Position.Y + Scale.Y) - (Parent.Position.Y + Parent.Scale.Y - Parent.Padding.Bottom));
                        }
                    }
                    break;
            }

            if (Overflow == Overflow.Hidden)
                spriteBatch.GraphicsDevice.ScissorRectangle = new Rectangle (Position.ToPoint (), Scale.ToPoint ());
        }
    }
}