using MediatR;

namespace Application.Domain.Products.Commands.DeleteProduct;

public record DeleteProductCommand(IReadOnlyCollection<Guid> Ids) : IRequest;