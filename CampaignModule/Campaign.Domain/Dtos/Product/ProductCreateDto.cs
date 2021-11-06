﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Dtos.Product
{
    public class ProductCreateDto
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}