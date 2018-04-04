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
                Scale = new Vector2 (200, 200),
                Color = new Color (33, 33, 33),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness (20),
            };

            Panel child1 = new Panel
            {
                Scale = new Vector2 (50, 50),
                Color = new Color (123, 123, 123),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            panel.AddChild (child1);

            main.AddChild (panel);

            UI.AddCanvas (main);
        }
    }
}
