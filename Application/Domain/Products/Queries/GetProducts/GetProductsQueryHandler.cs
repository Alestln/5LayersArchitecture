using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Dtos.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PagesResponses;
using Persistence;

namespace Application.Domain.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PageResponse<ProductDto[]>>
{
    private readonly StoreDbContext _storeDbContext;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(StoreDbContext storeDbContext, IMapper mapper)
    {
        _storeDbContext = storeDbContext;
        _mapper = mapper;
    }

    public async Task<PageResponse<ProductDto[]>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _storeDbContext.Products
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

        return new PageResponse<ProductDto[]>(products.Length, products);
    }
}