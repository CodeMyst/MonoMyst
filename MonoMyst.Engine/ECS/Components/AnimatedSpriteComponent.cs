using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.ECS.Components
{
    /// <summary>
    /// Holds data neccessary for an animated sprite.
    /// </summary>
    public class AnimatedSpriteComponent : IComponent
    {
        /// <summary>
        /// Full sprite sheet of all sprites used in the animation.
        /// </summary>
        public Texture2D SpriteSheet { get; set; }

        /// <summary>
        /// The size of the drawn sprite (in pixels).
        /// </summary>
        public Vector2 Size { get; set; }

        public Color Color { get; set; }

        /// <summary>
        /// Size of each sprite in the sprite sheet (in pixels).
        /// </summary>
        /// <returns></returns>
        public Vector2 SpriteSize { get; set; }

        /// <summary>
        /// The time each frame in the animation will last for (in seconds).
        /// </summary>
        public float TimePerFrame { get; set; }
    }
}