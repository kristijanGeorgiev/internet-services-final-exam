using ProductStore.Application.DTOs;

namespace ProductStore.Application.Interfaces
{
    public interface IStockRepository
    {
        Task ImportAsync(List<ImportProductDto> importProducts);
    }
}