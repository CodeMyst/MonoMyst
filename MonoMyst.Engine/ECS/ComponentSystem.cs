/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.ECS
{
    /// <summary>
    /// Does logic on all entities that have the compatible components.
    /// </summary>
    public class ComponentSystem : MObject
    {
        private List<Type> compatibleTypes;

        /// <summary>
        /// All entities filtered by the compatible components.
        /// </summary>
        protected List<Entity> Entities { get; }

        public ComponentSystem (EntityPool entities, params Type [] types)
        {
            if (types.Any (t => !t.IsComponent ()))
                throw new Exception ("Type passed is not of type Component.");

            compatibleTypes = new List<Type> ();
            compatibleTypes.AddRange (types);

            entities.OnEntityAdded += EntitiesChanged;
            entities.OnEntityRemoved += EntitiesChanged;

            entities.OnEntityComponentAdded += EntitiesChanged;
            entities.OnEntityComponentRemoved += EntitiesChanged;

            Entities = new List<Entity> ();
            Entities.AddRange (GetCompatibleEntities (entities));

            MGame.CurrentScene.Systems.Add (this);
        }

        protected internal override void Initialize()
        {
        }

        protected internal override void Update (float deltaTime)
        {
        }

        protected internal override void Draw (SpriteBatch spriteBatch)
        {
        }

        /// <summary>
        /// When entities get changed refresh the entities list again.
        /// </summary>
        private void EntitiesChanged (EntityPool entities, Entity entity)
        {
            Entities.Clear ();
            Entities.AddRange (GetCompatibleEntities (entities));
        }

        /// <summary>
        /// Get all entities which have the components specified by this <see cref="ComponentSystem" />
        /// </summary>
        /// <param name="entities">List of entities which will be filtered</param>
        /// <returns>Filtered list of entities</returns>
        public IEnumerable<Entity> GetCompatibleEntities (IEnumerable<Entity> entities)
        {
            return entities.Where (e => e.HasComponents (compatibleTypes));
        }
    }
}