using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class Widget
    {
        public ContentManager Content;

        public Widget Parent;

        public int GridColumn = 0;
        public int GridRow = 0;

        public int Width { get; }
        public int Height { get; }

        private int _gridSpanX = 1;
        private int _gridSpanY = 1;

        private bool _visible;

        private int _paddingLeft;
        private int _paddingTop;
        private int _paddingRight;
        private int _paddingBottom;

        public virtual void Initialize () { }
        public virtual void Draw (SpriteBatch spriteBatch) { }
    }
}
