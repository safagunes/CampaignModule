using Campaign.Domain.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Services
{
    public interface IProductService
    {
        void ProductCreate(ProductCreateDto model);
        ProductInfoDto GetProductInfo(string code);
    }
}
