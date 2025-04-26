using ProductStore.Application.DTOs;
using ProductStore.Domain.Entities;

namespace ProductStore.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ImportProductDto>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(c => c.Name)))
                .ReverseMap()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());

            CreateMap<Category, string>().ConvertUsing(c => c.Name);
        }
    }
}
