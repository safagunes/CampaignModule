using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Dtos.Order
{
    public class OrderCreateDto
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
