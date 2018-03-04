using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class TextBlock : Widget
    {
        public string Text;
        public float FontSize;
        public Color Color;
        public SpriteFont Font;

        public TextBlock (string text, float fontSize, Color color, SpriteFont font)
        {
            Text = text;
            FontSize = fontSize;
            Color = color;
            Font = font;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            spriteBatch.DrawString (Font, Text, new Vector2 (Position.X + Padding.Left + Parent.Padding.Left, Position.Y + Padding.Top + Parent.Padding.Top), Color, 0f, Vector2.Zero, FontSize, SpriteEffects.None, 0);
        }
    }
}
