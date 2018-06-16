/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System;
using System.Linq;
using System.Collections.Generic;

namespace MonoMyst.Engine.ECS
{
    /// <summary>
    /// Data container which holds a list of entities.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Entity's name, doesn't serve any purpose yet.
        /// </summary>
        public string Name { get; }

        private List<IComponent> components = new List<IComponent> ();

        /// <summary>
        /// The <see cref="EntityPool" /> this entity is a part of.
        /// </summary>
        public EntityPool OwnerPool { get; }

        public Entity (string name)
        {
            Name = name;
            OwnerPool = MGame.CurrentScene.Entities;
            MGame.CurrentScene.RegisterEntity (this);
        }

        /// <summary>
        /// Adds a component to this entity.
        /// </summary>
        public T AddComponent<T>() where T : IComponent, new()
        {
            T component = new T ();
            components.Add (component);
            OwnerPool.InvokeComponentAdded (this);
            return component;
        }

        /// <summary>
        /// Checks if this entity has a specified component.
        /// </summary>
        /// <param name="type">Type of the component</param>
        public bool HasComponent (Type type)
        {
            if (!type.IsComponent ())
                throw new Exception ("Specified type isn't a Component.");

            if (components.Any (c => c.GetType () == type))
                return true;

            return false;
        }

        /// <summary>
        /// Checks if this entity has all of the specified component types.
        /// </summary>
        /// <param name="compatibleTypes">List of component types to be checked</param>
        public bool HasComponents (IEnumerable<Type> compatibleTypes)
        {
            foreach (Type t in compatibleTypes)
                if (!HasComponent (t))
                    return false;

            return true;
        }

        /// <summary>
        /// Finds the first component of specified type on this entity.
        /// </summary>
        /// <returns>Returns null if it couldn't find a component</returns>
        public T GetComponent<T> () where T : IComponent => (T) components.FirstOrDefault (c => c.GetType () == typeof (T));
    }
}