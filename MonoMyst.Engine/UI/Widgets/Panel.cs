using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine.UI.Widgets
{
    public class Panel : Widget
    {
        public override void Update (float deltaTime)
        {
            base.Update (deltaTime);

            if (Keyboard.GetState ().IsKeyDown (Keys.Right))
                Scale += new Vector2 (10f, 0f);
            else if (Keyboard.GetState ().IsKeyDown (Keys.Up))
                Scale += new Vector2 (0f, 10f);
        }

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
