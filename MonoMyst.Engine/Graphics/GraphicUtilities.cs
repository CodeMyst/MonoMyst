using System.IO;
using System.Reflection;

using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine.Graphics
{
    public class GraphicUtilities
    {
        public Texture2D Rectangle { get; private set; }
        public SpriteFont NotoSansRegular { get; private set; }

        public GraphicUtilities ()
        {
            Rectangle = LoadFromStream<Texture2D> ("MonoMyst.Engine.Content.Rectangle.xnb", "Rectangle.xnb");
            NotoSansRegular = LoadFromStream<SpriteFont> ("MonoMyst.Engine.Content.NotoSansRegular.xnb", "NotoSansRegular.xnb");
        }

        private T LoadFromStream<T> (string streamName, string assetName)
        {
            T result = default (T);

            Assembly assembly = typeof (MonoMystGame).GetTypeInfo ().Assembly;

            Stream stream = assembly.GetManifestResourceStream (streamName);
            using (MemoryStream ms = new MemoryStream ())
            {
                byte [] buffer = new byte [16*1024];
                int read;
                while ((read = stream.Read (buffer, 0, buffer.Length)) > 0)
                    ms.Write (buffer, 0, read);

                result = MonoMystGame.EmbeddedContent.Load<T> (assetName, ms);
            }

            return result;
        }
    }
}
