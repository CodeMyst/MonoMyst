using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoMyst.Engine.Graphics;
using System;

namespace MonoMyst.Engine.UI.Widgets
{
    public class ButtonWidget : Widget
    {
        public string Text
        {
            get => textBlock.Text;
            set => textBlock.Text = value;
        }

        public Color TextColor = Color.White;
        public float FontSize = 1f;

        public Color BackgroundColor = MonoMystColors.MonoMystColor;

        public Color HoverBackgroundColor = MonoMystColors.MonoMystLighterColor;
        public Color ClickedColor = MonoMystColors.MonoMystDarkerColor;

        private bool hovering;
        private bool clicked;

        private MouseState currentState;
        private MouseState previousState;

        public event Action OnClicked;

        private SpriteFont font;

        private TextBlockWidget textBlock;

        public ButtonWidget (string text)
        {
            textBlock = new TextBlockWidget (text)
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            AddChild (textBlock);
            Text = text;
        }

        public override void Initialize ()
        {
            base.Initialize ();

            font = MonoMystGame.MMContent.Load<SpriteFont> ("NotoSansRegular");
        }

        public override void Update (float deltaTime)
        {
            base.Update (deltaTime);

            currentState = Mouse.GetState ();

            Rectangle mouseRect = new Rectangle (currentState.Position, new Point (1, 1));

            if (new Rectangle (DrawPosition.ToPoint (), DrawSize.ToPoint ()).Intersects (mouseRect))
                hovering = true;
            else
            {
                hovering = false;
                clicked = false;
            }

            if (hovering && Enabled && currentState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released)
            {
                OnClicked?.Invoke ();
                clicked = true;
            }
            else if (clicked && Enabled && currentState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Pressed)
            {
                clicked = true;
            }
            else
            {
                clicked = false;
            }

            previousState = currentState;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            spriteBatch.Draw
                (
                    GraphicUtilities.Rectangle,
                    new Rectangle (DrawPosition.ToPoint (), DrawSize.ToPoint ()),
                    null,
                    clicked ? ClickedColor : hovering ? HoverBackgroundColor : BackgroundColor,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    SortingOrder
                );
        }
    }
}
