using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class Button : Widget, IClickable
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

        public Action OnClick;

        public Button ()
        {
            textBlock = new TextBlock
            {
                TextHorizontalAlignment = TextHorizontalAlignment.Center,
                TextVerticalAlignment = TextVerticalAlignment.Center   
            };
            AddChild (textBlock);
        }

        public void OnClicked ()
        {
            OnClick?.Invoke ();
        }

        internal protected override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            Size = textBlock.MeasureString (textBlock.Text) + new Vector2 (10, 10);

            spriteBatch.Draw
                (
                    MonoMystGame.GraphicUtilities.Rectangle,
                    new Rectangle (Position.ToPoint (), Size.ToPoint ()),
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