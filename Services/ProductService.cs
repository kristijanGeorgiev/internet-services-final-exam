using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Interfaces;
using ProductStore.Application.Interfaces;
using ProductStore.Domain.Entities;

namespace ProductStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Create(Product product)
        {
            return await _repository.Add(product);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> GetByID(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Product> Update(Product product)
        {
            return await _repository.Update(product);
        }
    }
}
