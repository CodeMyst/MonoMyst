using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class CheckBox : Widget, IClickable
    {
        public bool Checked { get; set; }

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

        public new float SortingOrder
        {
            get => base.SortingOrder;
            set
            {
                base.SortingOrder = value;
                textBlock.SortingOrder = value;
            }
        }

        public Color CheckBoxBackgroundColor { get; set; } = MColors.Reno;

        public Action<bool> OnCheckedChanged;

        private TextBlock textBlock;

        public CheckBox (string text)
        {
            textBlock = new TextBlock
            {
                TextHorizontalAlignment = TextHorizontalAlignment.Left,
                TextVerticalAlignment = TextVerticalAlignment.Center,
                Margin = new Thickness (30, 0, 0, 0),
                Size = new Vector2 (1000, 20),
                FontSize = 0.75f,
            };
            AddChild (textBlock);
            Text = text;
            Vector2 textSize = textBlock.MeasureString (Text);
            Size = new Vector2 (textSize.X + 30, 20);
        }

        public CheckBox () : this ("") { }

        public void OnClicked ()
        {
            Checked = !Checked;
            OnCheckedChanged?.Invoke (Checked);
        }

        internal protected override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            spriteBatch.Draw
            (
                MGame.GraphicUtilities.Rectangle,
                new Rectangle (Position.ToPoint (), new Point (20)),
                null,
                CheckBoxBackgroundColor,
                Rotation,
                Vector2.Zero,
                SpriteEffects.None,
                SortingOrder
            );

            if (Checked)
            {
                spriteBatch.Draw
                (
                    MGame.GraphicUtilities.Checkmark,
                    new Rectangle (Position.ToPoint () + new Point (5, 4), new Point (12)),
                    null,
                    Color,
                    Rotation,
                    Vector2.Zero,
                    SpriteEffects.None,
                    SortingOrder + 0.01f
                );
            }
        }
    }
}