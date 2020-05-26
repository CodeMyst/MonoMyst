using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.ECS.Components
{
    /// <summary>
    /// Holds data necessary for rendering a sprite.
    /// </summary>
    public class SpriteComponent : Component
    {
        public Texture2D Sprite { get; set; }
        public Color Color { get; set; } = Color.White;
        public float LayerDepth { get; set; }
    }
}