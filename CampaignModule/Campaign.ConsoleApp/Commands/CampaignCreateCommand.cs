using Campaign.Domain.Dtos.Campaign;
using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.ConsoleApp.Commands
{
    public class CampaignCreateCommand : ICommand
    {
        private readonly ICampaignService _campaignService;
        public CampaignCreateCommand(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }
        public void Process(string[] arg)
        {
            var campaignCreateDto = new CampaignCreateDto
            {
                Name = arg[1],
                ProductCode = arg[2],
                Duration = Convert.ToByte(arg[3]),
                PriceManipulationLimit = Convert.ToByte(arg[4]),
                TargetSalesCount = Convert.ToInt32(arg[5])
            };
            _campaignService.CampaignCreate(campaignCreateDto);
            Console.WriteLine($"Campaign created; name {campaignCreateDto.Name}, product {campaignCreateDto.ProductCode}, duration {campaignCreateDto.Duration}, limit {campaignCreateDto.PriceManipulationLimit }, target sales count {campaignCreateDto.TargetSalesCount}");
        }
    }
}
