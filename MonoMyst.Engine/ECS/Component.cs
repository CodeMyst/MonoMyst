/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

namespace MonoMyst.Engine.ECS
{
    public abstract class Component
    {
        public Entity Entity { get; internal set; }
    }
}