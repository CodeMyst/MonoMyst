/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.ECS
{
    public class ComponentSystem : MObject
    {
        private List<Type> compatibleTypes;

        protected List<Entity> Entities { get; }

        public ComponentSystem (EntityPool entities, params Type [] types)
        {
            if (types.Any (t => !t.IsComponent ()))
                throw new Exception ("Type passed is not of type Component.");

            compatibleTypes = new List<Type> ();
            compatibleTypes.AddRange (types);

            entities.OnEntityAdded += EntitiesChanged;
            entities.OnEntityComponentAdded += EntitiesChanged;

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

        private void EntitiesChanged (EntityPool entities, Entity entity)
        {
            Entities.Clear ();
            Entities.AddRange (GetCompatibleEntities (entities));
            Console.WriteLine($"{GetType ().Name}.EntitiesChanged, {Entities.Count} entities in this system.");
        }

        public IEnumerable<Entity> GetCompatibleEntities (IEnumerable<Entity> entities)
        {
            return entities.Where (e => e.HasComponents (compatibleTypes));
        }
    }
}