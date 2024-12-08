using MeuPonto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MeuPonto.Infrastructure;

public static class SqlServerDbModule
{
    public static IServiceCollection AddSqlServerDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<MeuPontoDbContext>(options =>
            options
                .UseSqlServer(connectionString, b => b.MigrationsAssembly("MeuPonto.EntityFrameworkCore.SqlServer"))
                .UseSqlServerModel());

        //

        return services;
    }

    public static DbContextOptionsBuilder UseSqlServerModel(this DbContextOptionsBuilder optionsBuilder)
    {
        return optionsBuilder.ReplaceService<IModelCustomizer, SqlServerModelCustomizer>();
    }

    public static void EnsureSqlServerDatabaseExists(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<MeuPontoDbContext>();
            var logger = scopedServices.GetRequiredService<ILogger<MeuPontoDbContext>>();

            logger.LogDebug("Starting database migration");

            try
            {
                db.Database.MigrateAsync();

                logger.LogDebug("Database migration finished");

                //Utilities.InitializeDbForTests(db);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred migrating the database" +
                    "Error: {Message}", ex.Message);
            }
        }
    }

    public static async Task EnsureSqlServerDatabaseExistsAsync(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<MeuPontoDbContext>();
            var logger = scopedServices.GetRequiredService<ILogger<MeuPontoDbContext>>();

            logger.LogDebug("Starting database migration");

            try
            {
                await db.Database.MigrateAsync();

                logger.LogDebug("Database migration finished");

                //Utilities.InitializeDbForTests(db);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred migrating the database" +
                    "Error: {Message}", ex.Message);
            }
        }
    }
}
