using Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Add(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products
                             .Include(p => p.Categories) // Optional if needed
                             .ToListAsync();
    }

    public async Task<Product> Update(Product product)
    {
        var existingProduct = await _context.Products.FindAsync(product.Id);
        if (existingProduct == null)
        {
            return null;
        }

        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Price = product.Price;
        existingProduct.Categories = product.Categories;

        await _context.SaveChangesAsync();
        return existingProduct;
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Products
                             .Include(p => p.Categories)
                             .FirstOrDefaultAsync(p => p.Id == id);
    }
}
