using System;

namespace MonoMyst
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (Core game = new Core())
                game.Run();
        }
    }
}
