using System;
using System.Collections.Generic;
using System.Text;
using HB.MarsRover;
using HB.MarsRover.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace HB.MarsRoverTests
{
   public class Services
    {
        public static IServiceProvider CreateAndGetServices()
        {
            return   new ServiceCollection()
                .AddSingleton<ISurface, MarsSurface>()
                .AddSingleton<IRoverManager, RoverManager>()
                .BuildServiceProvider();
        }

         
    }
}
