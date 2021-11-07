using Campaign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Create(Order model);
        List<Order> GetList(string code);
    }
}
