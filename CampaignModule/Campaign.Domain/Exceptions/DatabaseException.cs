using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Exceptions
{
    public class DatabaseException  : Exception
    {
        public DatabaseException(string message) : base(message)
    {

    }
}
}
