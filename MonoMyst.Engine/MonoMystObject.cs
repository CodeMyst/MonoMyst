using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine
{
    public abstract class MonoMystObject : IInitializable, IUpdateable, IDrawable, IVisible
    {
        public bool Visible { get; protected set; } = true;

        public virtual void Initialize () { }

        public virtual void Update (float deltaTime) { }

        public virtual void Draw (SpriteBatch spriteBatch) { }

        public virtual void SetVisible ()
        {
            Visible = true;
        }

        public virtual void SetInvisible ()
        {
            Visible = false;
        }
    }
}
