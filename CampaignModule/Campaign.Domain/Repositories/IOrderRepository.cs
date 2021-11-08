using Campaign.Domain.Models;
using System.Collections.Generic;

namespace Campaign.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Create(Order model);
        List<Order> GetList(string code);
    }
}
