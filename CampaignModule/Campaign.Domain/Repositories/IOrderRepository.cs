using Campaign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        List<Order> GetList(string code);
    }
}
