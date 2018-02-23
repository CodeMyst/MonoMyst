using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.ECS
{
    public class Scene
    {
        private List<Entity> entities;

        public virtual void Initialize () { }
        public virtual void Update (float deltaTime) { }
        public virtual void Draw (SpriteBatch spriteBatch) { }
    }
}