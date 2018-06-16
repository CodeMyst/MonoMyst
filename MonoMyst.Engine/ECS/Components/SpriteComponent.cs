using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.ECS.Components
{
    /// <summary>
    /// Holds data necessary for rendering a sprite.
    /// </summary>
    public class SpriteComponent : IComponent
    {
        public Texture2D Sprite { get; set; }
        public Vector2 Size { get; set; }
        public Color Color { get; set; }
    }
}