﻿using System.ComponentModel.DataAnnotations;

namespace DataTransfer.Dtos.Products;

public class ProductDto
{
    [Required] 
    public Guid Id { get; init; }
    
    [Required] 
    public string Title { get; init; }
    
    [Required] 
    public decimal Price { get; init; }
}