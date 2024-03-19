using Infrastructure.Dtos.Products;
using MediatR;
using PagesResponses;

namespace Application.Domain.Products.Queries.GetProducts;

public record GetProductsQuery(int Page, int PageSize) : IRequest<PageResponse<ProductDto[]>>;