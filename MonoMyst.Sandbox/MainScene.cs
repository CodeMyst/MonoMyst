using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine;
using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;
using MonoMyst.Engine.UI.Widgets;

namespace MonoMyst.Sandbox
{
    public class MainScene : Scene
    {
        private Panel panel;

        public MainScene (MonoMystGame game, GraphicsDevice graphicsDevice) : base (game, graphicsDevice)
        {
        }

        public override void Initialize ()
        {
            base.Initialize ();

            Canvas main = new Canvas ()
            {
                Padding = new Thickness (20)
            };

			panel = new Panel
            {
                Scale = new Vector2 (200, 200),
                Color = new Color (33, 33, 33),
                Padding = new Thickness (20),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            Panel child = new Panel
            {
                Scale = new Vector2 (100, 100),
                Color = new Color (123, 123, 123),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };

            panel.AddChild (child);
            
            main.AddChild (panel);

            UI.AddCanvas (main);
        }

        public override void Update (float deltaTime)
        {
            if (Keyboard.GetState ().IsKeyDown (Keys.Up))
                panel.Transform.Scale.Y += 5f;
            if (Keyboard.GetState ().IsKeyDown (Keys.Down))
                panel.Transform.Scale.Y -= 5f;
            if (Keyboard.GetState ().IsKeyDown (Keys.Right))
                panel.Transform.Scale.X += 5f;
            if (Keyboard.GetState ().IsKeyDown (Keys.Left))
                panel.Transform.Scale.X -= 5f;
        }
    }
}
