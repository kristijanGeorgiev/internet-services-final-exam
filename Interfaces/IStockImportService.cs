using ProductStore.Application.DTOs;

namespace ProductStore.Application.Interfaces
{
    public interface IStockImportService
    {
        Task ImportAsync(List<ImportProductDto> importProducts);
    }
}
