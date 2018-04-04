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

            Panel panel = new Panel
            {
                Scale = new Vector2 (100, 100),
                Color = Color.MonoGameOrange,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            main.AddChild (panel);

            UI.AddCanvas (main);
        }
    }
}
