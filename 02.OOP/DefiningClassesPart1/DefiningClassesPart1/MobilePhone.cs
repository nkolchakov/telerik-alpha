using DefiningClassesPart1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPart1
{
    public class MobilePhone
    {
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private IBattery battery;
        private IDisplay display;

        private List<ICall> calls;

        private static MobilePhone iPhone4S = new MobilePhone("4S", "Apple");

        public MobilePhone(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.battery = null;
            this.display = null;

            this.calls = new List<ICall>();
        }

        public MobilePhone(string model, string manufacturer, decimal price, string owner, IBattery battery, IDisplay display)
            : this(model, manufacturer)
        {
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
        }

        public void MakeCall(ICall call)
        {
            this.calls.Add(call);
        }

        public void DeleteCall(ICall call)
        {
            this.calls.Remove(call);
        }

        public void ClearHistory()
        {
            this.calls.Clear();
        }

        public decimal TotalPrice(decimal pricePerMinute)
        {
            double total = 0;
            foreach (Call call in this.calls)
            {
                total += call.Duration;
            }
            return (decimal)total / 60 * pricePerMinute;
        }

        public IEnumerable<ICall> CallHistory
        {
            get
            {
                return this.calls;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Model: {0}\nManufacturer: {1}\nPrice: {2}\nOwner: {3}\nBattery: {4}\nDisplay: {5}\n-----------\n",
                this.model, this.manufacturer, this.price, this.owner, this.battery, this.display);
            return sb.ToString();
        }

        public static MobilePhone IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }
    }
}
