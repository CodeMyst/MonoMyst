using System;

namespace MonoMyst.LevelEditor
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (LevelEditorGame game = new LevelEditorGame())
                game.Run();
        }
    }
}
