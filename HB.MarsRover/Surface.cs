using System;

namespace HB.MarsRover
{
    public class SurfaceModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class Surface
    {

        public SurfaceModel SurfaceModel;
        public Surface(SurfaceModel surfaceModel)
        {
            if (surfaceModel.Width < 0 || surfaceModel.Height < 0)
            {
                throw new Exception("width and height can not be less than zero");
            }
            SurfaceModel = surfaceModel;
        }
    }
}
