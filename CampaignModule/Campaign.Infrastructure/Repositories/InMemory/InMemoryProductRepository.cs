using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using System.Collections.Generic;

namespace Campaign.Infrastructure.Repositories.InMemory
{
    public class InMemoryProductRepository : IProductRepository
    {
        private Dictionary<string, Product> _products = new Dictionary<string, Product>();
        public void Create(Product model)
        {
            if (_products.TryGetValue(model.ProductCode, out Product product))
            {
                throw new DatabaseException("Product already exist.");
            }
            _products.Add(model.ProductCode, model);
        }

        public Product Get(string code)
        {
            _products.TryGetValue(code, out Product product);
            return product;
        }
    }
}
