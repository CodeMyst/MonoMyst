using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.Collections
{
    public class Quadtree<T> where T : IHasRectangle
    {
        private const int NodeCapacity = 4;

        private Rectangle bounds;

        private List<T> elements = new List<T> ();

        private Quadtree<T> northWest;
        private Quadtree<T> northEast;
        private Quadtree<T> southWest;
        private Quadtree<T> southEast;

        private bool divided;

        public Quadtree (Rectangle bounds)
        {
            this.bounds = bounds;
        }

        public bool Insert (T element)
        {
            if (!bounds.Contains (element.Rectangle.Location)) return false;

            if (elements.Count < NodeCapacity)
            {
                elements.Add (element);
                return true;
            }

            if (!divided)
                Subdivide ();

            return (this.northEast.Insert(element) || this.northWest.Insert(element) ||
                    this.southEast.Insert(element) || this.southWest.Insert(element));
        }

        private void Subdivide ()
        {
            divided = true;

            int subWidth = bounds.Width / 2;
            int subHeight = bounds.Height / 2;

            Rectangle nw = new Rectangle (bounds.X, bounds.Y, subWidth, subHeight );
            Rectangle ne = new Rectangle (bounds.X + subWidth, bounds.Y, subWidth, subHeight);
            Rectangle sw = new Rectangle (bounds.X, bounds.Y + subHeight, subWidth, subHeight);
            Rectangle se = new Rectangle (bounds.X + subWidth, bounds.Y + subHeight, subWidth, subHeight );

            northWest = new Quadtree<T> (nw);
            northEast = new Quadtree<T> (ne);
            southWest = new Quadtree<T> (sw);
            southEast = new Quadtree<T> (se);
        }

        public void Clear ()
        {
            elements.Clear ();

            if (divided)
            {
                northWest.Clear ();
                northEast.Clear ();
                southWest.Clear ();
                southEast.Clear ();
            }
        }

        public void Draw (SpriteBatch sb)
        {
            sb.Draw
            (
                MGame.GraphicUtilities.Rectangle,
                new Rectangle (bounds.X, bounds.Y, bounds.Width, 1),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                1f
            );

            sb.Draw
            (
                MGame.GraphicUtilities.Rectangle,
                new Rectangle (bounds.X + bounds.Width - 1, bounds.Y, 1, bounds.Height),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                1f
            );

            sb.Draw
            (
                MGame.GraphicUtilities.Rectangle,
                new Rectangle (bounds.X, bounds.Y + bounds.Height - 1, bounds.Width, 1),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                1f
            );

            sb.Draw
            (
                MGame.GraphicUtilities.Rectangle,
                new Rectangle (bounds.X, bounds.Y, 1, bounds.Height),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                1f
            );

            for (int i = 0; i < elements.Count; i++)
            {
                T element = elements [i];

                sb.Draw
                (
                    MGame.GraphicUtilities.Rectangle,
                    element.Rectangle,
                    null,
                    Color.Red,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    1f
                );
            }

            if (divided)
            {
                this.northWest.Draw (sb);
                this.northEast.Draw (sb);
                this.southWest.Draw (sb);
                this.southEast.Draw (sb);
            }
        }
    }
}