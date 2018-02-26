using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Core.ECS;

namespace MonoMyst.Engine.Components
{
    public class SpriteRenderer : Component
    {
        public Texture2D Sprite;

        public Point Size = new Point (1, 1);

        public Color Color = Color.White;

        public override void Draw (SpriteBatch spriteBatch)
        {
            if (Sprite == null)
                return;

            spriteBatch.Draw (Sprite, new Rectangle (Entity.Position, Size), null, Color);
        }
    }
}
