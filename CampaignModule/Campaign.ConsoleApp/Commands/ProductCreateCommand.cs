using Campaign.Domain.Dtos.Product;
using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.ConsoleApp.Commands
{
    public class ProductCreateCommand : ICommand
    {
        private readonly IProductService _productService;
        public ProductCreateCommand(IProductService productService)
        {
            _productService = productService;
        }
        public void Process(string[] arg)
        {
            var productCreateDto = new ProductCreateDto
            {
                ProductCode = arg[1],
                Price = Convert.ToDecimal(arg[2]),
                Stock = Convert.ToInt32(arg[3])
            };
            _productService.ProductCreate(productCreateDto);
            Console.WriteLine($"Product created; code {productCreateDto.ProductCode}, price {productCreateDto.Price}, stock {productCreateDto.Stock}");
        }
    }
}
