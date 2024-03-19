using MediatR;

namespace Application.Domain.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Title,
    decimal Price) : IRequest<Guid>;