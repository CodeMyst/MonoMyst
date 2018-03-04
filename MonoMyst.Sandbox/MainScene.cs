using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine;
using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;
using MonoMyst.Engine.ECS.Components;

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

            Grid grid = new Grid
            {
                DebugDraw = true,
                Padding = new Thickness (20, 20, 20, 20)
            };

            TextBlock t1 = new TextBlock ("TextBlock", 1f, Color.White, Content.Load<SpriteFont> ("Fonts/Montserrat/Montserrat-Regular"));
            grid.Widgets.Add (t1);

            TextBlock t2 = new TextBlock ("TextBlock", 1f, Color.White, Content.Load<SpriteFont> ("Fonts/Montserrat/Montserrat-Regular"));
            t1.Padding = new Thickness (20, 20, 20, 20);
            grid.Widgets.Add (t2);

            UI.AddWidget (grid);

            //Entity e = Entity.CreateSceneEntity ("Test");
            //SpriteComponent sc = e.AddComponent<SpriteComponent> ();
            //sc.Sprite = Content.Load<Texture2D> ("Sprites/Rectangle");
            //sc.Size = new Point (50, 50);
            //sc.Color = Color.MonoGameOrange;
        }
    }
}
