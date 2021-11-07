using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using Campaign.Infrastructure.Repositories.InMemory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Campaign.Test.Repositories
{
    public class OrderRepositoryTest
    {
        private readonly IOrderRepository _orderRepository;
        public OrderRepositoryTest()
        {
            _orderRepository = new InMemoryOrderRepository();

            _orderRepository.Create(new Order
            {
                ProductCode = "P1",
                Price = 100,
                Quantity = 1
            });
        }

        [Fact]
        public void GetSuccessTest()
        {
            var orderList = _orderRepository.GetList("P1");
            Assert.True(orderList != null && orderList.Count > 0);
        }

        [Fact]
        public void GetNullTest()
        {
            var orderList = _orderRepository.GetList("P2");
            Assert.True(orderList == null || orderList.Count == 0);
        }

        [Fact]
        public void CreateSuccessTest()
        {
            _orderRepository.Create(new Order
            {
                ProductCode = "P2",
                Price = 100,
                Quantity = 1
            });
            Assert.True(true);
        }
    }
}
