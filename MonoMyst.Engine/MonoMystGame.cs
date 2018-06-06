using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.UI;
using MonoMyst.Engine.Graphics;

namespace MonoMyst.Engine
{
    public class MonoMystGame : Game
    {
        private SpriteBatch spriteBatch;

        public static Camera Camera { get; private set; }

        protected GraphicsDeviceManager GraphicsDeviceManager { get; private set; }

        private RasterizerState rasterizerState = new RasterizerState () { ScissorTestEnable = true };

        public static XNBContentManager EmbeddedContent { get; private set; }

        public static GraphicUtilities GraphicUtilities { get; private set; }

        public MonoMystGame ()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager (this);

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

        protected override void LoadContent()
        {
            base.LoadContent ();

            spriteBatch = new SpriteBatch (GraphicsDevice);

            EmbeddedContent = new XNBContentManager (GraphicsDevice);
            GraphicUtilities = new GraphicUtilities ();
        }

        protected override void Update (GameTime gameTime)
        {
            base.Update (gameTime);

            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

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
            GraphicsDevice.Clear (MonoMystColors.Nero);

            spriteBatch.Begin (transformMatrix: Camera.Transform);

            // Scene draw

            spriteBatch.End ();

            spriteBatch.Begin (sortMode: SpriteSortMode.FrontToBack, rasterizerState: rasterizerState);

            // UI draw

            spriteBatch.End ();

            base.Draw (gameTime);
        }
    }
}
