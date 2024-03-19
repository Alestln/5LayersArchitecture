using Infrastructure.Dtos.Products;
using MediatR;

namespace Application.Domain.Products.Queries.GetProductDetails;

public record GetProductDetailsQuery(Guid Id) : IRequest<ProductDetailsDto>;