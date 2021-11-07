using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.ConsoleApp.Commands
{
    public class CampaignInfoCommand : ICommand
    {
        private readonly ICampaignService _campaignService;
        public CampaignInfoCommand(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }
      
        public void Process(string[] arg)
        {
            if ((arg.Length - 1) != 1)
            {
                throw new ApplicationException($"The argument count of the {arg[0]} command is incorrect. Expected number of arguments 1.");
            }
            var campaignInfo = _campaignService.GetCampaingInfo(arg[1]);
            Console.WriteLine($"Campaign {campaignInfo.Name} info; Status {(campaignInfo.Status ? "Active" : "Ended")}, Target Sales {campaignInfo.TargetSalesCount}, Total Sales {campaignInfo.TotalSalesCount}, Turnover {campaignInfo.Turnover}, Average Item Price {(campaignInfo.AvarageItemPrice == null ? "-" : campaignInfo.AvarageItemPrice.ToString())}");
        }
    }
}
