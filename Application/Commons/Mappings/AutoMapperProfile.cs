using Application.Products.Commands;
using Application.Products.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductGetResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));

        CreateMap<Category, CategoryResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
