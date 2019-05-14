namespace HB.MarsRover
{
    public interface ISurface
    {
        Surface Size { get; }

        void SetSurface(SurfaceModel surfaceModel);
    }
}