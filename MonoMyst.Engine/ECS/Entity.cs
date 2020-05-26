/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

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

        private List<Component> components = new List<Component> ();

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
        public T AddComponent<T> () where T : Component, new ()
        {
            T component = new T ();
            components.Add (component);
            ((Component) component).Entity = this;
            OwnerPool.InvokeComponentAdded (this);
            return component;
        }

        /// <summary>
        /// Adds a component to this entity.
        /// </summary>
        public Component AddComponent (Type t)
        {
            Component component = (Component) Activator.CreateInstance (t);
            components.Add (component);
            ((Component) component).Entity = this;
            OwnerPool.InvokeComponentAdded (this);
            return component;
        }

        /// <summary>
        /// Adds a component to this entity if it doesn't exist. If it exists it just returns the existing component.
        /// </summary>
        public T AddComponentIfDoesntExist<T> () where T : Component, new ()
        {
            if (!HasComponent<T> ()) return AddComponent<T> ();
            else return GetComponent<T> ();
        }

        /// <summary>
        /// Removes the first component of type T
        /// </summary>
        public void RemoveComponent<T> () where T : Component
        {
            T c = (T) components.FirstOrDefault (a => a.GetType () == typeof (T));
            if (c != null)
            {
                RemoveComponent (c);
                OwnerPool.InvokeComponentRemoved (this);
            }
        }

        /// <summary>
        /// Removes the component by instance
        /// </summary>
        /// <param name="component">Instance of the component to remove</param>
        public void RemoveComponent (Component component)
        {
            component.Entity = null;
            components.Remove (component);
            OwnerPool.InvokeComponentRemoved (this);
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
        /// Checks if this entity has a specified component.
        /// </summary>
        /// <param name="type">Type of the component</param>
        public bool HasComponent<T> () where T : Component
        {
            return HasComponent (typeof (T));
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
        public T GetComponent<T> () where T : Component => (T) components.FirstOrDefault (c => c.GetType () == typeof (T));

        /// <summary>
        /// Finds all components for specified type on this entity.
        /// </summary>
        public IEnumerable<T> GetComponents<T> () where T : Component
        {
            Component [] cs = (Component []) components.FindAll (c => c.GetType () == typeof (T)).ToArray ();
        
            List<T> result = new List<T> ();

            foreach (Component c in cs)
                result.Add ((T) c);

            return result;
        }

        /// <summary>
        /// Destroys the entity.
        /// </summary>
        public void Destroy ()
        {
            for (int i = 0; i < components.Count; i++)
            {
                RemoveComponent(components[i]);
            }

            OwnerPool.Remove (this);
        }
    }
}