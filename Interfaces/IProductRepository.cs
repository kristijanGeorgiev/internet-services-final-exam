using ProductStore.Domain.Entities;

namespace Core.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<bool> Delete(int id);
    }
}