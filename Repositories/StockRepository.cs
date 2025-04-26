using ProductStore.Application.DTOs;
using ProductStore.Application.Interfaces;
using ProductStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ProductStore.Infrastructure.Data;

namespace ProductStore.Infrastructure.Repositories;

public class StockRepository : IStockRepository
{
    private readonly ApplicationDbContext _context;

    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task ImportAsync(List<ImportProductDto> importProducts)
    {
        foreach (var item in importProducts)
        {
            var categoryNames = item.Categories.Select(c => c.Trim()).ToList();

            var categories = new List<Category>();
            foreach (var catName in categoryNames)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == catName);
                if (category == null)
                {
                    category = new Category { Name = catName };
                    _context.Categories.Add(category);
                }
                categories.Add(category);
            }

            var existingProduct = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(p => p.Name == item.Name);

            if (existingProduct != null)
            {
                existingProduct.Quantity += item.Quantity;
            }
            else
            {
                var newProduct = new Product
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Description = item.Description,
                    Categories = categories
                };
                _context.Products.Add(newProduct);
            }
        }

        await _context.SaveChangesAsync();
    }
}
