using Bytes2you.Validation;
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
        private readonly IDatabase database;

        public ListingCommand(IDatabase database)
        {
            Guard.WhenArgument(database, "database");

            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            if (this.Collection.Count == 0)
            {
                return this.EmptyCollectionMessage;
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, this.Collection);
        }

        protected abstract IList<T> Collection { get; }
        protected abstract string EmptyCollectionMessage { get; }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }
    }
}