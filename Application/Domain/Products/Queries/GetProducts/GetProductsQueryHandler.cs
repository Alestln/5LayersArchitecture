using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataTransfer.Dtos.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PagesResponses;
using Infrastructure;

namespace Application.Domain.Products.Queries.GetProducts;

public class GetProductsQueryHandler(StoreDbContext storeDbContext, IMapper mapper)
    : IRequestHandler<GetProductsQuery, PageResponse<ProductDto[]>>
{
    public async Task<PageResponse<ProductDto[]>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await storeDbContext.Products
            .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

        return new PageResponse<ProductDto[]>(products.Length, products);
    }
}