using MonoMyst.Engine;

namespace MonoMyst.Sandbox
{
    public class Game1 : MGame
    {
        public Game1 () : base ()
        {
            GraphicsDeviceManager.PreferredBackBufferWidth = 1280;
            GraphicsDeviceManager.PreferredBackBufferHeight = 720;
            GraphicsDeviceManager.ApplyChanges ();
        }

        protected override void Initialize ()
        {
            base.Initialize ();

            var scene = new MainScene (this);
            NextScene (scene);
        }
    }
}
