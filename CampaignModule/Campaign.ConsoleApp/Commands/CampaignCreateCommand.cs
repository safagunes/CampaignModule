using Campaign.ConsoleApp.Builders;
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
            if ((arg.Length - 1) != 5)
            {
                throw new ApplicationException($"The argument count of the {arg[0]} command is incorrect. Expected number of arguments 5.");
            }

            var campaignCreateBuilder = new CampaignCreateBuilder();
            var campaignCreateDto = campaignCreateBuilder.SetName(arg[1])
                                                         .SetProductCode(arg[2])
                                                         .SetDuration(arg[3])
                                                         .SetPriceManipulationLimit(arg[4])
                                                         .SetTargetSalesCount(arg[5])
                                                         .Build();
            _campaignService.CampaignCreate(campaignCreateDto);
            Console.WriteLine($"Campaign created; name {campaignCreateDto.Name}, product {campaignCreateDto.ProductCode}, duration {campaignCreateDto.Duration}, limit {campaignCreateDto.PriceManipulationLimit }, target sales count {campaignCreateDto.TargetSalesCount}");
        }
    }
}
