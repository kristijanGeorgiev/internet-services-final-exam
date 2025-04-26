using Core.Domain.Interfaces;
using ProductStore.Domain.Entities;
using ProductStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Create(Category category)
        {
            return await _repository.Add(category);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Category> GetByID(int id)
        {
            return await _repository.GetByID(id);
        }

        public async Task<Category> Update(Category category)
        {
            return await _repository.Update(category);
        }
    }
}
