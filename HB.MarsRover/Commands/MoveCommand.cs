using System;
using System.Text.RegularExpressions;
using HB.MarsRover.Enums;
using HB.MarsRover.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace HB.MarsRover.Commands
{
    public class MoveCommand : CommandBase
    {
        private Regex _pattern => new Regex("^[LMR]+$");
        private readonly IRoverManager _manager;

        public MoveCommand(IServiceProvider serviceProvider)
        {
            _manager = serviceProvider.GetService<IRoverManager>();

        }

        public override bool IsCommandEnsure(string command)
        {
            return _pattern.IsMatch(command);
        }

        public override void Command(string command)
        {
            if (_manager.Rover == null)
            {
                throw new Exception("first off you have to launch the rover");
            }

            foreach (var order in command)
            {
                var movement = Enum.Parse<Movements>(order.ToString());
                _manager.Rover.Move(movement);
            }

            GetLocation();
        }


        public void GetLocation()
        {
            Console.WriteLine(_manager.Rover.ToString());
        }


    }
}