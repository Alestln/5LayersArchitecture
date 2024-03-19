using Core.Domain.Products.Data;
using Core.Domain.Products.Models;
using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

namespace Application.Domain.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler(StoreDbContext storeDbContext) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await storeDbContext.Products
                          .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                      ?? throw new NotFoundException($"{nameof(Product)} with id: '{request.Id}' was not found.");

        var data = new UpdateProductData(
            request.Title,
            request.Price);
        
        product.Update(data);
        await storeDbContext.SaveChangesAsync(cancellationToken);
    }
}