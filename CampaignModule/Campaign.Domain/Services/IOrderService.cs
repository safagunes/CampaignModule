using Campaign.Domain.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Domain.Services
{
    public interface IOrderService
    {
        void OrderCreate(OrderCreateDto model);
    }
}
