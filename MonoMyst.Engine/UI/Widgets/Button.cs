using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class Button : Widget
    {
        public string Text
        {
            get => textBlock.Text;
            set => textBlock.Text = value;
        }

        public Color TextColor
        {
            get => textBlock.Color;
            set => textBlock.Color = value;
        }

        private TextBlock textBlock;

        public Button ()
        {
            textBlock = new TextBlock
            {
                TextHorizontalAlignment = TextHorizontalAlignment.Center,
                TextVerticalAlignment = TextVerticalAlignment.Center   
            };
            AddChild (textBlock);
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            Scale = textBlock.MeasureString (textBlock.Text) + new Vector2 (10, 10);

            spriteBatch.Draw
                (
                    GraphicUtilities.Rectangle,
                    new Rectangle (Position.ToPoint (), Scale.ToPoint ()),
                    null,
                    Color,
                    Rotation,
                    Vector2.Zero,
                    SpriteEffects.None,
                    SortingOrder
                );
        }
    }
}