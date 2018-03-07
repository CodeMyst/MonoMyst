using MonoMyst.Engine;
using MonoMyst.Engine.ECS;

namespace MonoMyst.LevelEditor
{
    public class LevelEditorGame : MonoMystGame
    {
        public LevelEditorGame () : base ()
        {
            GraphicsDeviceManager.PreferredBackBufferWidth = 1280 + 350;
            GraphicsDeviceManager.PreferredBackBufferHeight = 795;
            GraphicsDeviceManager.ApplyChanges ();
            Window.AllowAltF4 = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize ()
        {
            base.Initialize ();

            Scene main = new MainScene (this, GraphicsDevice);
            NextScene (main);
        }
    }
}
