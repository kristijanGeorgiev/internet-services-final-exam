using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetByID(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<bool> Delete(int id);
    }
}
