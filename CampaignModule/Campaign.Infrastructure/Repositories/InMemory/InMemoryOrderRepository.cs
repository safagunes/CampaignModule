using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campaign.Infrastructure.Repositories.InMemory
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static List<Order> _orders = new List<Order>();
        public void Create(Order model)
        {
            _orders.Add(model);
        }

        public Order Get(string code)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetList(string code)
        {
            return _orders.Where(a => a.ProductCode == code).ToList();
        }
    }
}
