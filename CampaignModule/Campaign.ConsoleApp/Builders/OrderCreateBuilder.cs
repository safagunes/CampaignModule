using Campaign.Domain.Dtos.Order;
using System;

namespace Campaign.ConsoleApp.Builders
{
    public class OrderCreateBuilder
    {
        private string ProductCode { get; set; }
        private int Quantity { get; set; }

        public OrderCreateBuilder SetProductCode(string arg)
        {
            ProductCode = arg;
            return this;
        }

        public OrderCreateBuilder SetQuantity(string arg)
        {
            if (int.TryParse(arg, out int value))
            {
                Quantity = value;
            }
            else
            {
                throw new ApplicationException($"Failed to SetQuantity. Arg:{arg}");
            }
            return this;
        }

        public OrderCreateDto Build()
        {
            return new OrderCreateDto
            {
                ProductCode = ProductCode,
                Quantity = Quantity
            };
        }
    }
}
