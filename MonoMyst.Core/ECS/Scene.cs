using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Core.ECS
{
    public class Scene
    {
        public MonoMystGame Game { get; }
        public GraphicsDevice GraphicsDevice { get; }

        public Color ClearColor = new Color (29, 29, 29);

        protected ContentManager Content;

        private List<Entity> entities = new List<Entity> ();

        public Scene (MonoMystGame game, GraphicsDevice graphicsDevice)
        {
            Game = game;
            GraphicsDevice = graphicsDevice;
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
            Entity e = new Entity (name);
            entities.Add (e);
            return e;
        }
    }
}
