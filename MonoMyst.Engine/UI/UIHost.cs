using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.UI
{
    public class UIHost : MonoMystObject
    {
        protected Game Game;

        protected ContentManager Content;

        private List<Canvas> canvasses = new List<Canvas> ();

        public UIHost (Game game)
        {
            Game = game;

            Content = new ContentManager (Game.Services)
            {
                RootDirectory = "Content"
            };
        }

        public void AddCanvas (Canvas canvas)
        {
            canvasses.Add (canvas);
            canvas.Initialize ();
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            foreach (Canvas c in canvasses)
                c.Draw (spriteBatch);
        }

        public override void Update (float deltaTime)
        {
            foreach (Canvas c in canvasses)
                c.Update (deltaTime);
        }
    }
}
