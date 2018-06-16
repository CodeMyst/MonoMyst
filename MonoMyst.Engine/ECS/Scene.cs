/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.UI;

namespace MonoMyst.Engine.ECS
{
    /// <summary>
    /// Holds all the entities. You can do additional logic from here.
    /// </summary>
    public class Scene : MObject
    {
        public EntityPool Entities { get; private set; } = new EntityPool ();

        public List<ComponentSystem> Systems { get; } = new List<ComponentSystem> ();

        /// <summary>
        /// The color with which the screen will be cleared.
        /// </summary>
        public Color ClearColor { get; set; } = MColors.Nero;

        protected UIHost UI { get; set; }

        protected internal override void Initialize ()
        {
            UI = new UIHost ();
        }

        protected internal override void Update (float deltaTime)
        {
            foreach (ComponentSystem system in Systems)
                system.Update (deltaTime);

            UI.Update (deltaTime);
        }

        protected internal override void Draw (SpriteBatch spriteBatch)
        {
            foreach (ComponentSystem system in Systems)
                system.Draw (spriteBatch);

            UI.Draw (spriteBatch);
        }

        /// <summary>
        /// Adds an entity to this scene's <see cref="EntityPool" />
        /// </summary>
        internal void RegisterEntity (Entity entity)
        {
            Entities.Add (entity);
        }
    }
}