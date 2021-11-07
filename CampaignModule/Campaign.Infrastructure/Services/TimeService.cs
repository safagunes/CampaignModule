using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Campaign.Infrastructure.Services
{
    public class TimeService : ITimeService
    {
        private static DateTime time = new DateTime(new DateTime(1979, 07, 28, 00, 00, 00, new CultureInfo("tr-TR", false).Calendar).Ticks);

        public DateTime Get()
        {
            return time;
        }

        public void Incrace(int hour)
        {
           time = time.AddHours(hour);
        }
    }
}
