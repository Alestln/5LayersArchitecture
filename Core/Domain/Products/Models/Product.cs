using Core.Common;
using Core.Domain.Clients.Models;
using Core.Domain.Products.Data;
using Core.Domain.Products.Validators;

namespace Core.Domain.Products.Models;

public class Product : Entity
{
    private readonly List<Client> _clients = new();
    
    private Product()
    {
        
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public IReadOnlyList<Client> Clients => _clients.AsReadOnly();

    public static Product Create(CreateProductData data)
    {
        Validate(new CreateProductValidator(), data);

        return new Product()
        {
            Id = Guid.NewGuid(),
            Title = data.Title,
            Price = data.Price
        };
    }

    public void Update(UpdateProductData data)
    {
        Validate(new UpdateProductValidator(), data);

        Title = data.Title;
        Price = data.Price;
    }
}