using Campaign.Domain.Services;
using System;

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

            if (!int.TryParse(arg[1], out int value))
            {
                throw new ApplicationException($"Failed to SetIncreaseHour. Arg:{arg}");
            }

            _timeService.Incrace(value);
            var time = _timeService.Get();
            Console.WriteLine($"Time is {time:HH:mm}");
        }
    }
}
