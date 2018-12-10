using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;
using MonoMyst.Engine.Graphics;
using MonoMyst.Engine.UI.Widgets;

namespace MonoMyst.Engine
{
    public class MGame : Game
    {
        public static Scene CurrentScene { get; private set; }

        private SpriteBatch spriteBatch;

        public static Camera Camera { get; private set; }

        protected GraphicsDeviceManager GraphicsDeviceManager { get; private set; }

        private RasterizerState rasterizerState = new RasterizerState () { ScissorTestEnable = true };

        public static XNBContentManager EmbeddedContent { get; private set; }

        public static GraphicUtilities GraphicUtilities { get; private set; }

        public static GameServiceContainer GameServices { get; private set; }

        public static double FPS { get; set; }

        private Input input;

        public MGame ()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager (this);

            GameServices = new GameServiceContainer ();

            IsMouseVisible = true;

            Camera = new Camera (GraphicsDevice)
            {
                Position = Vector2.Zero
            };

            input = new Input ();
        }

        protected override void Initialize ()
        {
            base.Initialize ();
        }

        protected override void LoadContent()
        {
            base.LoadContent ();

            spriteBatch = new SpriteBatch (GraphicsDevice);

            EmbeddedContent = new XNBContentManager (GraphicsDevice);
            GraphicUtilities = new GraphicUtilities ();

            Content.RootDirectory = "Content";
            GameServices.AddService<ContentManager> (Content);
        }

        protected override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            input.StartState ();
            CurrentScene.Update (deltaTime);
            input.EndState ();
        }

        protected override void Draw (GameTime gameTime)
        {
            GraphicsDevice.Clear (CurrentScene.ClearColor);

            spriteBatch.Begin (transformMatrix: Camera.Transform, samplerState: SamplerState.AnisotropicWrap, sortMode: SpriteSortMode.FrontToBack);

            CurrentScene.Draw (spriteBatch);

            spriteBatch.End ();

            spriteBatch.Begin (sortMode: SpriteSortMode.FrontToBack, rasterizerState: rasterizerState);

            // UI draw

            FPS = 1 / gameTime.ElapsedGameTime.TotalSeconds;

            spriteBatch.End ();

            base.Draw (gameTime);
        }

        protected void NextScene (Scene scene)
        {
            CurrentScene = scene;
            CurrentScene.Initialize ();
        }
    }
}
