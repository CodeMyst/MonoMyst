using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.ECS
{
    /// <summary>
    /// Entity is a base object in the scene. It holds <seealso cref="Component"/>s which do the logic.
    /// </summary>
    public class Entity
    {
        public string Name { get; set; }

        public Transform Transform { get; private set; }

        private List<Component> components = new List<Component> ();

        public Entity Parent { get; private set; }
        private List<Entity> children = new List<Entity> ();

        protected Entity (string name, Scene scene)
        {
            Name = name;
            scene.RegisterEntity (this);
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

        public void SetParent (Entity e)
        {
            Parent = e;
            e.children.Add (this);
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

        public static string GetHierarchy (Entity e, string indent, bool last)
        {
            string h = $"{indent}+- {e.Name}";
            if (e.components.Count > 0)
            {
                h += " (";
                foreach (Component c in e.components)
                    h += $"{c.GetType ().Name}, ";
                h = h.Remove (h.Length - 2);
                h += ")";
            }
            h += "\n";

            indent += last ? "    " : "|  ";

            for (int i = 0; i < e.children.Count; i++)
            {
                h += GetHierarchy (e.children [i], indent, i == e.children.Count - 1);
            }

            return h;
        }
    }
}
