using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Core.ECS
{
    public class Entity
    {
        public string Name { get; set; }

        public Point Position;

        private List<Component> components = new List<Component> ();

        private Entity ()
        {
        }

        /// <summary>
        /// Creates an entity that's tied to the specified scene.
        /// </summary>
        public static Entity CreateSceneEntity (string name, Scene scene)
        {
            Entity e = new Entity
            {
                Name = name
            };
            scene.RegisterEntity (e);
            return e;
        }

        /// <summary>
        /// Creates an entity that's tied to the current running scene
        /// </summary>
        public static Entity CreateSceneEntity (string name)
        {
            Entity e = new Entity
            {
                Name = name
            };
            Scene.Current.RegisterEntity (e);
            return e;
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
