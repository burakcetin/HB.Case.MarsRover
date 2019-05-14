using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;

namespace HB.MarsRover.Commands
{
    public class PlataueCommand : CommandBase
    {
        private readonly ISurface _surface;
        public PlataueCommand(IServiceProvider serviceProvider)
        {
            _surface = serviceProvider.GetService<ISurface>();
        }

        private readonly Regex _pattern = new Regex("^\\d+ \\d+$");
        public override bool IsCommandEnsure(string command)
        {
            return _pattern.IsMatch(command);
        }

        public override void Command(string command)
        {
            var surfaceModel = ParseCommand(command);
            _surface.SetSurface(surfaceModel);
        }

        private SurfaceModel ParseCommand(string command)
        {
            var splitCommand = command.Split(' ');
            var width = int.Parse(splitCommand[0]);
            var height = int.Parse(splitCommand[1]);
            return new SurfaceModel()
            {
                Height = height,
                Width = width
            };
        }

    }
}
