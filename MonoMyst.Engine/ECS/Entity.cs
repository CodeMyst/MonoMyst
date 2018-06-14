/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System;
using System.Linq;
using System.Collections.Generic;

namespace MonoMyst.Engine.ECS
{
    public class Entity
    {
        public string Name { get; }

        private List<IComponent> components = new List<IComponent> ();

        public EntityPool OwnerPool { get; }

        public Entity (string name)
        {
            Name = name;
            OwnerPool = MGame.CurrentScene.Entities;
            MGame.CurrentScene.RegisterEntity (this);
        }

        public T AddComponent<T>() where T : IComponent, new()
        {
            T component = new T ();
            components.Add (component);
            OwnerPool.InvokeComponentAdded (this);
            return component;
        }

        public bool HasComponent (Type type)
        {
            if (!type.IsComponent ())
                throw new Exception ("Specified type isn't a Component.");

            if (components.Any (c => c.GetType () == type))
                return true;

            return false;
        }

        public bool HasComponents (IEnumerable<Type> compatibleTypes)
        {
            foreach (Type t in compatibleTypes)
                if (!HasComponent (t))
                    return false;

            return true;
        }

        public T GetComponent<T> () where T : IComponent => (T) components.First (c => c.GetType () == typeof (T));
    }
}