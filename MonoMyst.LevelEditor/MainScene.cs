using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine;
using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;
using MonoMyst.Engine.UI.Widgets;

namespace MonoMyst.LevelEditor
{
    public class MainScene : Scene
    {
        private int ScreenWidth => GraphicsDevice.PresentationParameters.Bounds.Width;
        private int ScreenHeight => GraphicsDevice.PresentationParameters.Bounds.Height;

        public MainScene (MonoMystGame game, GraphicsDevice graphicsDevice) : base (game, graphicsDevice)
        {
            ClearColor = Color.Black;
        }

        public override void Initialize ()
        {
            base.Initialize ();

            PanelWithTitleBarWidget layersPanel = new PanelWithTitleBarWidget
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Stretch,
                Title = "Layers"
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
                Color = Color.Red,
                Padding = new Thickness (50, 0, 300, 0)
            };
            tilesPanel.Size.Y = 75;

            UI.AddWidget (layersPanel);
            UI.AddWidget (toolsPanel);
            UI.AddWidget (tilesPanel);
        }
    }
}
