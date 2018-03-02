using Microsoft.Xna.Framework;

namespace MonoMyst.Engine.ECS
{
    public struct Transform
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;

        public Transform (Vector2 position, float rotation, Vector2 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}
