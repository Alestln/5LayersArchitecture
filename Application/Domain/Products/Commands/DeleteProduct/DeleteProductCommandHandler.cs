using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Domain.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly StoreDbContext _storeDbContext;

    public DeleteProductCommandHandler(StoreDbContext storeDbContext)
    {
        _storeDbContext = storeDbContext;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var products = await _storeDbContext.Products
            .Where(p => request.Ids.Contains(p.Id))
            .ToArrayAsync(cancellationToken);
        
        _storeDbContext.Products.RemoveRange(products);

        await _storeDbContext.SaveChangesAsync(cancellationToken);
    }
}