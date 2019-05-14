using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HB.MarsRover.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace HB.MarsRover
{
    partial class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            var service = CreateAndGetService();

           
            ISpaceCenter spaceCenter = service.GetService<ISpaceCenter>();
            spaceCenter.SendCommand("5 5");
            spaceCenter.SendCommand("1 2 N");
            spaceCenter.SendCommand("LMLMLMLMM");
            spaceCenter.SendCommand("3 3 E");
            spaceCenter.SendCommand("MMRMMRMRRM");

            Console.ReadLine();

        }
        //global exception handler
        private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {

            Console.WriteLine(e.ExceptionObject.ToString());
            Console.ReadLine();

        }

        private static IServiceProvider CreateAndGetService()
        {

            return new ServiceCollection()
                 .AddSingleton<ISurface, MarsSurface>()
                 .AddSingleton<IRoverManager, RoverManager>()
                 .AddSingleton<ISpaceCenter, Houston>()
                 .BuildServiceProvider();
        }


    }
}
