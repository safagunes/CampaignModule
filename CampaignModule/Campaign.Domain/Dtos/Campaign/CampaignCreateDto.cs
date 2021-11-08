namespace Campaign.Domain.Dtos.Campaign
{
    public class CampaignCreateDto
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public byte Duration { get; set; }
        public byte PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
