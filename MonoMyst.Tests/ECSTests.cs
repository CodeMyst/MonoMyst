using Microsoft.Xna.Framework;

using Xunit;

using MonoMyst.Engine;
using MonoMyst.Engine.ECS;
using MonoMyst.Engine.ECS.Components;

namespace MonoMyst.Tests
{
    public class ECSTests
    {
        private MonoMystGame _game;

        public ECSTests ()
        {
            _game = new MonoMystGame ();
        }

        [Fact]
        public void GetComponentTest1 ()
        {
            Scene scene = new Scene (_game, _game.GraphicsDevice);

            Entity entity = Entity.CreateSceneEntity ("test", scene);
            entity.AddComponent<SpriteComponent> ();

            Component c = entity.GetComponent<SpriteComponent> ();

            Assert.NotNull (c);
        }
    }
}