using System;

using Microsoft.Xna.Framework;

namespace MonoMyst.Engine.ECS.Components
{
    public class AABBComponent : Component
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public bool DrawDebug { get; set; }
        public Color DebugColor { get; set; } = Color.Green;

        public Action<Entity, Vector2> OnCollision;
    }
}