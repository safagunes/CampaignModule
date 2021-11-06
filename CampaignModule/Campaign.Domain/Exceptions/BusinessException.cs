using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
