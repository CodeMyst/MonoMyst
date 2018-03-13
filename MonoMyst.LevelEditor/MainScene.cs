using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine;
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

            MenuBarWidget menuBar = new MenuBarWidget ();

            MenuBarButtonWidget file = new MenuBarButtonWidget ("File", MenuBarButtonType.Category, true);
            file.AddButton (new MenuBarButtonWidget ("New", MenuBarButtonType.Action, true));
            file.AddButton (new MenuBarButtonWidget ("Save", MenuBarButtonType.Action, false));
            file.AddButton (new MenuBarButtonWidget ("Load", MenuBarButtonType.Action, true));
            file.AddButton (new MenuBarButtonWidget ("Exit", MenuBarButtonType.Action, true));

            MenuBarButtonWidget edit = new MenuBarButtonWidget ("Edit", MenuBarButtonType.Category, true);
            edit.AddButton (new MenuBarButtonWidget ("Cut", MenuBarButtonType.Action, true));
            edit.AddButton (new MenuBarButtonWidget ("Copy", MenuBarButtonType.Action, true));
            edit.AddButton (new MenuBarButtonWidget ("Paste", MenuBarButtonType.Action, false));
            edit.AddButton (new MenuBarButtonWidget ("Undo", MenuBarButtonType.Action, false));
            edit.AddButton (new MenuBarButtonWidget ("Redo", MenuBarButtonType.Action, false));

            menuBar.AddButton (file);
            menuBar.AddButton (edit);

            UI.AddWidget (menuBar);

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
        }
    }
}
