using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.Products.Models;
using Core.Exceptions;
using Infrastructure.Dtos.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Domain.Products.Queries.GetProductDetails;

public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsDto>
{
    private readonly StoreDbContext _storeDbContext;
    private readonly IMapper _mapper;

    public GetProductDetailsQueryHandler(StoreDbContext storeDbContext, IMapper mapper)
    {
        _storeDbContext = storeDbContext;
        _mapper = mapper;
    }

    public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var product = await _storeDbContext.Products
            .ProjectTo<ProductDetailsDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Product)} with id: '{request.Id}' was not found.");

        return product;
    }
}