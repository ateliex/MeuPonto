namespace MeuPonto.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var useLocalDatabase = configuration.GetValue<bool>("UseLocalDatabase");

        if (useLocalDatabase)
        {
            services.AddSqliteDbServices(configuration);
        }
        else
        {
            services.AddSqlServerDbServices(configuration);
        }

        return services;
    }

    public static void EnsureDatabaseExists(this IServiceProvider services, IConfiguration configuration)
    {
        var useLocalDatabase = configuration.GetValue<bool>("UseLocalDatabase");

        if (useLocalDatabase)
        {
            services.EnsureSqliteDatabaseExists();
        }
        else
        {
            services.EnsureSqlServerDatabaseExists();
        }
    }

    public static async Task EnsureDatabaseExistsAsync(this IServiceProvider services, IConfiguration configuration)
    {
        var useLocalDatabase = configuration.GetValue<bool>("UseLocalDatabase");

        if (useLocalDatabase)
        {
            await services.EnsureSqliteDatabaseExistsAsync();
        }
        else
        {
            await services.EnsureSqlServerDatabaseExistsAsync();
        }
    }
}
