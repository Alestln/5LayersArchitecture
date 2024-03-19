using Application.Domain.Products.Commands.CreateProduct;
using Application.Domain.Products.Commands.UpdateProduct;
using AutoMapper;
using Core.Domain.Products.Models;
using DataTransfer.Dtos.Products;
using DataTransfer.Dtos.Products.Commands;

namespace Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateProjection<Product, ProductDto>();

        CreateProjection<Product, ProductDetailsDto>();

        CreateMap<CreateProductRequest, CreateProductCommand>();

        CreateMap<UpdateProductRequest, UpdateProductCommand>();
    }
}