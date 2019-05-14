using HB.MarsRover.Enums;

namespace HB.MarsRover.Managers
{
    public interface IRoverManager
    {
        void LaunchRover(int x, int y, Directions direction);
        ISurface Surface { get; }

        Rover Rover { get; }

    }
}