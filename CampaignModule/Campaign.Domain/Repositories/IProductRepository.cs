using Campaign.Domain.Models;

namespace Campaign.Domain.Repositories
{
    public interface IProductRepository
    {
        void Create(Product model);
        Product Get(string code);
    }
}
