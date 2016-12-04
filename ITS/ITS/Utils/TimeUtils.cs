using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITS.Utils
{
    public class TimeUtils
    {
        private const int MS_IN_SECOND = 1000;
        private const int SECONDS_IN_MIN = 60;
        private const int MIN_IN_HOUR = 60;
        private const int SECONDS_IN_HOUR = SECONDS_IN_MIN * MIN_IN_HOUR;
        private const int MS_IN_HOUR = SECONDS_IN_HOUR * MS_IN_SECOND;

        public static int ConvertHoursToMilliseconds(int hours)
        {
            return hours * MS_IN_HOUR;
        }

        public static int ConvertMillisecondsToHours(int ms)
        {
            return ms / MS_IN_HOUR;
        }
    }
}