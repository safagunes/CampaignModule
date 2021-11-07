using Campaign.Domain.Dtos.Product;
using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campaign.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ITimeService _timeService;
        public ProductService(IProductRepository productRepository, ICampaignRepository campaignRepository, ITimeService timeService)
        {
            _productRepository = productRepository;
            _campaignRepository = campaignRepository;
            _timeService = timeService;
        }
        public ProductInfoDto GetProductInfo(string code)
        {
            var product = _productRepository.Get(code);
            if (product == null)
            {
                throw new BusinessException("Product not found");
            }
            var campaigns = _campaignRepository.GetByProductCode(code);

            var time = _timeService.Get();

            var activeCampains = campaigns.SingleOrDefault(a => a.Duration - time.Hour > 0);

            if (activeCampains != null)
            {
                //TODO:Safa: Price Hesaplama yapılacak
                product.CurrentPrice = product.Price - (product.Price * (activeCampains.PriceManipulationLimit / activeCampains.Duration * time.Hour) / 100);

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
