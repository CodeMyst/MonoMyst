using MonoMyst.Core;
using MonoMyst.Core.ECS;

namespace MonoMyst.Sandbox
{
    public class Game1 : MonoMystGame
    {
        protected override void Initialize ()
        {
            base.Initialize ();

            Scene scene = new Scene (this, GraphicsDeviceManager.GraphicsDevice);
            NextScene (scene);
        }
    }
}
