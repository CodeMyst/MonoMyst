using MonoMyst.Core;
using MonoMyst.Core.ECS;

namespace MonoMyst.Sandbox
{
    public class Game1 : MonoMystGame
    {
        public Game1 ()
        {
            Window.AllowUserResizing = true;
        }

        protected override void Initialize ()
        {
            base.Initialize ();

            Scene scene = new MainScene (this, GraphicsDeviceManager.GraphicsDevice);
            NextScene (scene);
        }
    }
}
