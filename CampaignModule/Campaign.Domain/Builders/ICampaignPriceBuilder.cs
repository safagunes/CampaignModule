namespace Campaign.Domain.Builders
{
    public interface ICampaignPriceBuilder
    {
        decimal Build(decimal price, byte duration, byte priceManipulationLimit, int hour);
    }
}
