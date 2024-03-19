using AutoMapper;
using Core.Domain.Products.Models;
using Infrastructure.Dtos.Products;
using Infrastructure.Dtos.Products.Commands;

namespace Infrastructure.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateProjection<Product, ProductDto>();

        CreateProjection<Product, ProductDetailsDto>();
    }
}