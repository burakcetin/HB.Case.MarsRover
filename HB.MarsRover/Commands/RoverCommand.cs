using System;
using System.Text.RegularExpressions;
using HB.MarsRover.Enums;
using HB.MarsRover.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace HB.MarsRover.Commands
{

  
    public class RoverCommand : CommandBase
    {
        private readonly IRoverManager _manager;

        public RoverCommand(IServiceProvider serviceProvider)
        {
            _manager = serviceProvider.GetService<IRoverManager>();

        }

        private readonly Regex _pattern = new Regex("^\\d+ \\d+ [NSWE]$");

        public override bool IsCommandEnsure(string command)
        {
            return _pattern.IsMatch(command);
        }

        public override void Command(string command)
        {

            var parsedCommand = ParseCommand(command);
            _manager.LaunchRover(parsedCommand.Item1, parsedCommand.Item2, parsedCommand.Item3);
        }


        //burada tuple yerine model de kullanılabilirdi. sadece tercih.
        private Tuple<int, int, Directions> ParseCommand(string command)
        {
            var splitCommand = command.Split(' ');
            var x = int.Parse(splitCommand[0]);
            var y = int.Parse(splitCommand[1]);
            var direction = Enum.Parse<Directions>(splitCommand[2]);
            return new Tuple<int, int, Directions>(x, y, direction);
        }

    }
}
