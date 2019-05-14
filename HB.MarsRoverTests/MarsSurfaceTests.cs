using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using HB.MarsRover;
using Xunit;

namespace HB.MarsRoverTests
{
    public class MarsSurfaceTests
    {
        [Theory]
        [InlineData("50 50")]
        [InlineData("3 16")]
        [InlineData("5 10")]
        public void CreateSurfaceCorrectSize(string command)
        {
            ISurface landingSurface = new MarsSurface();

            var commandSplit = command.Split(' ');
            var width = int.Parse(commandSplit[0]);
            var height = int.Parse(commandSplit[1]);


            landingSurface.SetSurface(new SurfaceModel()
            {
                Width = width,
                Height = height
            });


            landingSurface.Size.SurfaceModel.Width.Should().Be(width);
            landingSurface.Size.SurfaceModel.Height.Should().Be(height);
        }



        [Theory]
        [InlineData("-1 -1")]
        [InlineData("1 -1")]
        [InlineData("-1 1")]
        public void WidthOrHeightCanNotBeLessZeroThrowException(string command)
        {
            ISurface landingSurface = new MarsSurface();

            var commandSplit = command.Split(' ');
            var width = int.Parse(commandSplit[0]);
            var height = int.Parse(commandSplit[1]);

            var action = new Action(() => landingSurface.SetSurface(new SurfaceModel()
            {
                Width = width,
                Height = height
            }));
            action.Should().Throw<Exception>().WithMessage("width and height can not be less than zero");


        }
    }
}
