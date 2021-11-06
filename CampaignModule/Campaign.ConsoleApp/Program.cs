using Campaign.ConsoleApp.Models;
using Campaign.Domain.Dtos.Campaign;
using Campaign.Domain.Dtos.Order;
using Campaign.Domain.Dtos.Product;
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
            var commands = new List<Command> {
                    new Command{
                        Name= "create_product",
                        ArgCount=3,
                        ArgTypes=new Type [] {typeof(string), typeof(decimal),typeof(int)
                        }
                    },
                    new Command{
                        Name= "get_product_info",
                        ArgCount=1,
                        ArgTypes=new Type [] {typeof(string)
                        }
                    },
                    new Command{
                        Name= "create_order",
                        ArgCount=2,
                        ArgTypes=new Type [] {typeof(string),typeof(int)
                        }
                    },
                    new Command{
                        Name= "create_campaign",
                        ArgCount=5,
                        ArgTypes=new Type [] {typeof(string),typeof(string),typeof(byte),typeof(byte),typeof(int)
                        }
                    },
                    new Command{
                        Name= "get_campaign_info",
                        ArgCount=1,
                        ArgTypes=new Type [] {typeof(string)
                        }
                    },
                    new Command{
                        Name= "increase_time",
                        ArgCount=1,
                        ArgTypes=new Type [] {typeof(byte)
                        }
                    }
            };

            IProductService _productService = new ProductService(new InMemoryProductRepository());
            IOrderService _orderService = new OrderService(new InMemoryOrderRepository());
            ICampaignService _campaignService = new CampaignService(new InMemoryCampaignRepository());
            ITimeService _timeService = new TimeService();

            try
            {
                string[] lines = File.ReadAllLines(@$"{Directory.GetCurrentDirectory()}\\Commands.txt");
                foreach (string line in lines)
                {
                    var splittedCommand = line.Split(" ");

                    var command = commands.SingleOrDefault(a => a.Name == splittedCommand[0]);
                    if (command != null)
                    {
                        if (command.ArgCount == splittedCommand.Length)
                        {
                            //TODO:Safa:Burada  type kontrolü yapılacak. Şimdilik es geçiyorum

                            switch (splittedCommand[0])
                            {
                                case "create_product":
                                    var productCreateDto = new ProductCreateDto
                                    {
                                        ProductCode = splittedCommand[1],
                                        Price = Convert.ToDecimal(splittedCommand[2]),
                                        Stock = Convert.ToInt32(splittedCommand[3])
                                    };
                                    _productService.ProductCreate(productCreateDto);
                                    Console.WriteLine($"Product created; code {productCreateDto.ProductCode}, price {productCreateDto.Price}, stock {productCreateDto.Stock}");
                                    break;
                                case "get_product_info":
                                    var productInfo = _productService.GetProductInfo(splittedCommand[1]);
                                    Console.WriteLine($"Product {productInfo.ProductCode} info; price {productInfo.Price}, stock {productInfo.Stock}");
                                    break;
                                case "create_order":
                                    var orderCreateDto = new OrderCreateDto
                                    {
                                        ProductCode = splittedCommand[1],
                                        Quantity = Convert.ToInt32(splittedCommand[2])
                                    };
                                    _orderService.OrderCreate(orderCreateDto);
                                    Console.WriteLine($"Order created; product {orderCreateDto.ProductCode}, quantity {orderCreateDto.Quantity}");
                                    break;
                                case "create_campaign":
                                    var campaignCreateDto = new CampaignCreateDto
                                    {
                                        Name = splittedCommand[1],
                                        ProductCode = splittedCommand[1],
                                        Duration = Convert.ToByte(splittedCommand[2]),
                                        PriceManipulationLimit = Convert.ToByte(splittedCommand[3]),
                                        TargetSalesCount = Convert.ToInt32(splittedCommand[4])
                                    };
                                    _campaignService.CampaignCreate(campaignCreateDto);
                                    Console.WriteLine($"Campaign created; name {campaignCreateDto.Name}, product {campaignCreateDto.ProductCode}, duration {campaignCreateDto.Duration}, limit {campaignCreateDto.PriceManipulationLimit }, target sales count {campaignCreateDto.TargetSalesCount}");
                                    break;
                                case "get_campaign_info":
                                    var campaignInfo = _campaignService.GetCampaingInfo(splittedCommand[1]);
                                    Console.WriteLine($"Campaign {campaignInfo.Name} info; Status {(campaignInfo.Status? "Active" : "Passive")}, Target Sales {campaignInfo.TargetSalesCount}, Total Sales {campaignInfo.TotalSalesCount}, Turnover {campaignInfo.Turnover}, Average Item Price {campaignInfo.AvarageItemPrice}");
                                    break;
                                case "increase_time":
                                    var time = _timeService.Get();
                                    Console.WriteLine($"Time is {time.Hour}:{time.Minute}");
                                    break;
                                default:
                                    break;

                            }


                        }
                        else
                        {
                            Console.WriteLine($"Missing argument Command:{line}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Command not found Command:{line}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File not found in directory {Directory.GetCurrentDirectory()}");

            }


            Console.ReadKey();
        }
    }
}
