namespace DataTransfer.Dtos.Products.Commands;

public record UpdateProductRequest(
    Guid Id,
    string Title,
    decimal Price);