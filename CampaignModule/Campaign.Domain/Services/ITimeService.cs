using System;

namespace Campaign.Domain.Services
{
    public interface ITimeService
    {

        DateTime Get();

        void Incrace(int hour);


    }
}
