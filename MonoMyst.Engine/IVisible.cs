namespace MonoMyst.Engine
{
    public interface IVisible
    {
        bool Visible { get; }

        void SetVisible ();
        void SetInvisible ();
    }
}
