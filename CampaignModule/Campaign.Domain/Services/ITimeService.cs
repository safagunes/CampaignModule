using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Services
{
    public interface ITimeService
    {
       
        DateTime Get();

        void Incrace(int hour);


    }
}
