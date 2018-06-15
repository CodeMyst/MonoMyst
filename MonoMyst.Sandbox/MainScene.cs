using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine;
using MonoMyst.Engine.UI;
using MonoMyst.Engine.ECS;
using MonoMyst.Engine.UI.Widgets;
using MonoMyst.Engine.ECS.Systems;
using MonoMyst.Engine.ECS.Components;

namespace MonoMyst.Sandbox
{
    public class MainScene : Scene
    {
        protected override void Initialize ()
        {
            base.Initialize ();

            SpriteRenderSystem spriteRenderSystem = new SpriteRenderSystem (Entities);
            
            Entity dino = new Entity ("Dino");

            TransformComponent transform = dino.AddComponent<TransformComponent> ();
            transform.Position = new Vector2 (100, 400);

            SpriteComponent sprite = dino.AddComponent<SpriteComponent> ();
            sprite.Sprite = Game1.GraphicUtilities.Rectangle;
            sprite.Color = MColors.Mystge;
            sprite.Size = new Vector2 (50, 50);
        
            Canvas canvas = new Canvas ();

            TextBlock text = new TextBlock
            {
                Text = "Text",
                Color = Color.White
            };

            canvas.AddChild (text);

            UI.AddCanvas (canvas);
        }
    }
}