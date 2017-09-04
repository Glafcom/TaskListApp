using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasklistApp.Web.Helpers {
    public static class DurationHelper {
        public static string ConvertTimeSpanToString(TimeSpan timeSpan) {
            var daysCount = timeSpan.Days;
            timeSpan -= new TimeSpan(daysCount, 0, 0, 0);
            var hoursCount = timeSpan.Hours;
            timeSpan -= new TimeSpan(hoursCount, 0, 0);
            var minutesCount = timeSpan.Minutes;
            return (daysCount > 0 ? $"{daysCount}d " : string.Empty) +
                (hoursCount > 0 ? $"{hoursCount}h " : string.Empty) +
                (minutesCount > 0 ? $"{minutesCount}m" : string.Empty);
        } 

        public static TimeSpan ConvertStringToTimeSpan(string strValue) {
            int daysCount = 0, hoursCount = 0, minutesCount = 0;
            string[] strArray = strValue.Split(' ');
            foreach(var item in strArray) {
                int value;
                var unit = item.Trim().Last();
                int.TryParse(item.Substring(0, item.Length - 1), out value);
                switch (unit) {
                    case 'd':
                        daysCount = value;
                        break;
                    case 'h':
                        hoursCount = value;
                        break;
                    case 'm':
                        minutesCount = value;
                        break;
                    default:
                        break;
                }
            }
            return new TimeSpan(daysCount, hoursCount, minutesCount, 0);
        }

    }
}