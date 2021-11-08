using Campaign.Domain.Dtos.Campaign;
using Campaign.Domain.Exceptions;
using Campaign.Domain.Repositories;
using Campaign.Domain.Services;
using System.Linq;

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

        public CampaingInfoDto GetCampaingInfo(string name)
        {
            var campaign = _campaignRepository.Get(name);
            if (campaign == null)
            {
                throw new BusinessException("Campaign not found.");
            }
            var time = _timeService.Get();
            bool status = (campaign.Duration - time.Hour) > 0;
            var orderlist = _orderRepository.GetList(campaign.ProductCode);
            var dd = orderlist.Count();
            return new CampaingInfoDto
            {
                Name = campaign.Name,
                Status = status,
                TargetSalesCount = campaign.TargetSalesCount,
                TotalSalesCount = orderlist.Count(),
                Turnover = campaign.TargetSalesCount * orderlist.Count(),
                AvarageItemPrice = (orderlist != null && orderlist.Count > 0) ? orderlist.Average(a => a.Quantity * a.Price) : (decimal?)null
            };
        }
    }
}
