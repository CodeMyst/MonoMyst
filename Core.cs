using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.ECS;

namespace MonoMyst
{
    public class Core : Game
    {
        public static Scene Scene;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Core()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges ();
        }

        protected override void Initialize()
        {
            base.Initialize();

            Scene = new Scene ();

            Scene.Initialize ();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch (GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            Scene.Update (deltaTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin ();

            Scene.Draw (spriteBatch);

            spriteBatch.End ();

            base.Draw(gameTime);
        }
    }
}
