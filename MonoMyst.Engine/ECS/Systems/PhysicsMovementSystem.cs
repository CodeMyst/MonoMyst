using System;

using Microsoft.Xna.Framework;

using MonoMyst.Engine.Extensions;
using MonoMyst.Engine.ECS.Components;

namespace MonoMyst.Engine.ECS.Systems
{
    public class PhysicsMovementSystem : ComponentSystem
    {
        public PhysicsMovementSystem (EntityPool entities)
            : base(entities, typeof (TransformComponent),
                             typeof (AABBComponent))
        {
        }

        internal protected override void Update (float dt)
        {
            base.Update (dt);

            foreach (Entity e in Entities)
            {
                PhysicsBodyComponent pbody = e.GetComponent<PhysicsBodyComponent> ();
                if (pbody == null) continue;

                TransformComponent transform = e.GetComponent<TransformComponent> ();
                AABBComponent collider = e.GetComponent<AABBComponent> ();

                if (pbody.Velocity.X != 0)
                {
                    transform.Position = new Vector2 (transform.Position.X + pbody.Velocity.X * dt, transform.Position.Y);
                    HandleHorizontalCollision (e, transform, collider, pbody);
                }

                if (pbody.Velocity.Y != 0)
                {
                    transform.Position = new Vector2 (transform.Position.X, transform.Position.Y + pbody.Velocity.Y * dt);
                    HandleVerticalCollision (e, transform, collider, pbody);
                }
            }
        }

        private void HandleHorizontalCollision (Entity e, TransformComponent t, AABBComponent c, PhysicsBodyComponent p)
        {
            foreach (Entity o in Entities)
            {
                if (e == o) continue;

                TransformComponent ot = o.GetComponent<TransformComponent> ();
                AABBComponent oc = o.GetComponent<AABBComponent> ();

                Rectangle r = new Rectangle ((int) t.Position.X + c.OffsetX, (int) t.Position.Y + c.OffsetY, c.Width, c.Height);
                Rectangle or = new Rectangle ((int) ot.Position.X + oc.OffsetX, (int) ot.Position.Y + oc.OffsetY, oc.Width, oc.Height);

                if (r.Intersects (or))
                {
                    float d = r.GetIntersectionDepth (or).X * -1;

                    t.Position = new Vector2 ((float) Math.Floor (t.Position.X - d), t.Position.Y);
                }
            }
        }

        private void HandleVerticalCollision (Entity e, TransformComponent t, AABBComponent c, PhysicsBodyComponent p)
        {
            foreach (Entity o in Entities)
            {
                if (e == o) continue;

                TransformComponent ot = o.GetComponent<TransformComponent> ();
                AABBComponent oc = o.GetComponent<AABBComponent> ();

                Rectangle r = new Rectangle ((int) t.Position.X + c.OffsetX, (int) t.Position.Y + c.OffsetY, c.Width, c.Height);
                Rectangle or = new Rectangle ((int) ot.Position.X + oc.OffsetX, (int) ot.Position.Y + oc.OffsetY, oc.Width, oc.Height);

                if (r.Intersects (or))
                {
                    float d = r.GetIntersectionDepth (or).Y * -1;

                    t.Position = new Vector2 (t.Position.X, (float) Math.Floor (t.Position.Y - d));
                }
            }
        }
    }
}