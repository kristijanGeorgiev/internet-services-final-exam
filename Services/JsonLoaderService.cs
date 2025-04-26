using System.Text.Json;
using ProductStore.Application.DTOs;
using Microsoft.AspNetCore.Hosting;
namespace ProductStore.Infrastructure.Services
{
    public class JsonLoaderService
    {
        private readonly IWebHostEnvironment _env;

        public JsonLoaderService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public List<ImportProductDto> LoadStockFromJson()
        {
            string filePath = Path.Combine(_env.WebRootPath, "data", "stock.json");

            if (!File.Exists(filePath))
                return new List<ImportProductDto>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<ImportProductDto>>(json) ?? new List<ImportProductDto>();
        }
    }
}
