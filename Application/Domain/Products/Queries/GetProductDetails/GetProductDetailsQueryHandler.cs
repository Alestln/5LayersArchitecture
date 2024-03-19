using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.Products.Models;
using Core.Exceptions;
using DataTransfer.Dtos.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

namespace Application.Domain.Products.Queries.GetProductDetails;

public class GetProductDetailsQueryHandler(StoreDbContext storeDbContext, IMapper mapper)
    : IRequestHandler<GetProductDetailsQuery, ProductDetailsDto>
{
    public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var product = await storeDbContext.Products
            .ProjectTo<ProductDetailsDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Product)} with id: '{request.Id}' was not found.");

        return product;
    }
}