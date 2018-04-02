using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.ECS
{
    /// <summary>
    /// A components sits on an <seealso cref="MonoMyst.Engine.ECS.Entity"/> and does the logic.
    /// </summary>
    public class Component
    {
        /// <summary>
        /// The Entity this component is placed on.
        /// </summary>
        public Entity Entity;

        public virtual void Update (float deltaTime) { }
        public virtual void Draw (SpriteBatch spriteBatch) { }
    }
}
