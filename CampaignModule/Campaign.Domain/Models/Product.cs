using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Models
{
    public class Product
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public decimal CurrentPrice { get; set; }
        public int Stock { get; set; }
    }
}
