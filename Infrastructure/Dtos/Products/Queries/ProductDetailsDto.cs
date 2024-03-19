using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos.Products;

public class ProductDetailsDto
{
    [Required]
    public Guid Id { get; init; }

    [Required]
    public string Title { get; init; }

    [Required]
    public decimal Price { get; init; }
}