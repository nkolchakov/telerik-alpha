using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Enums;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Vehicles
{
    public class Airplane : Vehicle, IAirplane
    {
        public Airplane(int passangerCapacity, decimal pricePerKilometer, bool hasFreeFood)
            : base(passangerCapacity, pricePerKilometer)
        {
            this.HasFreeFood = hasFreeFood;
        }

        public bool HasFreeFood { get; protected set; }

        public override VehicleType Type
        {
            get
            {
                return VehicleType.Air;
            }
        }

        protected override string VehicleName
        {
            get
            {
                return "Airplane";
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Has free food: {this.HasFreeFood}".TrimEnd();
        }
    }
}
