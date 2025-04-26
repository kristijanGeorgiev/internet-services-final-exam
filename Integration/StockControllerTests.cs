using Xunit;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductStore.Application.DTOs;
using Microsoft.VisualStudio.TestPlatform.TestHost;

public class StockControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public StockControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ImportStock_ReturnsOk()
    {
        var payload = new List<ImportProductDto>
        {
            new()
            {
                Name = "Test CPU",
                Description = "Test Description",
                Categories = new List<string> { "CPU" },
                Price = 199.99M,
                Quantity = 5
            }
        };

        var response = await _client.PostAsJsonAsync("/api/stock/import", payload);

        response.EnsureSuccessStatusCode();
    }
}
