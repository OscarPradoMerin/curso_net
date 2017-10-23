using System;

namespace Powerdede.Utils {
    public static class DateUtils {
        public static bool IsInYesterday(DateTime date)
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);

            return date.Date == yesterday;
        }

        public static bool IsInLastMonth(DateTime date)
        {
            DateTime lastMonth = DateTime.Today.AddMonths(-1);
            return date.Month == lastMonth.Month && date.Year == lastMonth.Year;
        }

        public static bool IsInLastYear(DateTime dt)
        {
            return dt.Year == DateTime.Now.Year - 1;
        }
    }
}