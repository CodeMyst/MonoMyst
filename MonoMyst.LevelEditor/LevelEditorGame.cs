using MonoMyst.Engine;
using MonoMyst.Engine.ECS;

namespace MonoMyst.LevelEditor
{
    public class LevelEditorGame : MonoMystGame
    {
        protected override void Initialize ()
        {
            base.Initialize ();

            Scene main = new MainScene (this, GraphicsDevice);
            NextScene (main);
        }
    }
}
