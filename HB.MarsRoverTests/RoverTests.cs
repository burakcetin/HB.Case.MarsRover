using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using HB.MarsRover;
using HB.MarsRover.Enums;
using Xunit;
using System.Linq;
using HB.MarsRover.Managers;

namespace HB.MarsRoverTests
{
    public class RoverTests
    {
        [Theory]
        [InlineData("LMLMLMLMM")]

        public void HBRequired(string command)
        {
            var plataue = new MarsSurface();
            plataue.SetSurface(new SurfaceModel() { Width = 5, Height = 5 });
            var manager = new RoverManager(plataue);
            manager.LaunchRover(1, 2, Directions.N);
            var movements = command
                .ToCharArray()
                .Select(x => Enum.Parse<Movements>(x.ToString()))
                .ToList();


            movements.ForEach(manager.Rover.Move);

            manager.Rover.Should().NotBeNull();
            manager.Rover.X.Should().Be(1);
            manager.Rover.Y.Should().Be(3);
            manager.Rover.Direction.Should().Be(Directions.N);

        }

        [Theory]
        [InlineData("MMRMMRMRRM")]
        public void HBRequired2(string command)
        {
            var plataue = new MarsSurface();
            plataue.SetSurface(new SurfaceModel() { Width = 5, Height = 5 });
            var manager = new RoverManager(plataue);
            manager.LaunchRover(3, 3, Directions.E);
            var movements = command
                .ToCharArray()
                .Select(x => Enum.Parse<Movements>(x.ToString()))
                .ToList();


            movements.ForEach(manager.Rover.Move);

            manager.Rover.Should().NotBeNull();
            manager.Rover.X.Should().Be(5);
            manager.Rover.Y.Should().Be(1);
            manager.Rover.Direction.Should().Be(Directions.E);

        }
    }
}