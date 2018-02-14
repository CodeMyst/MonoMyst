using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using TiledSharp;

using MonoMyst.TileSystem;

namespace MonoMyst
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private TmxMap map;
        private Texture2D tileset;

        private TileSystem.TileSystem tileSystem;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            map = new TmxMap ("Content/LevelSet1.tmx");
            tileset = Content.Load<Texture2D> ("Grass");
            tileSystem = new TileSystem.TileSystem (map, tileset);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin ();

            tileSystem.Draw (spriteBatch);

            spriteBatch.End ();

            base.Draw(gameTime);
        }
    }
}
