using Campaign.Domain.Builders;
using Campaign.Domain.Dtos.Product;
using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using Campaign.Domain.Services;
using Campaign.Infrastructure.Builders;
using Campaign.Infrastructure.Repositories.InMemory;
using Campaign.Infrastructure.Services;
using Xunit;

namespace Campaign.Test.Services
{
    public class ProductServiceTest
    {
        private readonly IProductRepository _productRepository;
        private readonly ICampaignRepository _campaignRepository;

        private readonly ICampaignPriceBuilder _campaignPriceBuilder;

        private readonly ITimeService _timeService;
        private readonly IProductService _productService;


        public ProductServiceTest()
        {
            _productRepository = new InMemoryProductRepository();
            _campaignRepository = new InMemoryCampaignRepository();

            _campaignPriceBuilder = new CampaignPriceBuilder();

            _timeService = new TimeService();
            _productService = new ProductService(_productRepository, _campaignRepository, _timeService, _campaignPriceBuilder);

            _productRepository.Create(new Product
            {
                ProductCode = "P1",
                Price = 100,
                CurrentPrice = 100,
                Stock = 1000
            });
        }
        [Fact]
        public void GetProductInfoSuccessTest()
        {
            var productInfo = _productService.GetProductInfo("P1");
            Assert.True(productInfo != null);
        }
        [Fact]
        public void GetProductInfoNullTest()
        {
            var ex = Assert.Throws<BusinessException>(() => _productService.GetProductInfo("P2"));

            Assert.Equal("Product not found.", ex.Message);
        }

        [Fact]
        public void CreateProductSuccessTest()
        {
            _productService.ProductCreate(new ProductCreateDto
            {
                ProductCode = "P2",
                Price = 100,
                Stock = 1
            });
            Assert.True(true);
        }
        [Fact]
        public void CreateProductErrorTest()
        {
            var ex = Assert.Throws<DatabaseException>(() => _productService.ProductCreate(new ProductCreateDto
            {
                ProductCode = "P1",
                Price = 100,
                Stock = 1
            }));
            Assert.Equal("Product already exist.", ex.Message);
        }
    }
}
