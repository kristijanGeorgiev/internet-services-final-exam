using ProductStore.Application.DTOs;
using ProductStore.Application.Interfaces;

namespace ProductStore.Application.Services;

public class StockImportService : IStockImportService
{
    private readonly IStockRepository _repository;

    public StockImportService(IStockRepository repository)
    {
        _repository = repository;
    }

    public async Task ImportAsync(List<ImportProductDto> importProducts)
    {
        await _repository.ImportAsync(importProducts);
    }
}