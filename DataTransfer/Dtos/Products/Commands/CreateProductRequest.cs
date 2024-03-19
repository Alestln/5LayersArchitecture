namespace DataTransfer.Dtos.Products.Commands;

public record CreateProductRequest(
    string Title,
    decimal Price);