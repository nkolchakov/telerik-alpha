using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Commands.Contracts;

namespace Academy.Models.Utils
{
    public static class DateParser
    {
        public static DateTime Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Date string cannot be null or white space!");
            }
            // 2017-01-24
            var splitted = input.Split('-').Select(x => int.Parse(x)).ToArray();

            int year = splitted[0];
            int month = splitted[1];
            int date = splitted[2];

            return new DateTime(year, month, date);
        }
    }
}
