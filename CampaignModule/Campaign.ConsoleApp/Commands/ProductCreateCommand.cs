using Campaign.ConsoleApp.Builders;
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
            if ((arg.Length - 1) != 3)
            {
                throw new ApplicationException($"The argument count of the {arg[0]} command is incorrect. Expected number of arguments 3.");
            }

            var productCreateBuilder = new ProductCreateBuilder();
            var productCreateDto = productCreateBuilder.SetProductCode(arg[1])
                                                       .SetPrice(arg[2])
                                                       .SetStock(arg[3])
                                                       .Build();
            _productService.ProductCreate(productCreateDto);
            Console.WriteLine($"Product created; code {productCreateDto.ProductCode}, price {productCreateDto.Price}, stock {productCreateDto.Stock}");
        }
    }
}
