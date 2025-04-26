using System.Net;
using System.Net.Http.Json;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

using ProductStore.Domain.Entities;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ProductStore.Tests.Integration
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllProducts_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/products");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostProduct_ReturnsOk_AndCanRetrieve()
        {

            var product = new Product
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 99.99m,
                Quantity = 10,
                Categories = new List<Category>() // Optional if Categories are required
            };


            var postResponse = await _client.PostAsJsonAsync("/api/products", product);

            postResponse.EnsureSuccessStatusCode();
            var created = await postResponse.Content.ReadFromJsonAsync<Product>();
            Assert.NotNull(created);
            Assert.Equal("Test Product", created!.Name);


            var getResponse = await _client.GetAsync($"/api/products/{created.Id}");
            var fetched = await getResponse.Content.ReadFromJsonAsync<Product>();

            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(created.Id, fetched!.Id);
        }
        [Fact]
        public async Task UpdateProduct_ReturnsOk()
        {

            var product = new Product
            {
                Name = "Original Product",
                Description = "Before Update",
                Price = 50,
                Quantity = 1,
                Categories = new List<Category>()
            };

            var postResponse = await _client.PostAsJsonAsync("/api/products", product);
            var created = await postResponse.Content.ReadFromJsonAsync<Product>();


            created!.Name = "Updated Product";
            created.Description = "After Update";


            var putResponse = await _client.PutAsJsonAsync($"/api/products/{created.Id}", created);
            Assert.Equal(HttpStatusCode.NoContent, putResponse.StatusCode);


            var getResponse = await _client.GetAsync($"/api/products/{created.Id}");
            var updated = await getResponse.Content.ReadFromJsonAsync<Product>();

            Assert.Equal("Updated Product", updated!.Name);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsOk()
        {

            var product = new Product
            {
                Name = "To Delete",
                Description = "Will be deleted",
                Price = 10,
                Quantity = 5,
                Categories = new List<Category>()
            };

            var postResponse = await _client.PostAsJsonAsync("/api/products", product);
            var created = await postResponse.Content.ReadFromJsonAsync<Product>();


            var deleteResponse = await _client.DeleteAsync($"/api/products/{created!.Id}");
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);


            var getResponse = await _client.GetAsync($"/api/products/{created.Id}");
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }
    }
}
