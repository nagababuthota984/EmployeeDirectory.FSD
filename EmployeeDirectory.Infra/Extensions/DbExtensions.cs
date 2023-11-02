
using DbUp;
using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Infra.Persistence.Postgres.Dapper;
using EmployeeDirectory.Infra.Persistence.Postgres.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace EmployeeDirectory.Infra.Extensions
{
    public static class DbExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfigurationRoot config)
        {
            //Ef Core
            services.AddDbContext<IApplicationDbContext,EmployeeDirectoryDbContext>(options => options.UseNpgsql(config.GetConnectionString("Postgres")));
            //Dapper
            services.AddSingleton<IDapperContext, DapperContext>();
        }

        public static IApplicationBuilder MigrateDatabase<TContext>(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfigurationRoot>();
                var logger = services.GetRequiredService<ILogger<TContext>>();

                logger.LogInformation("Migrating postresql database.");

                string connection = configuration.GetConnectionString("Postgres") ?? string.Empty;

                EnsureDatabase.For.PostgresqlDatabase(connection);

                var upgrader = DeployChanges.To
                    .PostgresqlDatabase(connection)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

                var result = upgrader.PerformUpgrade();

                if (!result.Successful)
                {
                    logger.LogError(result.Error, "An error occurred while migrating the postresql database");
                    return app;
                }

                logger.LogInformation("Migrated postresql database.");
            }
            return app;
        }
    }
}
