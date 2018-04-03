using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine;
using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;
using MonoMyst.Engine.UI.Widgets;

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

            Canvas main = new Canvas ();

            Button button = new Button ()
            {
                Text = "Button",
                Color = Color.MonoGameOrange,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Origin = new Vector2 (0.5f, 0.5f)
            };

            main.AddChild (button);

            UI.AddCanvas (main);
        }
    }
}
