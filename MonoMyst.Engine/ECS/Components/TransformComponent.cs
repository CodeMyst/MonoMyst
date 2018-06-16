using Microsoft.Xna.Framework;

namespace MonoMyst.Engine.ECS.Components
{
    /// <summary>
    /// Holds position, size and rotation.
    /// </summary>
    public class TransformComponent : IComponent
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public float Rotation { get; set; }
    }
}