using Campaign.Domain.Dtos.Campaign;
using Campaign.Domain.Repositories;
using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campaign.Infrastructure.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITimeService _timeService;
        public CampaignService(ICampaignRepository campaignRepository, IOrderRepository orderRepository, ITimeService timeService)
        {
            _campaignRepository = campaignRepository;
            _orderRepository = orderRepository;
            _timeService = timeService;
        }
        public void CampaignCreate(CampaignCreateDto model)
        {
            _campaignRepository.Create(new Domain.Models.Campaign
            {
                Name = model.Name,
                ProductCode = model.ProductCode,
                Duration = model.Duration,
                PriceManipulationLimit = model.PriceManipulationLimit,
                TargetSalesCount = model.TargetSalesCount
            });
        }

        public CampaingInfoDto GetCampaingInfo(string code)
        {
            var campaign = _campaignRepository.Get(code);
            var time = _timeService.Get();
            bool status = (campaign.Duration - time.Hour) <= 0 ? false : true;

            var orderlist = _orderRepository.GetList(code);

            return new CampaingInfoDto
            {
                Name = campaign.Name,
                Status = status,
                TargetSalesCount = campaign.TargetSalesCount,
                TotalSalesCount = orderlist.Count,
                AvarageItemPrice = orderlist.Average(a => a.Price),
                Turnover = campaign.TargetSalesCount * orderlist.Count
            };
        }
    }
}
