using System;
using HB.MarsRover.Enums;

namespace HB.MarsRover.Managers
{
    public class RoverManager : IRoverManager
    {

        public ISurface Surface { get; }

        public Rover Rover { get; private set; }

        public RoverManager(ISurface surface)
        {
            Surface = surface;
        }

        public void LaunchRover(int x, int y, Directions direction)
        {
            if (Surface.Size == null)
            {
                throw new Exception("surface is not set up");

            }
            if (IsLocationValid(x, y))
            {
                
                Rover = new Rover(x, y, direction, Surface);
            }
            else
            {
                throw new Exception("location is not valid");
            }

        }


        private bool IsLocationValid(int x, int y)
        {
            return x >= 0 && x < Surface.Size.SurfaceModel.Width &&
                   y >= 0 && y < Surface.Size.SurfaceModel.Height;
        }
    }
}