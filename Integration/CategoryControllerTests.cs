using System.Net;
using System.Net.Http.Json;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductStore.Domain.Entities;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ProductStore.Tests.Integration
{
    public class CategoryControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CategoryControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllCategories_ReturnsOk()
        {

            var response = await _client.GetAsync("/api/categories");


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostCategory_ReturnsOk_AndCanRetrieve()
        {

            var newCategory = new Category
            {
                Name = "Test Category",
                Description = "For testing",
                Products = new List<Product>()
            };


            var postResponse = await _client.PostAsJsonAsync("/api/categories", newCategory);


            postResponse.EnsureSuccessStatusCode();
            var created = await postResponse.Content.ReadFromJsonAsync<Category>();
            Assert.NotNull(created);
            Assert.Equal("Test Category", created!.Name);


            var getResponse = await _client.GetAsync($"/api/categories/{created.Id}");
            var fetched = await getResponse.Content.ReadFromJsonAsync<Category>();


            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(created.Id, fetched!.Id);
        }
        [Fact]
        public async Task UpdateCategory_ReturnsNoContent()
        {

            var newCategory = new Category
            {
                Name = "Original Category",
                Description = "Before update",
                Products = new List<Product>()
            };

            var postResponse = await _client.PostAsJsonAsync("/api/categories", newCategory);
            var created = await postResponse.Content.ReadFromJsonAsync<Category>();


            created!.Name = "Updated Category";
            created.Description = "Updated description";

            var putResponse = await _client.PutAsJsonAsync($"/api/categories/{created.Id}", created);


            Assert.Equal(HttpStatusCode.NoContent, putResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteCategory_ReturnsNoContent()
        {

            var newCategory = new Category
            {
                Name = "To Be Deleted",
                Description = "Will be removed",
                Products = new List<Product>()
            };

            var postResponse = await _client.PostAsJsonAsync("/api/categories", newCategory);
            var created = await postResponse.Content.ReadFromJsonAsync<Category>();


            var deleteResponse = await _client.DeleteAsync($"/api/categories/{created!.Id}");


            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);


            var getResponse = await _client.GetAsync($"/api/categories/{created.Id}");
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

    }
}
