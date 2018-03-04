namespace MonoMyst.Engine.UI
{
    public struct Thickness
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public Thickness (int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}
