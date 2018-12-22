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
        public MainScene (MGame game) : base (game) { }

        protected override void Initialize ()
        {
            base.Initialize ();

            Entity e = Premade.Create ("Content/Test.mpm");
        }
    }
}