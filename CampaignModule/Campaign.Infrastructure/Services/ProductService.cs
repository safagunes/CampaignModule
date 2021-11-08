using Campaign.Domain.Builders;
using Campaign.Domain.Dtos.Product;
using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using Campaign.Domain.Services;
using System.Linq;

namespace Campaign.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ITimeService _timeService;
        private readonly ICampaignPriceBuilder _campaignPriceBuilder;
        public ProductService(IProductRepository productRepository, ICampaignRepository campaignRepository, ITimeService timeService, ICampaignPriceBuilder campaignPriceBuilder)
        {
            _productRepository = productRepository;
            _campaignRepository = campaignRepository;
            _timeService = timeService;
            _campaignPriceBuilder = campaignPriceBuilder;
        }
        public ProductInfoDto GetProductInfo(string code)
        {
            var product = _productRepository.Get(code);
            if (product == null)
            {
                throw new BusinessException("Product not found.");
            }
            var campaigns = _campaignRepository.GetByProductCode(code);

            var time = _timeService.Get();

            var activeCampain = campaigns.SingleOrDefault(a => a.Duration - time.Hour > 0);

            if (activeCampain != null)
            {

                product.CurrentPrice = _campaignPriceBuilder.Build(product.Price, activeCampain.Duration, activeCampain.PriceManipulationLimit, time.Hour);
            }
            return new ProductInfoDto
            {
                ProductCode = product.ProductCode,
                Price = product.CurrentPrice,
                Stock = product.Stock
            };
        }

        public void ProductCreate(ProductCreateDto model)
        {
            _productRepository.Create(new Product
            {
                ProductCode = model.ProductCode,
                Price = model.Price,
                CurrentPrice = model.Price,
                Stock = model.Stock
            });
        }
    }
}
