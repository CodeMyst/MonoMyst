/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.ECS
{
    public class Scene : MObject
    {
        public EntityPool Entities { get; private set; } = new EntityPool ();

        public List<ComponentSystem> Systems { get; } = new List<ComponentSystem> ();

        public Color ClearColor { get; set; } = MonoMystColors.Nero;

        protected internal override void Initialize ()
        {
        }

        protected internal override void Update (float deltaTime)
        {
            foreach (ComponentSystem system in Systems)
                system.Update (deltaTime);
        }

        protected internal override void Draw (SpriteBatch spriteBatch)
        {
            foreach (ComponentSystem system in Systems)
                system.Draw (spriteBatch);
        }

        internal void RegisterEntity (Entity entity)
        {
            Entities.Add (entity);
        }
    }
}