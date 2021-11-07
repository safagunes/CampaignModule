using Campaign.Domain.Services;
using Campaign.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Campaign.Test.Services
{
    public class TimeServiceTest
    {
        private readonly ITimeService _timeService;
        public TimeServiceTest()
        {
            _timeService = new TimeService();
        }

        [Fact]
        public void GetTimeTest()
        {
            var time = _timeService.Get();
            Assert.True(time != null);
        }

        [Fact]
        public void IncreaceTimeTest()
        {
            _timeService.Incrace(1);
            var time = _timeService.Get();
            Assert.True(time.Hour == 1);
        }
    }
}
