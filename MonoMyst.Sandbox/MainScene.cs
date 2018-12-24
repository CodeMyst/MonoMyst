using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine;
using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;
using MonoMyst.Engine.UI.Widgets;
using MonoMyst.Engine.ECS.Systems;
using MonoMyst.Engine.ECS.Components;

using Microsoft.Xna.Framework.Input;

namespace MonoMyst.Sandbox
{
    public class MainScene : Scene
    {
        private Entity e;

        public MainScene (MGame game) : base (game) { }

        protected override void Initialize ()
        {
            base.Initialize ();

            new SpriteRenderSystem (Entities);
            new AABBSystem (Entities);
            new PhysicsMovementSystem (Entities);

            e = Premade.Create ("Content/Test.mpm");
            Entity e2 = Premade.Create ("Content/Test.mpm");
            e2.GetComponent<TransformComponent> ().Position = new Vector2 (50, 300);

            Premade.Create ("Content/Test.mpm").GetComponent<TransformComponent> ().Position = new Vector2 (80, 300);
            Premade.Create ("Content/Test.mpm").GetComponent<TransformComponent> ().Position = new Vector2 (141, 300);
            Premade.Create ("Content/Test.mpm").GetComponent<TransformComponent> ().Position = new Vector2 (170, 250);

            e.AddComponent<PhysicsBodyComponent> ();
        }

        protected override void Update (float dt)
        {
            base.Update (dt);

            PhysicsBodyComponent p = e.GetComponent<PhysicsBodyComponent> ();
            AABBComponent c = e.GetComponent<AABBComponent> ();
            
            if (Input.IsKeyHeld (Keys.D))
                p.Velocity.X = 100;
            else if (Input.IsKeyHeld (Keys.A))
                p.Velocity.X = -100;
            else
                p.Velocity.X = 0;

            if (Input.IsKeyHeld (Keys.S))
                p.Velocity.Y = 100;
            else if (Input.IsKeyHeld (Keys.W))
                p.Velocity.Y = -100;
            else
                p.Velocity.Y = 0;
        }
    }
}