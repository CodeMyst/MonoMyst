using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.ECS;
using System.Collections.Generic;

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

        public Vector2 Origin = Vector2.Zero;

        public float SortingOrder = 0f;

        public Color Color = Color.White;

        public HorizontalAlignment HorizontalAlignment = HorizontalAlignment.None;
        public VerticalAlignment VerticalAlignment = VerticalAlignment.None;

        public Widget Parent { get; private set; }

        private List<Widget> children = new List<Widget> ();

        public void SetParent (Widget parent)
        {
            Parent = parent;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            Origin = Vector2.Clamp (Origin, Vector2.Zero, Vector2.One);

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Stretch:
                    {
                        Position = new Vector2 (Parent.Position.X, Position.Y);
                        Scale = new Vector2 (Parent.Scale.X, Scale.Y);
                    } break;

                case HorizontalAlignment.Left:
                    {
                        Position = new Vector2 (Parent.Position.X - (Scale.X * Origin.X), Position.Y);
                    } break;

                case HorizontalAlignment.Center:
                    {
                        Position = new Vector2 ((Parent.Scale.X / 2) - (Scale.X * Origin.X), Position.Y);
                    } break;

                case HorizontalAlignment.Right:
                    {
                        Position = new Vector2 ((Parent.Scale.X) - (Scale.X * Origin.X), Position.Y);
                    } break;
            }

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Stretch:
                    {
                        Position = new Vector2 (Position.X, Parent.Position.Y);
                        Scale = new Vector2 (Scale.X, Parent.Scale.Y);
                    }
                    break;

                case VerticalAlignment.Top:
                    {
                        Position = new Vector2 (Position.X, Parent.Position.Y - (Scale.Y * Origin.Y));
                    }
                    break;

                case VerticalAlignment.Center:
                    {
                        Position = new Vector2 (Position.X, (Parent.Scale.Y / 2) - (Scale.Y * Origin.Y));
                    }
                    break;

                case VerticalAlignment.Bottom:
                    {
                        Position = new Vector2 (Position.X, Parent.Scale.Y - (Scale.Y * Origin.Y));
                    }
                    break;
            }
        }
    }
}