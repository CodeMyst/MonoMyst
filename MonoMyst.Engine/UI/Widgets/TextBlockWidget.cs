using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class TextBlockWidget : Widget
    {
        public string Text;
        public float FontSize = 1f;
        public Color Color = Color.White;

        private SpriteFont font;

        public TextBlockWidget (string text)
        {
            Text = text;
        }

        public override void Initialize ()
        {
            base.Initialize ();

            font = MonoMystGame.MMContent.Load<SpriteFont> ("NotoSansRegular");
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            Size = new Vector2 (font.MeasureString (Text).X * FontSize, font.MeasureString (Text).Y * FontSize);

            base.Draw (spriteBatch);

            spriteBatch.DrawString
                (
                    font,
                    Text,
                    DrawPosition,
                    Color,
                    0f,
                    Vector2.Zero,
                    FontSize,
                    SpriteEffects.None,
                    SortingOrder
                );
        }
    }
}
