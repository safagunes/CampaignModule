using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.ConsoleApp.Models
{
    public class Command
    {
        public string Name { get; set; }
        public byte ArgCount { get; set; }
        public Type[]  ArgTypes { get; set; }
    }
}
