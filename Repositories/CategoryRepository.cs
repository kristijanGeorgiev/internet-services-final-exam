using ProductStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Data;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> Add(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return false;
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories
                             .Include(p => p.Products)
                             .ToListAsync();
    }

    public async Task<Category?> GetByID(int id)
    {
        return await _context.Categories
                             .Include(p => p.Products)
                             .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Category> Update(Category category)
    {
        var existingCategory = await _context.Categories.FindAsync(category.Id);
        if (existingCategory == null)
        {
            return null;
        }

        existingCategory.Name = category.Name;
        existingCategory.Description = category.Description;
        existingCategory.Products = category.Products;

        await _context.SaveChangesAsync();
        return existingCategory;
    }
}