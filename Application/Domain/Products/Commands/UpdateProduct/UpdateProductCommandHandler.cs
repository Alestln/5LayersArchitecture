using Core.Domain.Products.Data;
using Core.Domain.Products.Models;
using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Domain.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly StoreDbContext _storeDbContext;

    public UpdateProductCommandHandler(StoreDbContext storeDbContext)
    {
        _storeDbContext = storeDbContext;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _storeDbContext.Products
                          .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                      ?? throw new NotFoundException($"{nameof(Product)} with id: '{request.Id}' was not found.");

        var data = new UpdateProductData(
            request.Title,
            request.Price);
        
        product.Update(data);
        await _storeDbContext.SaveChangesAsync(cancellationToken);
    }
}