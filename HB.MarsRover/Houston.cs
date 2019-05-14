using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HB.MarsRover.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace HB.MarsRover
{

    public class Houston : ISpaceCenter
    {
        private readonly IServiceProvider _service;

        public Houston(IServiceProvider service)
        {
            _service = service;
        }

        public void SendCommand(string command)
        {
            var commandManagers = GetCommandObjects().ToList();

            var commandObject = commandManagers.FirstOrDefault(x => x.IsCommandEnsure(command));
            if (commandObject == null)
                throw new Exception("command is not provided");

            commandObject.Command(command);
             

        }

       

        private IEnumerable<CommandBase> GetCommandObjects()
        {
            var types = Assembly.GetAssembly(typeof(CommandBase)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(CommandBase)));
            foreach (Type type in types)
            {
                yield return (CommandBase)Activator.CreateInstance(type, _service);
            }


        }
    }
}