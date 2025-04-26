using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetByID(int id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<bool> Delete(int id);
    }
}
