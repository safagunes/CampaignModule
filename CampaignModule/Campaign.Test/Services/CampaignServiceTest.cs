using Campaign.Domain.Dtos.Campaign;
using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using Campaign.Domain.Services;
using Campaign.Infrastructure.Repositories.InMemory;
using Campaign.Infrastructure.Services;
using Xunit;

namespace Campaign.Test.Services
{
    public class CampaignServiceTest
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICampaignRepository _campaignRepository;

        private readonly ITimeService _timeService;
        private readonly ICampaignService _campaignService;


        public CampaignServiceTest()
        {
            _orderRepository = new InMemoryOrderRepository();
            _productRepository = new InMemoryProductRepository();
            _campaignRepository = new InMemoryCampaignRepository();
            _timeService = new TimeService();
            _campaignService = new CampaignService(_campaignRepository, _orderRepository, _timeService);

            _productRepository.Create(new Product
            {
                ProductCode = "P1",
                Price = 100,
                CurrentPrice = 100,
                Stock = 1000
            });
            _campaignRepository.Create(new Domain.Models.Campaign
            {
                Name = "C1",
                ProductCode = "P1",
                Duration = 10,
                PriceManipulationLimit = 20,
                TargetSalesCount = 1000
            });
        }
        [Fact]
        public void GetCampaignInfoSuccessTest()
        {
            var campaignInfo = _campaignService.GetCampaingInfo("C1");
            Assert.True(campaignInfo != null);
        }
        [Fact]
        public void GetCampaignInfoNullTest()
        {
            var ex = Assert.Throws<BusinessException>(() => _campaignService.GetCampaingInfo("C2"));
            Assert.Equal("Campaign not found.", ex.Message);
        }

        [Fact]
        public void CreateCampaignSuccessTest()
        {
            _campaignService.CampaignCreate(new CampaignCreateDto
            {
                Name = "C2",
                ProductCode = "P1",
                Duration = 10,
                PriceManipulationLimit = 20,
                TargetSalesCount = 100
            });
            Assert.True(true);
        }
        [Fact]
        public void CreateCampaignErrorTest()
        {
            var ex = Assert.Throws<DatabaseException>(() => _campaignService.CampaignCreate(new CampaignCreateDto
            {
                Name = "C1",
                ProductCode = "P1",
                Duration = 10,
                PriceManipulationLimit = 20,
                TargetSalesCount = 100
            }));
            Assert.Equal("Campaign already exist.", ex.Message);
        }
    }
}
