using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.ECS
{
    public class Entity
    {
        public string Name { get; }

        public Vector2 Position;
        public float Scale = 1f;

        private List<Component> components;

        public Entity (string name)
        {
            components = new List<Component> ();
            Name = name;
        }

        public T AddComponent<T> () where T : Component, new ()
        {
            T component = new T ();
            component.Entity = this;
            components.Add (component);
            return component;
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