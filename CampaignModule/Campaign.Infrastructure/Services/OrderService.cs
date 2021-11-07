using Campaign.Domain.Dtos.Order;
using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using Campaign.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public void OrderCreate(OrderCreateDto model)
        {
            var product = _productRepository.Get(model.ProductCode);
            if (product == null)
            {
                throw new BusinessException("Not found product for the order.");
            }
            _orderRepository.Create(new Order
            {
                ProductCode = model.ProductCode,
                Quantity = model.Quantity,
                Price = product != null ? product.Price : 0
            });
        }
    }
}
