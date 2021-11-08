using Campaign.Domain.Dtos.Order;
using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using Campaign.Domain.Services;
using Campaign.Infrastructure.Repositories.InMemory;
using Campaign.Infrastructure.Services;
using Xunit;

namespace Campaign.Test.Services
{
    public class OrderServiceTest
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        private readonly ITimeService _timeService;
        private readonly IOrderService _orderService;


        public OrderServiceTest()
        {
            _orderRepository = new InMemoryOrderRepository();
            _productRepository = new InMemoryProductRepository();

            _productRepository.Create(new Product
            {
                ProductCode = "P1",
                Price = 100,
                CurrentPrice = 100,
                Stock = 1000
            });

            _timeService = new TimeService();
            _orderService = new OrderService(_orderRepository, _productRepository);
        }
        [Fact]
        public void CreateOrderSuccessTest()
        {
            _orderService.OrderCreate(new OrderCreateDto
            {
                ProductCode = "P1",
                Quantity = 1
            });
            Assert.True(true);
        }
        [Fact]
        public void CreateOrderErrorTest()
        {
            var ex = Assert.Throws<BusinessException>(() => _orderService.OrderCreate(new OrderCreateDto
            {
                ProductCode = "P3",
                Quantity = 1
            }));
            Assert.Equal("Not found product for the order.", ex.Message);
        }
    }
}
