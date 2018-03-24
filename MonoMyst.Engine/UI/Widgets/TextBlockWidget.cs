using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class TextBlockWidget : Widget
    {
        public string Text;
        public SpriteFont Font;
        public float FontSize = 1f;

        public float CharacterSpacing = 1f;

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

            base.Draw (spriteBatch);

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
