using Core.Domain.Products.Data;
using Core.Domain.Products.Models;
using MediatR;
using Infrastructure;

namespace Application.Domain.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(StoreDbContext storeDbContext) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var data = new CreateProductData(
            request.Title,
            request.Price);

        var product = Product.Create(data);

        storeDbContext.Add(product);
        await storeDbContext.SaveChangesAsync(cancellationToken);
        
        return product.Id;
    }
}