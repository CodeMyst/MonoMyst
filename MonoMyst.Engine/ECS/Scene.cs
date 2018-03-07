using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.UI;

namespace MonoMyst.Engine.ECS
{
    public class Scene
    {
        /// <summary>
        /// The current active scene.
        /// </summary>
        public static Scene Current { get; internal set; }

        public MonoMystGame Game { get; }
        public GraphicsDevice GraphicsDevice { get; }

        /// <summary>
        /// The color with which the screen will be cleared in this scene.
        /// </summary>
        public Color ClearColor = new Color (29, 29, 29);

        protected ContentManager Content;

        protected UIHost UI;

        private List<Entity> entities = new List<Entity> ();

        public Scene (MonoMystGame game, GraphicsDevice graphicsDevice)
        {
            Game = game;
            GraphicsDevice = graphicsDevice;
            UI = game.UI;
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

        /// <summary>
        /// Registers an entity so the entity will receive all the events. Without it the entity is basically useless.
        /// </summary>
        /// <param name="e"></param>
        internal void RegisterEntity (Entity e)
        {
            entities.Add (e);
        }
    }
}
