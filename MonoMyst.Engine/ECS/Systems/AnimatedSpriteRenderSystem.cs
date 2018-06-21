using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoMyst.Engine.ECS.Components;

namespace MonoMyst.Engine.ECS.Systems
{
    public class AnimatedSpriteRenderSystem : ComponentSystem
    {
        public AnimatedSpriteRenderSystem (EntityPool entities)
            : base (entities, typeof (TransformComponent),
                              typeof (AnimatedSpriteComponent))
        {
        }

        private Dictionary<Entity, AnimationData> data = new Dictionary<Entity, AnimationData> ();

        protected internal override void Update (float deltaTime)
        {
            foreach (Entity e in Entities)
            {
                AnimatedSpriteComponent sprite = e.GetComponent<AnimatedSpriteComponent> ();
                
                data.TryGetValue (e, out AnimationData animationData);

                animationData.Recalculate (sprite);

                animationData.CurrentTime += deltaTime;
                if (animationData.CurrentTime >= sprite.TimePerFrame)
                {
                    animationData.CurrentTime = 0;

                    animationData.CurrentFrame++;
                    if (animationData.CurrentFrame == animationData.MaxFrames)
                        animationData.CurrentFrame = 0;

                    int row = animationData.CurrentFrame / animationData.Columns;
                    int column = animationData.CurrentFrame % animationData.Columns;

                    animationData.SourceRectangle = new Rectangle ((int) sprite.SpriteSize.X * column, (int) sprite.SpriteSize.Y * row, (int) sprite.SpriteSize.X, (int) sprite.SpriteSize.Y);
                }
                else if (animationData.CurrentFrame == 0)
                {
                    int row = animationData.CurrentFrame / animationData.Columns;
                    int column = animationData.CurrentFrame % animationData.Columns;

                    animationData.SourceRectangle = new Rectangle((int)sprite.SpriteSize.X * column, (int)sprite.SpriteSize.Y * row, (int)sprite.SpriteSize.X, (int)sprite.SpriteSize.Y);
                }
            }
        }

        protected internal override void Draw (SpriteBatch spriteBatch)
        {
            foreach (Entity e in Entities)
            {
                TransformComponent transform = e.GetComponent<TransformComponent> ();
                AnimatedSpriteComponent sprite = e.GetComponent<AnimatedSpriteComponent> ();
                
                data.TryGetValue (e, out AnimationData animationData);

                spriteBatch.Draw
                (
                    sprite.SpriteSheet,
                    new Rectangle (transform.Position.ToPoint (), sprite.Size.ToPoint ()),
                    animationData.SourceRectangle,
                    sprite.Color,
                    transform.Rotation,
                    Vector2.Zero,
                    SpriteEffects.None,
                    1f
                );
            }
        }

        protected override void EntitiesChanged (EntityPool entities, Entity entity)
        {
            base.EntitiesChanged (entities, entity);

            if (entity.HasComponents (CompatibleTypes) && data.ContainsKey (entity) == false)
                data.Add (entity, new AnimationData ());

            if (entity.HasComponents (CompatibleTypes) == false && data.ContainsKey (entity))
                data.Remove (entity);
        }

        private class AnimationData
        {
            public int CurrentFrame;

            public float CurrentTime;

            public int MaxFrames;

            public Rectangle SourceRectangle;

            public int Rows;

            public int Columns;

            public void Recalculate (AnimatedSpriteComponent sprite)
            {
                Columns = (int) (sprite.SpriteSheet.Width / sprite.SpriteSize.X);
                Rows = (int) (sprite.SpriteSheet.Height / sprite.SpriteSize.Y);

                MaxFrames = Columns * Rows;
            }
        }
    }
}