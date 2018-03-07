using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.Graphics
{
    public class GraphicUtilities
    {
        public static Texture2D Rectangle => MonoMystGame.MMContent.Load<Texture2D> ("Rectangle");
    }
}
