using Campaign.Domain.Dtos.Product;
using System;

namespace Campaign.ConsoleApp.Builders
{
    public class ProductCreateBuilder
    {
        private string ProductCode { get; set; }
        private decimal Price { get; set; }
        private int Stock { get; set; }

        public ProductCreateBuilder SetProductCode(string arg)
        {
            ProductCode = arg;
            return this;
        }
        public ProductCreateBuilder SetPrice(string arg)
        {
            if (decimal.TryParse(arg, out decimal value))
            {
                Price = value;
            }
            else
            {
                throw new ApplicationException($"Failed to SetPrice. Arg:{arg}");
            }
            return this;
        }
        public ProductCreateBuilder SetStock(string arg)
        {
            if (int.TryParse(arg, out int value))
            {
                Stock = value;
            }
            else
            {
                throw new ApplicationException($"Failed to SetStock. Arg:{arg}");
            }
            return this;
        }

        public ProductCreateDto Build()
        {
            return new ProductCreateDto
            {
                ProductCode = ProductCode,
                Price = Price,
                Stock = Stock
            };
        }
    }
}
