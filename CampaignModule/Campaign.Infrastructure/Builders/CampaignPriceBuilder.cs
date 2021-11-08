using Campaign.Domain.Builders;

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
