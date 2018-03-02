using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.ECS;

namespace MonoMyst.Engine.UI
{
    public class TextComponent : Component
    {
        public SpriteFont Font;
        public string Text;
        public Color Color = Color.White;
        public Vector2 Scale = Vector2.One;

        public override void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString (Font, Text, Entity.Position, Color, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
