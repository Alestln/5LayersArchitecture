namespace Core.Domain.Products.Data;

public record CreateProductData(
    string Title,
    decimal Price);