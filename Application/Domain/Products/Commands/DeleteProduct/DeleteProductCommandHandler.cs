using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

namespace Application.Domain.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(StoreDbContext storeDbContext) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var products = await storeDbContext.Products
            .Where(p => request.Ids.Contains(p.Id))
            .ToArrayAsync(cancellationToken);
        
        storeDbContext.Products.RemoveRange(products);

        await storeDbContext.SaveChangesAsync(cancellationToken);
    }
}