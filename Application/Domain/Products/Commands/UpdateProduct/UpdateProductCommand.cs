using MediatR;

namespace Application.Domain.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Title,
    decimal Price) : IRequest;