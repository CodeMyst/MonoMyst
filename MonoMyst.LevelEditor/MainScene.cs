using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine;
using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;
using MonoMyst.Engine.UI.Widgets;
using Microsoft.Xna.Framework;

namespace MonoMyst.LevelEditor
{
    public class MainScene : Scene
    {
        private int ScreenWidth => GraphicsDevice.PresentationParameters.Bounds.Width;
        private int ScreenHeight => GraphicsDevice.PresentationParameters.Bounds.Height;

        public MainScene (MonoMystGame game, GraphicsDevice graphicsDevice) : base (game, graphicsDevice)
        {
        }

        public override void Initialize ()
        {
            base.Initialize ();

            PanelWidget layersPanel = new PanelWidget
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            layersPanel.Size.X = 300;

            PanelWidget toolsPanel = new PanelWidget
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Stretch,
                Color = Color.Blue
            };
            toolsPanel.Size.X = 50;

            PanelWidget tilesPanel = new PanelWidget
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom,
                Color = Color.Red
            };
            tilesPanel.Size.Y = 75;

            UI.AddWidget (layersPanel);
            UI.AddWidget (toolsPanel);
            UI.AddWidget (tilesPanel);
        }
    }
}
