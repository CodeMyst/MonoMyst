using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine
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

        /// <summary>
        /// Converts a position in world coordinates to a position in screen coordinates.
        /// </summary>
        public Point WorldToScreen (Point worldCoords)
        {
            return new Point (worldCoords.X - (int) Position.X, worldCoords.Y - (int) Position.Y);
        }

        /// <summary>
        /// Converts a position in screen coordinates to a position in world coordinates.
        /// </summary>
        public Point ScreenToWorld (Point screenCords)
        {
            return new Point ((int) Position.X + screenCords.X, (int) Position.Y + screenCords.Y);
        }
    }
}
