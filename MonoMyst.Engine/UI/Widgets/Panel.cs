using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class Panel : Widget
    {
        internal protected override void Update (float deltaTime)
        {
            base.Update (deltaTime);
        }

        internal protected override void Draw (SpriteBatch spriteBatch)
        {
            base.Draw (spriteBatch);

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
