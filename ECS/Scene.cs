using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.ECS
{
    public class Scene
    {
        public Game Game;

        public Color ClearColor = Color.Black;

        protected ContentManager Content;

        private List<Entity> entities;

        public Scene ()
        {
            entities = new List<Entity> ();
        }

        public virtual void Initialize ()
        {
            Content = new ContentManager (Game.Services)
            {
                RootDirectory = "Content"
            };
        }

        public virtual void Update (float deltaTime)
        {
            foreach (Entity e in entities)
                e.Update (deltaTime);
        }

        public virtual void Draw (SpriteBatch spriteBatch)
        {
            foreach (Entity e in entities)
                e.Draw (spriteBatch);
        }

        protected Entity CreateEntity (string name)
        {
            Entity entity = new Entity (name);
            entities.Add (entity);
            return entity;
        }
    }
}