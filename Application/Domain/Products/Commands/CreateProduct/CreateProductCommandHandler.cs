using Core.Domain.Products.Data;
using Core.Domain.Products.Models;
using MediatR;
using Persistence;

namespace Application.Domain.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly StoreDbContext _storeDbContext;

    public CreateProductCommandHandler(StoreDbContext storeDbContext)
    {
        _storeDbContext = storeDbContext;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var data = new CreateProductData(
            request.Title,
            request.Price);

        var product = Product.Create(data);

        _storeDbContext.Add(product);
        await _storeDbContext.SaveChangesAsync(cancellationToken);
        
        return product.Id;
    }
}