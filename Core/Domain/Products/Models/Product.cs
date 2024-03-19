using Core.Common;
using Core.Domain.Clients.Models;

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
}