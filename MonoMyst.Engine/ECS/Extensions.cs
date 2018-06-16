/*
    The ECS in MonoMyst heavily takes on from SharpECS project by Anthony Lewis Baynham https://github.com/anthony-y/sharp-ecs/
 */

using System;

namespace MonoMyst.Engine.ECS
{
    public static class Extensions
    {
        /// <summary>
        /// Checks if a type is assignable from <see cref="IComponent" />
        /// </summary>
        public static bool IsComponent (this Type type) => typeof (IComponent).IsAssignableFrom (type);
    }
}