using MetaEditor.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaEditor.Commands.Contracts;
using Ninject;

namespace MetaEditor.Core
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel container;

        public CommandFactory(IKernel container)
        {
            this.container = container;
        }

        public ICommand CreateCommand(string commandName)
        {
            return this.container.Get<ICommand>(commandName);
        }
    }
}
