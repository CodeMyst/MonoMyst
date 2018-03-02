using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.ECS.Components
{
    public class SpriteComponent : Component
    {
        public Texture2D Sprite;

        public Point Size = new Point (1, 1);

        public Color Color = Color.White;

        public override void Draw (SpriteBatch spriteBatch)
        {
            if (Sprite == null)
                return;

            spriteBatch.Draw (Sprite, new Rectangle (Entity.Position.ToPoint (), Size), null, Color);
        }
    }
}
