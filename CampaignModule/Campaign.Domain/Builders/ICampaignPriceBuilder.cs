using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Builders
{
    public interface ICampaignPriceBuilder
    {
        decimal Build(decimal price, byte duration, byte priceManipulationLimit, int hour);
    }
}
