using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Commands.Creating
{
    public abstract class CreateVehicleCommand : ICommand
    {
        protected readonly ITravellerFactory factory;
        protected readonly IEngine engine;

        public CreateVehicleCommand(ITravellerFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        protected abstract IVehicle CreateVehicle(IList<string> parameters);

        public string Execute(IList<string> parameters)
        {
            IVehicle vehicle = this.CreateVehicle(parameters);

            this.engine.Vehicles.Add(vehicle);
            
            return $"Vehicle with ID {engine.Vehicles.Count - 1} was created.";
    
        }
    }
}