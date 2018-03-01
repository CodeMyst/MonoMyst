using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Core.ECS
{
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
