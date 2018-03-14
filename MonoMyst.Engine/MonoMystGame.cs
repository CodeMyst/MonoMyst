using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;

namespace MonoMyst.Engine
{
    public class MonoMystGame : Game
    {
        public static Scene Scene { get; private set; }

        private SpriteBatch spriteBatch;

        public static Camera Camera { get; private set; }

        protected GraphicsDeviceManager GraphicsDeviceManager;
        internal static ContentManager MMContent;

        public UIHost UI { get; private set; }

        public MonoMystGame ()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager (this);

            ResourceContentManager resxContent = new ResourceContentManager (Services, Resources.ResourceManager);
            MMContent = resxContent;

            IsMouseVisible = true;

            Camera = new Camera (GraphicsDevice)
            {
                Position = Vector2.Zero
            };
        }

        protected override void Initialize ()
        {
            base.Initialize ();
        }

        protected override void LoadContent ()
        {
            spriteBatch = new SpriteBatch (GraphicsDevice);
            UI = new UIHost (new ContentManager (Services), GraphicsDevice);
        }

        protected override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            Scene.Update (deltaTime);

            UI.Update (deltaTime);

            if (Keyboard.GetState ().IsKeyDown (Keys.Left))
                Camera.Position.X -= 50f * deltaTime;
            if (Keyboard.GetState ().IsKeyDown (Keys.Up))
                Camera.Position.Y -= 50f * deltaTime;
            if (Keyboard.GetState ().IsKeyDown (Keys.Right))
                Camera.Position.X += 50f * deltaTime;
            if (Keyboard.GetState ().IsKeyDown (Keys.Down))
                Camera.Position.Y += 50f * deltaTime;
        }

        protected override void Draw (GameTime gameTime)
        {
            GraphicsDevice.Clear (Scene.ClearColor);

            spriteBatch.Begin (transformMatrix: Camera.Transform);

            Scene.Draw (spriteBatch);

            spriteBatch.End ();

            spriteBatch.Begin (sortMode: SpriteSortMode.FrontToBack);

            UI.Draw (spriteBatch);

            spriteBatch.End ();

            base.Draw (gameTime);
        }

        /// <summary>
        /// Switches to the next scene.
        /// </summary>
        public void NextScene (Scene scene)
        {
            Scene = scene;
            Scene.Current = Scene;
            Scene.Initialize ();
        }
    }
}
