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
            if ((arg.Length - 1) != 1)
            {
                throw new ApplicationException($"The argument count of the {arg[0]} command is incorrect. Expected number of arguments 1.");
            }
            _timeService.Incrace(1);
            var time = _timeService.Get();
            Console.WriteLine($"Time is {time.ToString("HH:mm")}");
        }
    }
}
