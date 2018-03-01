using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Core.ECS
{
    public class Entity
    {
        public string Name { get; set; }

        public Transform Transform { get; private set; }

        private List<Component> components = new List<Component> ();

        private Entity ()
        {
            Transform = new Transform (Vector2.Zero, 0f, Vector2.One);
        }

        public Vector2 Position
        {
            get { return Transform.Position; }
            set { Transform = new Transform (value, Transform.Rotation, Transform.Scale); }
        }

        public float Rotation
        {
            get { return Transform.Rotation; }
            set { Transform = new Transform (Transform.Position, value, Transform.Scale); }
        }

        public Vector2 Scale
        {
            get { return Transform.Scale; }
            set { Transform = new Transform (Transform.Position, Transform.Rotation, value); }
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
