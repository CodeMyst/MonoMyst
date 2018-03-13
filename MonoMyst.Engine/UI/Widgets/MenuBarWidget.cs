using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class MenuBarWidget : Widget
    {
        public Color Color = MonoMystColors.MonoMystColor;

        private SpriteFont font;

        private HorizontalLayoutGroupWidget horizontalLayoutGroup;

        public MenuBarWidget ()
        {
            horizontalLayoutGroup = new HorizontalLayoutGroupWidget
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
            AddChild (horizontalLayoutGroup);
            Size.Y = 20;
        }

        public override void Initialize ()
        {
            base.Initialize ();

            font = MonoMystGame.MMContent.Load<SpriteFont> ("NotoSans_Regular");
        }

        public void AddButton (MenuBarButtonWidget button)
        {
            horizontalLayoutGroup.AddChild (button);
        }

        public override void Update (float deltaTime)
        {
            base.Update (deltaTime);
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            spriteBatch.Draw (GraphicUtilities.Rectangle, new Rectangle (0, 0, ScreenWidth, (int) DrawSize.Y), Color);
        }
    }
}
