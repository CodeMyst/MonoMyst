using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.ECS;
using MonoMyst.Engine.Extensions;
using MonoMyst.Engine.ECS.Components;

namespace MonoMyst.Engine.ECS.Systems
{
    public class AABBSystem : ComponentSystem
    {
        public AABBSystem (EntityPool entities)
            : base (entities, typeof (TransformComponent),
                              typeof (AABBComponent))
        {
        }

        internal protected override void Draw (SpriteBatch spriteBatch)
        {
            foreach (Entity e in Entities)
            {
                AABBComponent aabb = e.GetComponent<AABBComponent> ();
                if (!aabb.DrawDebug) continue;
                TransformComponent transform = e.GetComponent<TransformComponent> ();

                spriteBatch.Draw
                (
                    MGame.GraphicUtilities.Rectangle,
                    new Rectangle ((int) transform.Position.X + aabb.OffsetX, (int) transform.Position.Y + aabb.OffsetY, 1, aabb.Height),
                    null,
                    aabb.DebugColor,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    0.011f
                );

                spriteBatch.Draw
                (
                    MGame.GraphicUtilities.Rectangle,
                    new Rectangle ((int) transform.Position.X + aabb.OffsetX, (int) transform.Position.Y + aabb.OffsetY, aabb.Width, 1),
                    null,
                    aabb.DebugColor,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    0.011f
                );

                spriteBatch.Draw
                (
                    MGame.GraphicUtilities.Rectangle,
                    new Rectangle ((int) transform.Position.X + aabb.Width + aabb.OffsetX, (int) transform.Position.Y + aabb.OffsetY, 1, aabb.Height),
                    null,
                    aabb.DebugColor,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    0.011f
                );

                spriteBatch.Draw
                (
                    MGame.GraphicUtilities.Rectangle,
                    new Rectangle ((int) transform.Position.X + aabb.OffsetX, (int) transform.Position.Y + aabb.Height + aabb.OffsetY, aabb.Width, 1),
                    null,
                    aabb.DebugColor,
                    0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    0.011f
                );
            }
        }
    }
}