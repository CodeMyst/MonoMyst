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

            Canvas mainCanvas = new Canvas ();

            PanelWidget panel = new PanelWidget ()
            {
                Scale = new Vector2 (500, 100),
                VerticalAlignment = VerticalAlignment.Stretch
            };

            mainCanvas.AddWidget (panel);

            UI.AddCanvas (mainCanvas);

            //MenuBarWidget menuBar = new MenuBarWidget ();

            //MenuBarButtonWidget file = new MenuBarButtonWidget ("File", MenuBarButtonType.Category, true);
            //MenuBarButtonWidget newLevelButton = new MenuBarButtonWidget ("New", MenuBarButtonType.Action, true);
            //file.AddButton (newLevelButton);
            //file.AddButton (new MenuBarButtonWidget ("Save", MenuBarButtonType.Action, false));
            //file.AddButton (new MenuBarButtonWidget ("Load", MenuBarButtonType.Action, true));
            //MenuBarButtonWidget exitButton = new MenuBarButtonWidget ("Exit", MenuBarButtonType.Action, true);
            //exitButton.OnClicked += Game.Exit;
            //file.AddButton (exitButton);

            //MenuBarButtonWidget edit = new MenuBarButtonWidget ("Edit", MenuBarButtonType.Category, true);
            //edit.AddButton (new MenuBarButtonWidget ("Cut", MenuBarButtonType.Action, true));
            //edit.AddButton (new MenuBarButtonWidget ("Copy", MenuBarButtonType.Action, true));
            //edit.AddButton (new MenuBarButtonWidget ("Paste", MenuBarButtonType.Action, false));
            //edit.AddButton (new MenuBarButtonWidget ("Undo", MenuBarButtonType.Action, false));
            //edit.AddButton (new MenuBarButtonWidget ("Redo", MenuBarButtonType.Action, false));

            //menuBar.AddButton (file);
            //menuBar.AddButton (edit);
            //UI.AddWidget (menuBar);

            //ContentDialogWidget newLevelDialog = new ContentDialogWidget ()
            //{
            //    Title = "New Level",
            //    ActionButtonText = "Create"
            //};
            //newLevelButton.OnClicked += () => newLevelDialog.Show ();
            //TextBlockWidget test = new TextBlockWidget ("This is a simple dialog showing some sample text.")
            //{
            //    FontSize = 0.75f
            //};
            //test.VerticalAlignment = Engine.UI.VerticalAlignment.Bottom;
            //test.HorizontalAlignment = Engine.UI.HorizontalAlignment.Left;
            //newLevelDialog.AddWidgetToContent (test);

            //UI.AddWidget (newLevelDialog);
        }
    }
}
