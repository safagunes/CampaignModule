using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.ConsoleApp.Commands
{
    public interface ICommand
    {
        void Process(string[] arg);
    }
}
