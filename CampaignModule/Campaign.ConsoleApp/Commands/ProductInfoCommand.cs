using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
            var productInfo = _productService.GetProductInfo(arg[1]);
            Console.WriteLine($"Product {productInfo.ProductCode} info; price {productInfo.Price}, stock {productInfo.Stock}");
        }
    }
}
