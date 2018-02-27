using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Core
{
    public class Camera
    {
        public static Camera Main { get; private set; }

        private GraphicsDevice graphicsDevice;

        public Vector2 Position;

        private Matrix _transform;
        public Matrix Transform
        {
            get
            {
                _transform = Matrix.CreateTranslation (new Vector3 (-Position.X, -Position.Y, 0));
                return _transform;
            }
        }

        public Camera (GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            Main = this;
        }

        public Point WorldToScreen (Point worldCoords)
        {
            return new Point (worldCoords.X - (int) Position.X, worldCoords.Y - (int) Position.Y);
        }

        public Point ScreenToWorld (Point screenCords)
        {
            return new Point ((int) Position.X + screenCords.X, (int) Position.Y + screenCords.Y);

        }
    }
}
