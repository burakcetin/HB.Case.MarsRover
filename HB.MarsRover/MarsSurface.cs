namespace HB.MarsRover
{
    public class MarsSurface : ISurface
    {
        public Surface Size { get; private set; }
        public void SetSurface(SurfaceModel surfaceModel)
        {
            Size = new Surface(surfaceModel);
        }
    }
}