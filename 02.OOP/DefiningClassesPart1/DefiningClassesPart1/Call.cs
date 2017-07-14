using DefiningClassesPart1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPart1
{
    public class Call : ICall
    {
        private DateTime date;
        private double time;
        private string dialedPhone;
        private uint duration;

        public Call(DateTime date, double time, string dialedPhone, uint duration)
        {
            this.Date = date;
            this.Time = time;
            this.DialedPhone = dialedPhone;
            this.Duration = duration;
        }
        public string DialedPhone
        {
            get
            {
                return this.dialedPhone;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Dialed phone cannot be null or empty");
                }
                this.dialedPhone = value;
            }
        }
        public uint Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                this.duration = value;
            }
        }

        public double Time
        {
            get
            {
                return this.time;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Call time cannot be negative");
                }
                this.time = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value == default(DateTime))
                {
                    throw new ArgumentException("DateTime cannot be null");
                }
                this.date = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ----- Call detail ------");
            sb.AppendFormat("Date: {0}\nDialed phone: {1}\nDuration: {2}\n", this.Date, this.DialedPhone, this.Duration);
            sb.AppendLine("--------------");

            return sb.ToString();
        }
    }
}
