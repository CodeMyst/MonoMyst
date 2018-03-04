using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class Widget
    {
        public ContentManager Content;

        public Widget Parent;

        private Vector2 position = Vector2.Zero;
        public Vector2 Position => position;

        public int GridColumn = 0;
        public int GridRow = 0;

        public int Width { get; }
        public int Height { get; }

        private int _gridSpanX = 1;
        private int _gridSpanY = 1;

        private bool _visible;

        public Thickness Padding;

        public virtual void Initialize () { }
        public virtual void Draw (SpriteBatch spriteBatch) { }
    }
}
