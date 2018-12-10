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
        Entity dino;

        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public MainScene (MGame game) : base (game) { }

        protected override void Initialize ()
        {
            base.Initialize ();

            SpriteRenderSystem spriteRenderSystem = new SpriteRenderSystem (Entities);
            
            dino = new Entity ("Dino");

            TransformComponent transform = dino.AddComponent<TransformComponent> ();
            transform.Position = new Vector2 (100, 400);

            SpriteComponent sprite = dino.AddComponent<SpriteComponent> ();
            sprite.Sprite = Game1.GraphicUtilities.Rectangle;
            sprite.Color = MColors.Mystge;

            Canvas canvas = new Canvas ();

            TextBlock text = new TextBlock
            {
                Text = "Text",
                Color = Color.White,
                TextHorizontalAlignment = TextHorizontalAlignment.Center,
                TextVerticalAlignment = TextVerticalAlignment.Center
            };

            canvas.AddChild (text);

            UI.AddCanvas (canvas);
        }

        protected override void Update (float deltaTime)
        {
            currentKeyboardState = Keyboard.GetState ();

            if (currentKeyboardState.IsKeyDown (Keys.Space) && !previousKeyboardState.IsKeyDown (Keys.Space))
            {
                foreach (SpriteComponent c in dino.GetComponents<SpriteComponent> ())
                {
                    System.Console.WriteLine(c.Color);
                }
            }

            previousKeyboardState = currentKeyboardState;
        }
    }
}