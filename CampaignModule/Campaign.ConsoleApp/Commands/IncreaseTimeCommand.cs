using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.ConsoleApp.Commands
{
    public class IncreaseTimeCommand : ICommand
    {
        private readonly ITimeService _timeService;
        public IncreaseTimeCommand(ITimeService timeService)
        {
            _timeService = timeService;
        }
        public void Process(string[] arg)
        {
            _timeService.Incrace(1);
            var time = _timeService.Get();
            Console.WriteLine($"Time is {time.ToString("HH:mm")}");
        }
    }
}
