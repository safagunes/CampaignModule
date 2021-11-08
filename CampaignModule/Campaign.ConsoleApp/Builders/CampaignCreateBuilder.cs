using Campaign.Domain.Dtos.Campaign;
using System;

namespace Campaign.ConsoleApp.Builders
{
    public class CampaignCreateBuilder
    {
        private string Name { get; set; }
        private string ProductCode { get; set; }
        private byte Duration { get; set; }
        private byte PriceManipulationLimit { get; set; }
        private int TargetSalesCount { get; set; }

        public CampaignCreateBuilder SetName(string arg)
        {
            Name = arg;
            return this;
        }
        public CampaignCreateBuilder SetProductCode(string arg)
        {
            ProductCode = arg;
            return this;
        }
        public CampaignCreateBuilder SetDuration(string arg)
        {
            if (byte.TryParse(arg, out byte value))
            {
                Duration = value;
            }
            else
            {
                throw new ApplicationException($"Failed to SetDuration. Arg:{arg}");
            }
            return this;
        }
        public CampaignCreateBuilder SetPriceManipulationLimit(string arg)
        {
            if (byte.TryParse(arg, out byte value))
            {
                PriceManipulationLimit = value;
            }
            else
            {
                throw new ApplicationException($"Failed to SetPriceManipulationLimit. Arg:{arg}");
            }
            return this;
        }
        public CampaignCreateBuilder SetTargetSalesCount(string arg)
        {
            if (int.TryParse(arg, out int value))
            {
                TargetSalesCount = value;
            }
            else
            {
                throw new ApplicationException($"Failed to SetQuantity. Arg:{arg}");
            }
            return this;
        }

        public CampaignCreateDto Build()
        {
            return new CampaignCreateDto
            {
                Name = Name,
                ProductCode = ProductCode,
                Duration = Duration,
                PriceManipulationLimit = PriceManipulationLimit,
                TargetSalesCount = TargetSalesCount
            };
        }
    }
}
