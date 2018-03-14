using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class MenuBarSubmenuWidget : Widget
    {
        private List<MenuBarButtonWidget> buttons = new List<MenuBarButtonWidget> ();

        private SpriteFont font;

        public MenuBarSubmenuWidget ()
        {
            Initialize ();
        }

        public void AddButton (MenuBarButtonWidget button)
        {
            buttons.Add (button);
            button.Initialize ();
        }

        public override void Initialize ()
        {
            base.Initialize ();

            font = MonoMystGame.MMContent.Load<SpriteFont> ("NotoSansRegular");
        }

        public override void Update (float deltaTime)
        {
            base.Update (deltaTime);

            foreach (MenuBarButtonWidget b in buttons)
                b.Update (deltaTime);
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            Position.X = Parent.Position.X;
            Position.Y = Parent.DrawSize.Y;
            Size = new Vector2 (150, buttons.Count * 20);
            SortingOrder = Parent.SortingOrder;

            DrawPosition = Position;
            DrawSize = Size;

            spriteBatch.Draw
                (
                    GraphicUtilities.Rectangle,
                    new Rectangle (DrawPosition.ToPoint (), DrawSize.ToPoint ()),
                    null,
                    MonoMystColors.MonoMystColor,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    SortingOrder
                );

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons [i].Position = new Vector2 (Position.X, Position.Y + (i * 20));
                buttons [i].Size = new Vector2 (150, 20);
                buttons [i].SortingOrder = SortingOrder + 0.01f;
                buttons [i].Draw (spriteBatch);
            }
        }
    }
}
