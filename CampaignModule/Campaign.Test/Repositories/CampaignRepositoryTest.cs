using Campaign.Domain.Exceptions;
using Campaign.Domain.Repositories;
using Campaign.Infrastructure.Repositories.InMemory;
using Xunit;

namespace Campaign.Test.Repositories
{
    public class CampaignRepositoryTest
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignRepositoryTest()
        {
            _campaignRepository = new InMemoryCampaignRepository();
            _campaignRepository.Create(new Domain.Models.Campaign
            {
                Name = "C1",
                ProductCode = "P1",
                Duration = 10,
                PriceManipulationLimit = 20,
                TargetSalesCount = 100
            });
        }

        [Fact]
        public void GetSuccessTest()
        {
            var campaignInfo = _campaignRepository.Get("C1");
            Assert.True(campaignInfo != null);
        }

        [Fact]
        public void GetNullTest()
        {
            var campaignInfo = _campaignRepository.Get("C2");
            Assert.True(campaignInfo == null);
        }

        [Fact]
        public void GetByProductCodeSuccesTest()
        {
            var campaignList = _campaignRepository.GetByProductCode("P1");
            Assert.True(campaignList != null && campaignList.Count > 0);
        }

        [Fact]
        public void GetByProductCodeBNullTest()
        {
            var orderList = _campaignRepository.GetByProductCode("P2");
            Assert.True(orderList == null || orderList.Count == 0);
        }

        [Fact]
        public void CreateSuccessTest()
        {
            _campaignRepository.Create(new Domain.Models.Campaign
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
        public void CreateErrorTest()
        {
            var ex = Assert.Throws<DatabaseException>(() => _campaignRepository.Create(new Domain.Models.Campaign
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
