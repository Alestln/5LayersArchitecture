using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class PersistenceRegistration
{
    private const string ConnectionStringName = "Store";

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName)
                               ?? throw new AggregateException(
                                   $"Connection string '{ConnectionStringName}' is not found in configurations.");

        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        StoreDbContext.StoreDbMigrationsHistoryTable,
                        StoreDbContext.StoreDbSchema);
                });
        });
    }
}