using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class TextBlock : Widget
    {
        public string Text;
        public SpriteFont Font;
        public float FontSize = 1f;

        public float CharacterSpacing = 1f;

        public TextWrapping TextWrapping = TextWrapping.WordWrap;

        public override void Initialize ()
        {
            base.Initialize ();

            if (Font == null)
                Font = MonoMystGame.MMContent.Load<SpriteFont> ("NotoSansRegular");
            if (string.IsNullOrEmpty (Text))
                Text = "";
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            if (Font.Spacing != CharacterSpacing)
                Font.Spacing = CharacterSpacing;

            Scale = Font.MeasureString (Text) * FontSize;

            Scale = Vector2.Clamp (Scale, Vector2.Zero, Parent.Scale);

            base.Draw (spriteBatch);

            if (TextWrapping == TextWrapping.WordWrap)
            {
                StringBuilder wrappedText = new StringBuilder ();

                if (Font.MeasureString (Text).X * FontSize > Scale.X)
                {
                    string [] words = Text.Split (' ');
                    for (int i = 0; i < words.Length; i++)
                    {
                        wrappedText.Append (words [i] + "\n");
                    }
                }
                else
                {
                    wrappedText.Append (Text);
                }

                Scale = Vector2.Clamp (Font.MeasureString (wrappedText)*FontSize, Vector2.Zero, Parent.Scale);

                Rectangle currentRect = spriteBatch.GraphicsDevice.ScissorRectangle;
                spriteBatch.GraphicsDevice.ScissorRectangle = new Rectangle (Position.ToPoint (), Scale.ToPoint ());

                spriteBatch.DrawString
                    (
                        Font,
                        wrappedText,
                        Position,
                        Color,
                        Rotation,
                        Vector2.Zero,
                        FontSize,
                        SpriteEffects.None,
                        SortingOrder
                    );

                //spriteBatch.GraphicsDevice.ScissorRectangle = currentRect;
            }
            else if (TextWrapping == TextWrapping.NoWrap)
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
    }
}
