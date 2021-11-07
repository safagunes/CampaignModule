using Campaign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Repositories
{
    public interface IProductRepository
    {
        void Create(Product model);
        Product Get(string code);
    }
}
