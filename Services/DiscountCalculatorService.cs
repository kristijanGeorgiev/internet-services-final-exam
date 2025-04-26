using Core.Application.DTOs;
using Core.Application.Services;
using Core.Domain.Interfaces;

namespace Infrastructure.Services
{
    public class DiscountCalculatorService : IDiscountCalculatorService
    {
        private readonly IProductRepository _productRepository;

        public DiscountCalculatorService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DiscountResultDto> CalculateDiscountAsync(IEnumerable<BasketItemDto> basket)
        {
            var products = new Dictionary<int, ProductStore.Domain.Entities.Product>();
            decimal total = 0m;
            decimal discount = 0m;

            var categoryCounts = new Dictionary<string, int>();

            foreach (var item in basket)
            {
                var product = await _productRepository.GetById(item.ProductId);
                if (product == null)
                    throw new ArgumentException($"Product with ID {item.ProductId} not found.");

                // Track total and category counts
                total += product.Price * item.Quantity;

                foreach (var category in product.Categories)
                {
                    if (!categoryCounts.ContainsKey(category.Name))
                        categoryCounts[category.Name] = 0;
                    categoryCounts[category.Name]++;
                }

                // Apply discount rule #3 and #2
                if (item.Quantity > 1)
                {
                    foreach (var category in product.Categories)
                    {
                        if (categoryCounts[category.Name] > 1)
                        {
                            discount += product.Price * 0.05m;
                            break; // only once per product
                        }
                    }
                }
            }

            return new DiscountResultDto
            {
                TotalPrice = total,
                DiscountApplied = discount
            };
        }
    }
}
