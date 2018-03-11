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

            //MenuBarWidget menuBar = new MenuBarWidget ();
            //menuBar.AddButton (new MenuBarButtonWidget ("File", MenuBarButtonType.Category));
            //menuBar.AddButton (new MenuBarButtonWidget ("Edit", MenuBarButtonType.Category));
            //menuBar.AddButton (new MenuBarButtonWidget ("Help", MenuBarButtonType.Category));

            //UI.AddWidget (menuBar);

            //PanelWithTitleBarWidget layersPanel = new PanelWithTitleBarWidget
            //{
            //    HorizontalAlignment = HorizontalAlignment.Right,
            //    VerticalAlignment = VerticalAlignment.Stretch,
            //    Title = "Layers"
            //};
            //layersPanel.Size.X = 300;

            //PanelWidget toolsPanel = new PanelWidget
            //{
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    VerticalAlignment = VerticalAlignment.Stretch,
            //    Color = Color.Blue
            //};
            //toolsPanel.Size.X = 50;

            //PanelWidget tilesPanel = new PanelWidget
            //{
            //    HorizontalAlignment = HorizontalAlignment.Stretch,
            //    VerticalAlignment = VerticalAlignment.Bottom,
            //    Color = Color.Red,
            //    Padding = new Thickness (50, 0, 300, 0)
            //};
            //tilesPanel.Size.Y = 75;

            //UI.AddWidget (layersPanel);
            //UI.AddWidget (toolsPanel);
            //UI.AddWidget (tilesPanel);

            PanelWidget panelWidget = new PanelWidget
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Size = new Vector2 (500, 500),
            };

            PanelWidget childPanel = new PanelWidget
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch,
                Color = Color.Red,
                Size = new Vector2 (50, 50)
            };

            panelWidget.AddChild (childPanel);

            UI.AddWidget (panelWidget);
        }
    }
}
