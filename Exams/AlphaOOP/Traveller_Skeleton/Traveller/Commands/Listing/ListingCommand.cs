using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Listing
{
    public abstract class ListingCommand<T> : ICommand
    {
        protected readonly ITravellerFactory factory;
        protected readonly IEngine engine;

        public ListingCommand(ITravellerFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        protected abstract ICollection<T> Items { get;  }

        protected abstract string CustomErrorMessage { get; }

        public string Execute(IList<string> parameters)
        {
            var items = this.Items;

            if (items.Count == 0)
            {
                return this.CustomErrorMessage;
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, items);
        }
    }
}
