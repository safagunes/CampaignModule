using Campaign.Domain.Services;
using System;

namespace Campaign.ConsoleApp.Commands
{
    public class ProductInfoCommand : ICommand
    {

        private readonly IProductService _productService;
        public ProductInfoCommand(IProductService productService)
        {
            _productService = productService;
        }
        public void Process(string[] arg)
        {
            if ((arg.Length - 1) != 1)
            {
                throw new ApplicationException($"The argument count of the {arg[0]} command is incorrect. Expected number of arguments 1.");
            }
            var productInfo = _productService.GetProductInfo(arg[1]);
            Console.WriteLine($"Product {productInfo.ProductCode} info; price {productInfo.Price}, stock {productInfo.Stock}");
        }
    }
}
