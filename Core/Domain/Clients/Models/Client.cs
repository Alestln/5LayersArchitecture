using Core.Common;
using Core.Domain.Products.Models;

namespace Core.Domain.Clients.Models;

public class Client : Entity
{
    private readonly List<Product> _products = new();
    
    private Client()
    {
        
    }
    
    public Guid Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public DateTime Birthday { get; set; }

    public IReadOnlyList<Product> Products => _products.AsReadOnly();
}