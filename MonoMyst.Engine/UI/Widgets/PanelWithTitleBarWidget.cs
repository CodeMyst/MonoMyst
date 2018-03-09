using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class PanelWithTitleBarWidget : Widget
    {
        public Color BackgroundColor = Color.White;
        public Color TitleBarColor = MonoMystColors.MonoMystColor;
        public Color TitleTextColor = Color.White;

        public string Title = "Panel Title";

        protected SpriteFont Font;

        public override void Initialize ()
        {
            base.Initialize ();

            System.Console.WriteLine (MonoMystGame.MMContent.RootDirectory);
            Font = MonoMystGame.MMContent.Load<SpriteFont> ("NotoSans_Regular");
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

            spriteBatch.Draw (GraphicUtilities.Rectangle, new Rectangle ((int) DrawPosition.X, (int) DrawPosition.Y, (int) DrawSize.X, (int) DrawSize.Y), BackgroundColor);
            spriteBatch.Draw (GraphicUtilities.Rectangle, new Rectangle ((int) DrawPosition.X, (int) DrawPosition.Y, (int) DrawSize.X, 25), TitleBarColor);
            spriteBatch.DrawString (Font, Title, new Vector2 (DrawPosition.X + 5, (DrawPosition.Y + 4)), TitleTextColor, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 1f);
        }
    }
}
