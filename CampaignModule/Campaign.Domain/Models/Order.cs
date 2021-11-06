using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Models
{
    public class Order
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
