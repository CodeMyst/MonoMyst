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
                    transform.Position.X += pbody.Velocity.X * dt;
                    HandleHorizontalCollision (e, transform, collider, pbody);
                }

                if (pbody.Velocity.Y != 0)
                {
                    transform.Position.Y += pbody.Velocity.Y * dt;
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

                    t.Position.X = (float) Math.Round (t.Position.X - d);
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

                    t.Position.Y = (float) Math.Round (t.Position.Y - d);

                    if (Math.Sign (d) >= 0) p.Grounded = true;
                    else p.Grounded = false;
                }
            }
        }
    }
}