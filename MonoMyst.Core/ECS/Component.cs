using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Core.ECS
{
    public class Component
    {
        public Entity Entity;

        public virtual void Update (float deltaTime) { }
        public virtual void Draw (SpriteBatch spriteBatch) { }
    }
}
