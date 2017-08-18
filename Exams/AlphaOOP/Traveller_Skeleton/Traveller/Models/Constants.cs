using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveller.Models
{
    public static class Constants
    {
        public const int TrainMinPassangers = 30;
        public const int TrainMaxPassangers = 150;
        public const int CartMinCount = 1;
        public const int CartMaxCount = 15;
        
        public const int BusMinPassangers = 10;
        public const int BusMaxPassangers = 50;

        public const int StartingLocationMinLength = 5;
        public const int StartingLocationMaxLength = 25;

        public const int DestinationMinLength = 5;
        public const int DestinationMaxLength = 25;

        public const int DistanceMinInterval = 5;
        public const int DistanceMaxInterval = 5000;

        
    }
}
