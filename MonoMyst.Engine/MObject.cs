using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine
{
    /// <summary>
    /// Has Initialize, Update and Draw methods.
    /// </summary>
    public abstract class MObject
    {
        internal protected abstract void Initialize ();

        internal protected abstract void Update (float deltaTime);

        internal protected abstract void Draw (SpriteBatch spriteBatch);
    }
}