using AutoMapper;
using Core.Domain.Products.Data;
using Core.Domain.Products.Models;
using MediatR;
using Infrastructure;

namespace Application.Domain.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(StoreDbContext storeDbContext, IMapper mapper) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var data = mapper.Map<CreateProductData>(request);

        var product = Product.Create(data);

        storeDbContext.Add(product);
        await storeDbContext.SaveChangesAsync(cancellationToken);
        
        return product.Id;
    }
}