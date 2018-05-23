using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
<<<<<<< HEAD
using MonoMyst.Engine.Graphics;
=======
>>>>>>> 97016d8cd8153bc913268eb2ff88d4199ba7b6e5

namespace MonoMyst.Engine.UI.Widgets
{
    public class TextBlock : Widget
    {
        public string Text;
        public SpriteFont Font;
        public float FontSize = 1f;

        public float CharacterSpacing = 1f;

        public TextWrapping TextWrapping = TextWrapping.WordWrap;

        public TextHorizontalAlignment TextHorizontalAlignment = TextHorizontalAlignment.Left;
        public TextVerticalAlignment TextVerticalAlignment = TextVerticalAlignment.Top;

        public override void Initialize ()
        {
            base.Initialize ();

            if (Font == null)
                Font = MonoMystGame.GraphicUtilities.NotoSansRegular;
            if (Text == null)
                Text = "";
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            Scale = Font.MeasureString (Text) * FontSize;
            Scale = Vector2.Clamp (Scale, Vector2.Zero, Parent.Scale);

            if (TextHorizontalAlignment == TextHorizontalAlignment.Center)
            {
                Position = new Vector2 (Parent.Position.X + (Parent.Scale.X / 2) - (Scale.X / 2), Position.Y);
            }

            if (TextVerticalAlignment == TextVerticalAlignment.Center)
            {
                Position = new Vector2 (Position.X, Parent.Position.Y + (Parent.Scale.Y / 2) - (Scale.Y / 2));
            }

            if (TextWrapping == TextWrapping.WordWrap && MeasureString (Text).X > Parent.Scale.X)
            {
                StringBuilder formattedText = new StringBuilder ();

                string [] words = Text.Split (' ');
                float lineWidth = 0f;
                float spaceWidth = MeasureString (" ").X;

                for (int i = 0; i < words.Length; i++)
                {
                    if (lineWidth + spaceWidth + MeasureString (words [i]).X <= Parent.Scale.X)
                    {
                        formattedText.Append ($"{words [i]} ");
                        lineWidth += spaceWidth + MeasureString (words [i]).X;
                    }
                    else
                    {
                        formattedText.Append ("\n");
                        formattedText.Append ($"{words [i]} ");
                        lineWidth = spaceWidth + MeasureString (words [i]).X;
                    }
                }

                spriteBatch.DrawString
                    (
                        Font,
                        formattedText,
                        Position,
                        Color,
                        Rotation,
                        Vector2.Zero,
                        FontSize,
                        SpriteEffects.None,
                        SortingOrder
                    );
            }
            else
            {
                spriteBatch.DrawString
                    (
                        Font,
                        Text,
                        Position,
                        Color,
                        Rotation,
                        Vector2.Zero,
                        FontSize,
                        SpriteEffects.None,
                        SortingOrder
                    );
            }
        }

        /// <summary>
        /// Returns the size of the string when rendered with the TextBlock's font with regard to font size.
        /// </summary>
        /// <param name="text">The text to measure.</param>
        /// <returns>The size in pixels of the rendered text.</returns>
        public Vector2 MeasureString (string text)
        {
            return Font.MeasureString (text) * FontSize;
        }
    }
}
