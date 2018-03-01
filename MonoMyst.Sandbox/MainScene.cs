using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Core;
using MonoMyst.Core.ECS;

using MonoMyst.Engine.UI;
using MonoMyst.Engine.Components;

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

            SpriteFont font = Content.Load<SpriteFont> ("Fonts/Montserrat/Montserrat-Regular");

            Entity entity1 = Entity.CreateSceneEntity ("Entity 1");
            Entity entity11 = Entity.CreateSceneEntity ("Entity 11");
            Entity entity12 = Entity.CreateSceneEntity ("Entity 12");
            Entity entity13 = Entity.CreateSceneEntity ("Entity 13");
            Entity entity14 = Entity.CreateSceneEntity ("Entity 14");
            Entity entity15 = Entity.CreateSceneEntity ("Entity 15");
            Entity entity16 = Entity.CreateSceneEntity ("Entity 16");
            entity11.SetParent (entity1);
            entity12.SetParent (entity1);
            entity13.SetParent (entity1);
            entity14.SetParent (entity1);
            entity15.SetParent (entity1);
            entity16.SetParent (entity1);

            Entity entity111 = Entity.CreateSceneEntity ("Entity 111");
            entity111.SetParent (entity11);

            entity1.AddComponent<SpriteComponent> ();
            TextComponent tc = entity1.AddComponent<TextComponent> ();
            tc.Color = Color.White;
            tc.Font = font;
            tc.Text = Entity.GetHierarchy (entity1, "", true);

            Console.WriteLine (Entity.GetHierarchy (entity1, "", true));
        }
    }
}
