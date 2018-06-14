/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System.Collections;
using System.Collections.Generic;

namespace MonoMyst.Engine.ECS
{
    public class EntityPool : IEnumerable<Entity>
    {
        private List<Entity> entities = new List<Entity> ();

        public int Count => entities.Count;

        public event EntityChangedDelegate OnEntityAdded;
        public event EntityChangedDelegate OnEntityRemoved;
        public event EntityChangedDelegate OnEntityComponentAdded;
        public event EntityChangedDelegate OnEntityComponentRemoved;

        public IEnumerator<Entity> GetEnumerator() => entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Add (Entity entity)
        {
            entities.Add (entity);
            OnEntityAdded?.Invoke (this, entity);
        }

        internal void InvokeComponentAdded (Entity entity)
        {
            OnEntityComponentAdded?.Invoke (this, entity);
        }
    }

    public delegate void EntityChangedDelegate (EntityPool entities, Entity entity);
}