using System;

namespace Academy.Utils
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTimeNow()
        {
            return DateTime.Now;
        }
    }
}
