using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine;
using MonoMyst.Engine.ECS;

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

            //Entity e = Entity.CreateSceneEntity ("Test");
            //SpriteComponent sc = e.AddComponent<SpriteComponent> ();
            //sc.Sprite = Content.Load<Texture2D> ("Sprites/Rectangle");
            //sc.Size = new Point (50, 50);
            //sc.Color = Color.MonoGameOrange;
        }
    }
}
