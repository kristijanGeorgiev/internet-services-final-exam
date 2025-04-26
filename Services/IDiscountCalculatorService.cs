using Core.Application.DTOs;

namespace Core.Application.Services
{
    public interface IDiscountCalculatorService
    {
        Task<DiscountResultDto> CalculateDiscountAsync(IEnumerable<BasketItemDto> basket);
    }
}