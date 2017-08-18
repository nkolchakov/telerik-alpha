using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Enums;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Vehicles
{
    public class Train : Vehicle, ITrain
    {
        private int passangerCapacity;
        private int carts;

        public Train(int passangerCapacity, decimal pricePerKilometer, int carts)
            : base(passangerCapacity, pricePerKilometer)
        {
            this.Carts = carts;
        }

        public override int PassangerCapacity
        {
            get
            {
                return this.passangerCapacity;
            }
            protected set
            {
                if (value < Constants.TrainMinPassangers || value > Constants.TrainMaxPassangers)
                {
                    throw new ArgumentOutOfRangeException($"A train cannot have less than {Constants.TrainMinPassangers} passengers or more than {Constants.TrainMaxPassangers} passengers.");
                }
                this.passangerCapacity = value;
            }
        }

        public override VehicleType Type
        {
            get
            {
                return VehicleType.Land;
            }
        }

        public int Carts
        {
            get
            {
                return this.carts;
            }
            protected set
            {
                if (value < Constants.CartMinCount || value > Constants.CartMaxCount)
                {
                    throw new ArgumentOutOfRangeException($"A train cannot have less than {Constants.CartMinCount} cart or more than {Constants.CartMaxCount} carts.");
                }
                this.carts = value;
            }
        }

        protected override string VehicleName
        {
            get
            {
                return "Train";
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Carts amount: {this.Carts}");

            return sb.ToString().TrimEnd();
        }
    }
}
