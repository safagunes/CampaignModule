using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Campaign.Infrastructure.Repositories.InMemory
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private List<Order> _orders = new List<Order>();
        public void Create(Order model)
        {
            _orders.Add(model);
        }
        public List<Order> GetList(string code)
        {
            return _orders.Where(a => a.ProductCode == code).ToList();
        }
    }
}
