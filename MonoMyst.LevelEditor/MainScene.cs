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

            ButtonWidget button = new ButtonWidget ("Test Button")
            {
                VerticalAlignment = Engine.UI.VerticalAlignment.Center,
                HorizontalAlignment = Engine.UI.HorizontalAlignment.Center,
                Size = new Vector2 (100, 50),
                Padding = new Engine.UI.Thickness (20, 10, 20, 10)
            };

            UI.AddWidget (button);
        }
    }
}
