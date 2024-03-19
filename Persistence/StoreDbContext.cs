using Core.Domain.Clients.Models;
using Core.Domain.Products.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    internal const string StoreDbSchema = "store";
    internal const string StoreDbMigrationsHistoryTable = "__StoreDbMigrationsHistory";

    public DbSet<Client> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(StoreDbSchema);
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
    }
}