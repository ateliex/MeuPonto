using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeuPonto.Infrastructure;

public static class InfrastructureModule
{
    private static bool _local = true;

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (_local)
        {
            services.AddSqliteDbServices(configuration);
        }
        else
        {
            services.AddSqlServerDbServices(configuration);
        }

        //

        return services;
    }

    public static void EnsureDatabaseExists(this IServiceProvider serviceProvider)
    {
        if (_local)
        {
            serviceProvider.EnsureSqliteDatabaseExists();
        }
        else
        {
            serviceProvider.EnsureSqlServerDatabaseExists();
        }
    }

    public static async Task EnsureDatabaseExistsAsync(this IServiceProvider serviceProvider)
    {
        if (_local)
        {
            await serviceProvider.EnsureSqliteDatabaseExistsAsync();
        }
        else
        {
            await serviceProvider.EnsureSqlServerDatabaseExistsAsync();
        }
    }
}
