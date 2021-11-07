using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {

        }
    }
}
