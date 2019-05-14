namespace HB.MarsRover.Commands
{
    public abstract class CommandBase
    {
        public abstract bool IsCommandEnsure(string command);

        public abstract void Command(string command);

    }
}