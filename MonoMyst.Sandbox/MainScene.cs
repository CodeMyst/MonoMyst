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
                Color = Color.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Origin = new Vector2 (0.5f, 0.5f)
            };

            TextBlock text = new TextBlock
            {
                Text = "Apartments simplicity or understood do it we. Song such eyes had and off. Removed winding ask explain delight out few behaved lasting.",
                Color = Color.Black,
                TextWrapping = TextWrapping.WordWrap
            };

            panel.AddChild (text);

            main.AddChild (panel);

            UI.AddCanvas (main);
        }
    }
}
