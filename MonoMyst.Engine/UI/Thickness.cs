namespace MonoMyst.Engine.UI
{
    public struct Thickness
    {
        public int Left, Top, Right, Bottom;

        public Thickness (int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public static Thickness Zero => new Thickness (0, 0, 0, 0);
    }
}
