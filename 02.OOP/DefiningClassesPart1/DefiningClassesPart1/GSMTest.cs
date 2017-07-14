using DefiningClassesPart1.Contracts;
using DefiningClassesPart1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPart1
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            Battery samsungsBattery = new Battery("bateria", BatteryType.NiCd);
            Display samsubgsDisp = new Display(8);

            var samsungPhone = new MobilePhone("Galaxy", "Samsung", 500, "Me", samsungsBattery, samsubgsDisp);

            MobilePhone[] phones =
            {
                new MobilePhone("P8", "Huawei"),
                samsungPhone,
                MobilePhone.IPhone4S
            };

            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }

            Call callOne = new Call(DateTime.Now, 3, "123", 120);
            Call callTwo = new Call(DateTime.Now, 123, "345", 60);
            Call callThree = new Call(DateTime.Now, 555, "89334", 23);

            samsungPhone.MakeCall(callOne);
            samsungPhone.MakeCall(callTwo);
            samsungPhone.MakeCall(callThree);

            Console.WriteLine("--------- Calls details ----------");
            foreach (var call in samsungPhone.CallHistory)
            {
                Console.WriteLine(call);
            }

            decimal pricePerMinute = 0.37M;
            var totalPrice = samsungPhone.TotalPrice(pricePerMinute);
            Console.WriteLine($"Total price with longest call: {totalPrice}");

            ICall longestCall = samsungPhone.CallHistory.
                Aggregate((agg, next) => ((Call)next).Duration > ((Call)agg).Duration ? next : agg);

            samsungPhone.DeleteCall(longestCall);

            Console.WriteLine("---------- Without longest call --------");
            decimal priceWithoutLongest = samsungPhone.TotalPrice(pricePerMinute);
            Console.WriteLine($"Total price without longest call: {priceWithoutLongest}");
        }
    }
}
