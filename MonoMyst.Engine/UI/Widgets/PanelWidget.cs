using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class PanelWidget : Widget
    {
        public override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

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
