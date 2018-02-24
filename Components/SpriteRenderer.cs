using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.ECS;

namespace MonoMyst.Components
{
    public class SpriteRenderer : Component
    {
        public Texture2D Sprite;

        public Vector2 Size;

        public override void Draw (SpriteBatch spriteBatch)
        {
            if (Sprite == null)
                return;
            
            spriteBatch.Draw (Sprite, new Rectangle ((int) Entity.Position.X, (int) Entity.Position.Y, (int) Size.X, (int) Size.Y), null, Color.White);
        }
    }
}
