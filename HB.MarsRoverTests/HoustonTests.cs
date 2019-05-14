using System;
using HB.MarsRover;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using HB.MarsRover.Enums;
using HB.MarsRover.Managers;

namespace HB.MarsRoverTests
{
    public class HoustonTests
    {
        [Theory]
        [InlineData("5 5")]
        [InlineData("2 2")]
        [InlineData("1 1")]
        public void CreatePlatue(string command)
        {
            // Arrange
            var serviceProvider = Services.CreateAndGetServices();
            var commands = command.Split(' ');
            var width = int.Parse(commands[0]);
            var height = int.Parse(commands[1]);

            ISpaceCenter houston = new Houston(serviceProvider);
            var plateue = serviceProvider.GetService<ISurface>();


            houston.SendCommand(command);


            plateue.Should().NotBeNull();
            plateue.Size.Should().NotBeNull();
            plateue.Size.SurfaceModel.Width.Should().Be(width);
            plateue.Size.SurfaceModel.Height.Should().Be(height);
        }

        [Theory]
        [InlineData("1 1", "5 1 N")]

        public void LocationBoundThrowException(string plataeuCommand, string command)
        {
           
            var serviceProvider = Services.CreateAndGetServices();

            var houston = new Houston(serviceProvider);
            houston.SendCommand(plataeuCommand);

             var action = new Action(() => houston.SendCommand(command));

             
            action.Should().Throw<Exception>().WithMessage("location is not valid");
        }
        [Theory]
        [InlineData("Z Z")]
        public void WrongCommandThrowException(string command)
        {
            var serviceProvider = Services.CreateAndGetServices();

            var houston = new Houston(serviceProvider);

            var action = new Action(() => houston.SendCommand(command));

            action.Should().Throw<Exception>().WithMessage("command is not provided");
        }

        [Theory]
        [InlineData("5 1 N")]
        public void MustSetUpSurfaceThrowException(string command)
        {
            var serviceProvider = Services.CreateAndGetServices();

            var houston = new Houston(serviceProvider);

            var action = new Action(() => houston.SendCommand(command));

            action.Should().Throw<Exception>().WithMessage("surface is not set up");
        }

        [Theory]
        [InlineData("MRMRMRMR")]
        [InlineData("MLMLMLML")]
        public void ACircleReturnsToInitialPosition(string command)
        {
            // Arrange
            var serviceProvider = Services.CreateAndGetServices();

            var houston = new Houston(serviceProvider);
            houston.SendCommand("2 2");
            houston.SendCommand("1 1 W");
            var rover = serviceProvider.GetService<IRoverManager>().Rover;

            // Act
            houston.SendCommand(command);

            // Assert
            rover.Should().NotBeNull();
            rover.X.Should().Be(1);
            rover.Y.Should().Be(1);
            rover.Direction.Should().Be(Directions.W);
        }
    }
}
