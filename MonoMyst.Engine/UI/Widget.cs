using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class Widget
    {
        public GraphicsDevice GraphicsDevice;
        public ContentManager Content;

        public Widget Parent;

        public virtual void Initialize () { }
        public virtual void Draw (SpriteBatch spriteBatch) { }
    }
}
