/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System.Collections;
using System.Collections.Generic;

namespace MonoMyst.Engine.ECS
{
    /// <summary>
    /// A collection of entities. Has events for when the collection is changed.
    /// </summary>
    public class EntityPool : IEnumerable<Entity>
    {
        private List<Entity> entities = new List<Entity> ();

        /// <summary>
        /// Number of entities in this pool
        /// </summary>
        public int Count => entities.Count;

        /// <summary>
        /// Gets called when an entity has been added to this pool
        /// </summary>
        public event EntityChangedDelegate OnEntityAdded;
        /// <summary>
        /// Gets called when an entity has been removed from this pool
        /// </summary>
        public event EntityChangedDelegate OnEntityRemoved;
        /// <summary>
        /// Gets called when a component has been added to one of the entities in this pool
        /// </summary>
        public event EntityChangedDelegate OnEntityComponentAdded;
        /// <summary>
        /// Gets called when a component has been removed from one of the entities in this pool
        /// </summary>
        public event EntityChangedDelegate OnEntityComponentRemoved;

        public IEnumerator<Entity> GetEnumerator() => entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <summary>
        /// Adds an entity to this pool
        /// </summary>
        public void Add (Entity entity)
        {
            entities.Add (entity);
            OnEntityAdded?.Invoke (this, entity);
        }

        public void Remove (Entity entity)
        {
            entities.Remove (entity);
            OnEntityRemoved?.Invoke (this, null);
        }

        // TODO: I don't like the way I made the methods InvokeComponentAdded, InvokeComponentRemoved...

        /// <summary>
        /// Invokes the <see cref="OnEntityComponentAdded" /> event. Used internally because you can't invoke an event from other classes.
        /// </summary>
        /// <param name="entity"></param>
        internal void InvokeComponentAdded (Entity entity)
        {
            OnEntityComponentAdded?.Invoke (this, entity);
        }

        /// <summary>
        /// Invokes the <see cref="OnEntityComponentRemoved" /> event. Used internally because you can't invoke an event from other classes.
        /// </summary>
        /// <param name="entity"></param>
        internal void InvokeComponentRemoved (Entity entity)
        {
            OnEntityComponentRemoved?.Invoke (this, entity);
        }
    }

    /// <summary>
    /// Delegate used for events when an entity has been modified in an <see cref="EntityPool" />
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="entity"></param>
    public delegate void EntityChangedDelegate (EntityPool entities, Entity entity);
}