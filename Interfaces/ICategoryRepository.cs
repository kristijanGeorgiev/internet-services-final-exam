using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByID(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<bool> Delete(int id);
    }
}
