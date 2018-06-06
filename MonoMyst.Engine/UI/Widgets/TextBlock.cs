using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.Graphics;

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

        internal protected override void Initialize ()
        {
            base.Initialize ();

            if (Font == null)
                Font = MonoMystGame.GraphicUtilities.NotoSansRegular;
            if (Text == null)
                Text = "";
        }

        internal protected override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            Size = Font.MeasureString (Text) * FontSize;
            Size = Vector2.Clamp (Size, Vector2.Zero, Parent.Size);

            if (TextHorizontalAlignment == TextHorizontalAlignment.Center)
            {
                Position = new Vector2 (Parent.Position.X + (Parent.Size.X / 2) - (Size.X / 2), Position.Y);
            }

            if (TextVerticalAlignment == TextVerticalAlignment.Center)
            {
                Position = new Vector2 (Position.X, Parent.Position.Y + (Parent.Size.Y / 2) - (Size.Y / 2));
            }

            if (TextWrapping == TextWrapping.WordWrap && MeasureString (Text).X > Parent.Size.X)
            {
                StringBuilder formattedText = new StringBuilder ();

                string [] words = Text.Split (' ');
                float lineWidth = 0f;
                float spaceWidth = MeasureString (" ").X;

                for (int i = 0; i < words.Length; i++)
                {
                    if (lineWidth + spaceWidth + MeasureString (words [i]).X <= Parent.Size.X)
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
