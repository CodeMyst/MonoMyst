using System;
using System.IO;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMyst.Engine
{
    public class XNBContentManager : ContentManager
    {
        class FakeGraphicsService : IGraphicsDeviceService
        {   
            public FakeGraphicsService(GraphicsDevice graphicDevice)
            {
                GraphicsDevice = graphicDevice;
            }

            public GraphicsDevice GraphicsDevice { get; private set; }

            public event EventHandler<EventArgs> DeviceCreated;
            public event EventHandler<EventArgs> DeviceDisposing;
            public event EventHandler<EventArgs> DeviceReset;
            public event EventHandler<EventArgs> DeviceResetting;
        }

        class FakeServiceProvider : IServiceProvider
        {
            GraphicsDevice _graphicDevice;
            public FakeServiceProvider(GraphicsDevice graphicDevice)
            {
                _graphicDevice = graphicDevice;
            }

            public object GetService(Type serviceType)
            {
                if (serviceType == typeof(IGraphicsDeviceService))
                    return new FakeGraphicsService(_graphicDevice);

                throw new NotImplementedException();
            }
        }

        private MemoryStream _xnbStream;

        public XNBContentManager(GraphicsDevice graphicDevice)
            : base(new FakeServiceProvider(graphicDevice), "Content")
        {
        }

        protected override Stream OpenStream (string assetName)
        {
            return new MemoryStream(_xnbStream.GetBuffer(), false);
        }

        public T Load<T> (string assetName, MemoryStream ms)
        {
            _xnbStream = ms;
            return base.Load<T> (assetName);
        }
    }
}