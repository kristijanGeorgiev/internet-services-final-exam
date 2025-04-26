using Xunit;
using Moq;
using ProductStore.Application.DTOs;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Services;

namespace ProductStore.Tests.Services
{
    public class StockImportServiceTests
    {
        [Fact]
        public async Task ImportAsync_CallsRepositoryImportOnce()
        {

            var mockRepo = new Mock<IStockRepository>();
            var service = new StockImportService(mockRepo.Object);

            var testData = new List<ImportProductDto>
            {
                new()
                {
                    Name = "Test CPU",
                    Description = "Test description",
                    Categories = new List<string> { "CPU" },
                    Price = 199.99M,
                    Quantity = 5
                }
            };


            await service.ImportAsync(testData);


            mockRepo.Verify(repo => repo.ImportAsync(It.IsAny<List<ImportProductDto>>()), Times.Once);
        }
    }
}
