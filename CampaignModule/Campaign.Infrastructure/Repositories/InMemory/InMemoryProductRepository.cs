using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Infrastructure.Repositories.InMemory
{
    public class InMemoryProductRepository : IProductRepository
    {
        private static Dictionary<string, Product> _products = new Dictionary<string, Product>();
        public void Create(Product model)
        {
            if (_products.TryGetValue(model.ProductCode, out Product product))
            {
                throw new DatabaseException("Product already exist");
            }
            _products.Add(model.ProductCode, model);
        }

        public Product Get(string code)
        {
            if (!_products.TryGetValue(code, out Product product))
            {
                throw new DatabaseException("Product not found");
            }
            return product;
        }
    }
}
