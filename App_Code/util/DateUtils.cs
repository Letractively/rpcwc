using System;
using System.Collections.Generic;
using System.Text;

namespace rpcwc.util
{
    class DateUtils
    {
        public static DateTime getSaturdayAfter(DateTime date)
        {
            return date.AddDays(DayOfWeek.Saturday - date.DayOfWeek);
        }

        public static DateTime getSundayBefore(DateTime date)
        {
            return date.AddDays(-((date.DayOfWeek - DayOfWeek.Sunday) % 7));
        }

        public static DateTime getStartOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);

            //return date.AddDays(1 - date.Day);
        }

        public static DateTime getEndOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);

            //return date.AddDays(1 - date.Day);
        }
    }
}
