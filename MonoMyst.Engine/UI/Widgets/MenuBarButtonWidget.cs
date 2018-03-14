using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class MenuBarButtonWidget : Widget
    {
        public string Title { get; protected set; }
        protected MenuBarButtonType ButtonType;
        private MenuBarButtonPosition menuPosition = MenuBarButtonPosition.TopMenu;

        private SpriteFont font;

        public event Action OnClicked;

        public Color NormalBackgroundColor = Color.Transparent;
        public Color HoverBackgroundColor = MonoMystColors.MonoMystLighterColor;
        public Color ClickedColor = MonoMystColors.MonoMystDarkerColor;

        private bool hovering;

        private MouseState currentState;
        private MouseState previousState;

        public bool Enabled = true;

        public MenuBarSubmenuWidget Submenu { get; private set; }

        public MenuBarButtonWidget (string title, MenuBarButtonType buttonType, bool enabled)
        {
            Title = title;
            ButtonType = buttonType;
            Enabled = enabled;
            Submenu = new MenuBarSubmenuWidget
            {
                Parent = this,
                Visible = false
            };
            AddChild (Submenu);
        }

        public override void Initialize ()
        {
            base.Initialize ();

            font = MonoMystGame.MMContent.Load<SpriteFont> ("NotoSansRegular");

            OnClicked += MenuBarButtonWidget_OnClicked;
        }

        private void MenuBarButtonWidget_OnClicked ()
        {
            Submenu.Visible = !Submenu.Visible;
            if (menuPosition == MenuBarButtonPosition.SubMenu)
            {
                Parent.Visible = false;
            }
        }

        public void AddButton (MenuBarButtonWidget button)
        {
            Submenu.AddButton (button);
            button.menuPosition = MenuBarButtonPosition.SubMenu;
        }

        public override void Update (float deltaTime)
        {
            base.Update (deltaTime);

            currentState = Mouse.GetState ();

            Rectangle mouseRect = new Rectangle (currentState.Position, new Point (1, 1));

            if (new Rectangle (DrawPosition.ToPoint (), DrawSize.ToPoint ()).Intersects (mouseRect))
                hovering = true;
            else
                hovering = false;

            if (hovering && Enabled && currentState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released)
            {
                OnClicked?.Invoke ();
            }
            else if (!hovering && !new Rectangle (Submenu.DrawPosition.ToPoint (), Submenu.DrawSize.ToPoint ()).Intersects (mouseRect) && currentState.LeftButton == ButtonState.Pressed)
            {
                Submenu.Visible = false;
            }

            previousState = currentState;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            DrawPosition = Position;

            Vector2 textSize = font.MeasureString (Title) * 0.75f;

            Size = textSize + new Vector2 (12, 0);

            spriteBatch.Draw
                (
                    GraphicUtilities.Rectangle,
                    new Rectangle (DrawPosition.ToPoint (), DrawSize.ToPoint ()),
                    null,
                    hovering ? HoverBackgroundColor : NormalBackgroundColor,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    SortingOrder - 0.001f
                );

            spriteBatch.DrawString
                (
                    font,
                    Title,
                    DrawPosition + new Vector2 (5, 2),
                    Enabled ? Color.White : Color.Gray,
                    0f,
                    Vector2.Zero,
                    0.75f,
                    SpriteEffects.None,
                    SortingOrder
                );
        }
    }

    internal enum MenuBarButtonPosition
    {
        TopMenu,
        SubMenu
    }
}
