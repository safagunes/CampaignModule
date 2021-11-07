using Campaign.Domain.Dtos.Campaign;
using Campaign.Domain.Dtos.Order;
using Campaign.Domain.Dtos.Product;
using Campaign.Domain.Repositories;
using Campaign.Domain.Services;
using Campaign.Infrastructure.Repositories.InMemory;
using Campaign.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Campaign.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductRepository _productRepository = new InMemoryProductRepository();
            IOrderRepository _orderRepository = new InMemoryOrderRepository();
            ICampaignRepository _campaignRepository = new InMemoryCampaignRepository();

            ITimeService _timeService = new TimeService();
            IProductService _productService = new ProductService(_productRepository, _campaignRepository, _timeService);
            IOrderService _orderService = new OrderService(_orderRepository, _productRepository);
            ICampaignService _campaignService = new CampaignService(_campaignRepository, _orderRepository, _timeService);
            
            try
            {
                string[] lines = File.ReadAllLines(@$"{Directory.GetCurrentDirectory()}\\Commands.txt");

                var commandFactory = new CommandFactory(_productService,_orderService,_campaignService,_timeService);
                foreach (string line in lines)
                {
                    var splittedCommand = line.Split(" ");
                    var command = commandFactory.CreateCommand(splittedCommand[0]);
                    command.Process(splittedCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - Error Message: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
