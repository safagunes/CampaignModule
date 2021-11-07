using Campaign.Domain.Dtos.Order;
using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
            var orderCreateDto = new OrderCreateDto
            {
                ProductCode = arg[1],
                Quantity = Convert.ToInt32(arg[2])
            };
            _orderService.OrderCreate(orderCreateDto);
            Console.WriteLine($"Order created; product {orderCreateDto.ProductCode}, quantity {orderCreateDto.Quantity}");
        }
    }
}
