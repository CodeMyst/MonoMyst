using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Core;
using MonoMyst.Core.ECS;

using MonoMyst.Engine.UI;

namespace MonoMyst.Sandbox
{
    public class MainScene : Scene
    {
        public MainScene (MonoMystGame game, GraphicsDevice graphicsDevice) : base (game, graphicsDevice)
        {
        }

        public override void Initialize ()
        {
            base.Initialize ();

            Entity button = CreateEntity ("Button");
            Button buttonComponent = button.AddComponent<Button> ();
            buttonComponent.Sprite = Content.Load<Texture2D> ("Sprites/Rectangle");
            buttonComponent.Size = new Point (100, 100);
        }
    }
}
