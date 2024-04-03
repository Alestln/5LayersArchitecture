using Application.Domain.Products.Commands.CreateProduct;
using Application.Domain.Products.Commands.UpdateProduct;
using AutoMapper;
using Core.Domain.Products.Data;
using Core.Domain.Products.Models;
using DataTransfer.Dtos.Products;
using DataTransfer.Dtos.Products.Commands;

namespace Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // Create queries
        CreateProjection<Product, ProductDto>();
        CreateProjection<Product, ProductDetailsDto>();

        // Create commands
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<UpdateProductRequest, UpdateProductCommand>();

        // Create domains
        CreateMap<CreateProductCommand, CreateProductData>();
        CreateMap<UpdateProductCommand, UpdateProductData>();
    }
}