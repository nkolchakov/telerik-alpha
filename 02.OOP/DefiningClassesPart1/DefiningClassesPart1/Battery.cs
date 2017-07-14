using DefiningClassesPart1.Contracts;
using DefiningClassesPart1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPart1
{
    public class Battery : IBattery
    {
        private string model;
        private double hoursIdle;
        private double hoursTalk;
        private BatteryType batteryType;

        public Battery(string model, BatteryType type)
        {
            this.model = model;
            this.batteryType = type;
        }

        public Battery(string model, double hoursIdle, double hoursTalk, BatteryType type)
               : this(model, type)
        {
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Battery model cannot be null or empty");
                }
                this.model = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("-----Battery-------\nModel: {0}\nHours Idle: {1}\nHoursTalk: {2}\nBattery Type: {3}",
                this.model, this.hoursIdle, this.hoursTalk, this.batteryType);
            return sb.ToString();
        }
    }
}
