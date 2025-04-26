using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ProductStore.Application.Services;
using ProductStore.Application.Interfaces;
using ProductStore.Domain.Entities;
using Core.Domain.Interfaces;

namespace ProductStore.Tests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new() { Id = 1, Name = "CPU", Price = 299.99M, Quantity = 10 },
                new() { Id = 2, Name = "Keyboard", Price = 49.99M, Quantity = 20 }
            };

            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(products);

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AddAsync_CallsRepositoryWithProduct()
        {
            // Arrange
            var product = new Product
            {
                Name = "GPU",
                Price = 499.99M,
                Quantity = 5
            };

            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);

            // Act
            await service.Create(product);

            // Assert
            mockRepo.Verify(r => r.Add(It.Is<Product>(p => p.Name == "GPU")), Times.Once);
        }
    }
}

