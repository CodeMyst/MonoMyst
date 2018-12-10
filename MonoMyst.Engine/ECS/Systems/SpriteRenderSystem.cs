using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.ECS.Components;

namespace MonoMyst.Engine.ECS.Systems
{
    /// <summary>
    /// Renders a sprite on entities that have <see cref="TransformComponent" /> and <see cref="SpriteComponent" />.
    /// </summary>
    public class SpriteRenderSystem : ComponentSystem
    {
        public SpriteRenderSystem (EntityPool entities)
            : base (entities, typeof (TransformComponent),
                              typeof (SpriteComponent))
        {
        }

        protected internal override void Draw (SpriteBatch spriteBatch)
        {
            foreach (Entity e in Entities)
            {
                TransformComponent transform = e.GetComponent<TransformComponent> ();
                SpriteComponent sprite = e.GetComponent<SpriteComponent> ();

                spriteBatch.Draw
                (
                    sprite.Sprite,
                    transform.Position,
                    null,
                    Color.White,
                    0f,
                    Vector2.Zero,
                    transform.Size,
                    SpriteEffects.None,
                    sprite.LayerDepth
                );
            }
        } 
    }
}