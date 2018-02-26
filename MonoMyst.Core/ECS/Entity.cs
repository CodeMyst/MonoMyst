using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Core.ECS
{
    public class Entity
    {
        public string Name { get; }

        public Point Position;

        private List<Component> components = new List<Component> ();

        public Entity (string name)
        {
            Name = name;
        }

        public T AddComponent<T> () where T : Component, new ()
        {
            T component = new T
            {
                Entity = this
            };
            components.Add (component);
            return component;
        }

        public T GetComponent<T> () where T : Component, new ()
        {
            return components.Find (s => s.GetType () == typeof (T)) as T;
        }

        public virtual void Update (float deltaTime)
        {
            foreach (Component c in components)
                c.Update (deltaTime);
        }

        public virtual void Draw (SpriteBatch spriteBatch)
        {
            foreach (Component c in components)
                c.Draw (spriteBatch);
        }
    }
}
