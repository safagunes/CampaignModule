using Campaign.Domain.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Infrastructure.Builders
{
    public class CampaignPriceBuilder : ICampaignPriceBuilder
    {
        public decimal Build(decimal price, byte duration, byte priceManipulationLimit, int hour)
        {
            return price - (price * (priceManipulationLimit / duration * hour) / 100);
        }
    }
}
