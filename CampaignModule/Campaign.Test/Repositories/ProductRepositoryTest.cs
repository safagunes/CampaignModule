using Campaign.Domain.Exceptions;
using Campaign.Domain.Models;
using Campaign.Domain.Repositories;
using Campaign.Infrastructure.Repositories.InMemory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Campaign.Test.Repositories
{
    public class ProductRepositoryTest
    {
        private readonly IProductRepository _productRepository;
        public ProductRepositoryTest()
        {
            _productRepository = new InMemoryProductRepository();
            _productRepository.Create(new Product
            {
                ProductCode = "P1",
                Price = 100,
                CurrentPrice = 100,
                Stock = 1000
            });
        }

        [Fact]
        public void GetSuccessTest()
        {
            var productInfo = _productRepository.Get("P1");
            Assert.True(productInfo != null);
        }

        [Fact]
        public void GetNullTest()
        {
            var productInfo = _productRepository.Get("P2");
            Assert.True(productInfo == null);
        }

        [Fact]
        public void CreateSuccessTest()
        {
            _productRepository.Create(new Product
            {
                ProductCode = "P2",
                Price = 100,
                CurrentPrice = 100,
                Stock = 1
            });
            Assert.True(true);
        }
        [Fact]
        public void CreateErrorTest()
        {
            var ex = Assert.Throws<DatabaseException>(() => _productRepository.Create(new Product
            {
                ProductCode = "P1",
                Price = 100,
                CurrentPrice = 100,
                Stock = 1
            }));
            Assert.Equal("Product already exist.", ex.Message);
        }
    }
}
