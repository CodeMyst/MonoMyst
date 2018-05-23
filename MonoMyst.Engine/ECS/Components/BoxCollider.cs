using Microsoft.Xna.Framework;

namespace MonoMyst.Engine.ECS.Components
{
    /// <summary>
    /// Collider that represents an axis-aligned rectangle.
    /// </summary>
    public class BoxCollider : Component
    {
        public Rectangle Rectangle { get; set; }
    }
}