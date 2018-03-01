using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Core;
using MonoMyst.Core.ECS;

using MonoMyst.Engine.UI;

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
            string text = "This is a test text component";

            Entity button = Entity.CreateSceneEntity ("TextTest");
            button.Position = new Vector2 (10, 10);

            ButtonComponent buttonComponent = button.AddComponent<ButtonComponent> ();
            buttonComponent.Sprite = Content.Load<Texture2D> ("Sprites/Rectangle");
            buttonComponent.Size = new Point ((int) font.MeasureString (text).X, (int) font.MeasureString (text).Y);
            buttonComponent.Color = Color.DarkOrange;

            TextComponent textComponent = button.AddComponent<TextComponent> ();
            textComponent.Text = text;
            textComponent.Font = font;

            int count = 0;

            buttonComponent.OnPressed += () =>
            {
                count++;
                text = count.ToString ();
                buttonComponent.Size = new Point ((int) font.MeasureString (text).X, (int) font.MeasureString (text).Y);
                textComponent.Text = text;

                Console.WriteLine (button.GetComponent<ButtonComponent> ().Color);
            };
        }
    }
}
