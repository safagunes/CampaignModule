using Campaign.ConsoleApp.Builders;
using Campaign.Domain.Services;
using System;

namespace Campaign.ConsoleApp.Commands
{
    public class OrderCreateCommand : ICommand
    {
        private readonly IOrderService _orderService;
        public OrderCreateCommand(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public void Process(string[] arg)
        {
            if ((arg.Length - 1) != 2)
            {
                throw new ApplicationException($"The argument count of the {arg[0]} command is incorrect. Expected number of arguments 2.");
            }
            var orderCreateBuilder = new OrderCreateBuilder();
            var orderCreateDto = orderCreateBuilder.SetProductCode(arg[1])
                                                   .SetQuantity(arg[2])
                                                   .Build();
            _orderService.OrderCreate(orderCreateDto);
            Console.WriteLine($"Order created; product {orderCreateDto.ProductCode}, quantity {orderCreateDto.Quantity}");
        }
    }
}
