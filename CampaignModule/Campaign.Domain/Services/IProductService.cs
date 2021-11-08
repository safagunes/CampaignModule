using Campaign.Domain.Dtos.Product;

namespace Campaign.Domain.Services
{
    public interface IProductService
    {
        void ProductCreate(ProductCreateDto model);
        ProductInfoDto GetProductInfo(string code);
    }
}
